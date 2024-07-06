
#import <AppMetricaCore/AppMetricaCore.h>
#import <AppMetricaCrashes/AppMetricaCrashes.h>
#import "AMAUAppMetricaProxy.h"
#import "AMAUAdRevenueInfo.h"
#import "AMAUAppMetricaConfiguration.h"
#import "AMAUAppMetricaCrashesConfiguration.h"
#import "AMAUECommerceEvent.h"
#import "AMAUException.h"
#import "AMAUExternalAttribution.h"
#import "AMAULocation.h"
#import "AMAUReporterConfiguration.h"
#import "AMAURevenueInfo.h"
#import "AMAUStartupParamsCallbackProxy.h"
#import "AMAUUserProfile.h"
#import "AMAUUtils.h"

void amau_activate(char *configJson)
{
    AMAAppMetricaConfiguration *config = amau_deserializeAppMetricaConfiguration(configJson);
    if (config != nil) {
        // pre-processing of the config
        NSDictionary *dict = amau_dictionaryFromCString(configJson);
        // put ErrorEnvironment from config
        if (dict[@"ErrorEnvironment"] != nil) {
            NSDictionary *env = dict[@"ErrorEnvironment"];
            for (NSString *key in env) {
                [[AMAAppMetricaCrashes crashes] setErrorEnvironmentValue:env[key] forKey:key];
            }
        }
        
        if (AMAAppMetrica.isActivated) {
            NSLog(@"Skip AppMetrica activate. AppMetrica has already been started");
        } else {
            [AMAAppMetrica activateWithConfiguration:config];
        }
        [[AMAAppMetricaCrashes crashes] setConfiguration: amau_deserializeAppMetricaCrashesConfiguration(configJson)];
        [[[AMAAppMetricaCrashes crashes] pluginExtension] handlePluginInitFinished];
    } else {
        NSLog(@"Failed to deserialize AppMetrica configuration: %s", configJson);
    }
}

void amau_activateReporter(char *configJson)
{
    AMAReporterConfiguration *config = amau_deserializeReporterConfiguration(configJson);
    if (config != nil) {
        [AMAAppMetrica activateReporterWithConfiguration:config];
        
        // post-processing of the config
        NSDictionary *dict = amau_dictionaryFromCString(configJson);
        id<AMAAppMetricaReporting> reporter = [AMAAppMetrica reporterForAPIKey:config.APIKey];
        // put appEnvironment from config
        if (dict[@"AppEnvironment"] != nil) {
            NSDictionary *env = dict[@"AppEnvironment"];
            for (NSString *key in env) {
                [reporter setAppEnvironmentValue:env[key] forKey:key];
            }
        }
    } else {
        NSLog(@"Failed to deserialize AppMetrica reporter configuration: %s", configJson);
    }
}

void amau_clearAppEnvironment()
{
    [AMAAppMetrica clearAppEnvironment];
}

char *amau_getDeviceID()
{
    return amau_cStringFromString(AMAAppMetrica.deviceID);
}

char *amau_getLibraryVersion()
{
    return amau_cStringFromString(AMAAppMetrica.libraryVersion);
}

char *amau_getUuid()
{
    return amau_cStringFromString(AMAAppMetrica.UUID);
}

bool amau_isActivated()
{
    return AMAAppMetrica.isActivated;
}

void amau_pauseSession()
{
    [AMAAppMetrica pauseSession];
}

void amau_putAppEnvironmentValue(char *key, char *value)
{
    [AMAAppMetrica setAppEnvironmentValue:amau_stringFromCString(value) forKey:amau_stringFromCString(key)];
}

void amau_putErrorEnvironmentValue(char *key, char *value)
{
    [[AMAAppMetricaCrashes crashes] setErrorEnvironmentValue:amau_stringFromCString(value) forKey:amau_stringFromCString(key)];
}

void amau_reportAdRevenue(char *adRevenueJson)
{
    AMAAdRevenueInfo *adRevenue = amau_deserializeAdRevenueInfo(adRevenueJson);
    if (adRevenue != nil) {
        [AMAAppMetrica reportAdRevenue:adRevenue onFailure:^(NSError *error) {
            NSLog(@"Failed to report AdRevenue to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        NSLog(@"Failed to deserialize AppMetrica AdRevenue: %s", adRevenueJson);
    }
}

void amau_reportAppOpen(char *deeplink)
{
    NSString *url = amau_stringFromCString(deeplink);
    if (url != nil) {
        [AMAAppMetrica trackOpeningURL:[[NSURL alloc] initWithString:url]];
    } else {
        NSLog(@"Failed to trackOpeningURL %s. Url is nil", deeplink);
    }
}

void amau_reportECommerce(char *eCommerceJson)
{
    AMAECommerce *eCommerce = amau_deserializeECommerce(eCommerceJson);
    if (eCommerce != nil) {
        [AMAAppMetrica reportECommerce:eCommerce onFailure:^(NSError *error) {
            NSLog(@"Failed to report ECommerce to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        NSLog(@"Failed to deserialize AppMetrica ECommerce: %s", eCommerceJson);
    }
}

void amau_reportErrorWithoutIdentifier(char *messageCString, char *errorJson)
{
    NSString *message = amau_stringFromCString(messageCString);
    AMAPluginErrorDetails *error = amau_deserializeException(errorJson);
    if (error.backtrace.count == 0) {
        [[[AMAAppMetricaCrashes crashes] pluginExtension] reportErrorWithIdentifier:@"Errors without stacktrace"
                                                                            message:message
                                                                            details:error
                                                                          onFailure:^(NSError *error) {
            NSLog(@"Failed to report error to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        [[[AMAAppMetricaCrashes crashes] pluginExtension] reportError:error message:message onFailure:^(NSError *error) {
            NSLog(@"Failed to report error to AppMetrica: %@", [error localizedDescription]);
        }];
    }
}

void amau_reportError(char *identifier, char *message, char *error)
{
    [[[AMAAppMetricaCrashes crashes] pluginExtension] reportErrorWithIdentifier:amau_stringFromCString(identifier)
                                                                        message:amau_stringFromCString(message)
                                                                        details:amau_deserializeException(error)
                                                                      onFailure:^(NSError *error) {
        NSLog(@"Failed to report error to AppMetrica: %@", [error localizedDescription]);
    }];
}

void amau_reportEvent(char *message, char *paramsJson)
{
    [AMAAppMetrica reportEvent:amau_stringFromCString(message)
                    parameters:amau_dictionaryFromCString(paramsJson)
                     onFailure:^(NSError *error) {
        NSLog(@"Failed to report event to AppMetrica: %@", [error localizedDescription]);
    }];
}

void amay_reportExternalAttribution(char *sourceStr, char *value)
{
    AMAAttributionSource source = amau_getExternalAttributionSource(sourceStr);
    if (source == nil) {
        NSLog(@"Failed to report external attribution to AppMetrica. Unknown source %s", sourceStr);
        return;
    }
    
    NSDictionary *dict = amau_dictionaryFromCString(value);
    [AMAAppMetrica reportExternalAttribution:dict source:source onFailure:^(NSError *error) {
        NSLog(@"Failed to report external attribution to AppMetrica: %@", [error localizedDescription]);
    }];
}

void amau_reportRevenue(char *revenueJson)
{
    AMARevenueInfo *revenueInfo = amau_deserializeRevenueInfo(revenueJson);
    if (revenueInfo != nil) {
        [AMAAppMetrica reportRevenue:revenueInfo onFailure:^(NSError *error) {
            NSLog(@"Failed to report Revenue to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        NSLog(@"Failed to deserialize AppMetrica Revenue: %s", revenueJson);
    }
}

void amau_reportUnhandledException(char *exception)
{
    [[[AMAAppMetricaCrashes crashes] pluginExtension] reportUnhandledException:amau_deserializeException(exception)
                                                                     onFailure:^(NSError *error) {
        NSLog(@"Failed to report unhandled exception to AppMetrica: %@", [error localizedDescription]);
    }];
}

void amau_reportUserProfile(char *userProfileJson)
{
    AMAUserProfile *userProfile = amau_deserializeUserProfile(userProfileJson);
    if (userProfile != nil) {
        [AMAAppMetrica reportUserProfile:userProfile onFailure:^(NSError *error) {
            NSLog(@"Failed to report UserProfile to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        NSLog(@"Failed to deserialize AppMetrica UserProfile: %s", userProfileJson);
    }
}

void amau_requestStartupParams(char *identifiersJson, AMAUStartupParamsCallbackDelegate delegate, AMAUAction actionPtr)
{
    NSArray *identifiers = amau_fixStartupParamsKeys(amau_arrayFromCString(identifiersJson));
    [AMAAppMetrica requestStartupIdentifiersWithKeys:identifiers
                                     completionQueue:nil
                                     completionBlock:^(NSDictionary<AMAStartupKey,id> * _Nullable identifiers, NSError * _Nullable error) {
        if (delegate != nil) {
            delegate(actionPtr, amau_serializeStartupParamsResult(identifiers), amau_serializeStartupParamsError(error));
        }
    }];
}

void amau_resumeSession()
{
    [AMAAppMetrica resumeSession];
}

void amau_sendEventsBuffer()
{
    [AMAAppMetrica sendEventsBuffer];
}

void amau_setDataSendingEnabled(bool enabled)
{
    [AMAAppMetrica setDataSendingEnabled:enabled];
}

void amau_setLocation(char *location)
{
    AMAAppMetrica.customLocation = amau_deserializeLocation(amau_stringFromCString(location));
}

void amau_setLocationTracking(bool enabled)
{
    AMAAppMetrica.locationTrackingEnabled = enabled;
}

void amau_setUserProfileID(char *userProfileID)
{
    [AMAAppMetrica setUserProfileID:amau_stringFromCString(userProfileID)];
}

void amau_touchReporter(char *apiKey)
{
    [AMAAppMetrica reporterForAPIKey:amau_stringFromCString(apiKey)];
}
