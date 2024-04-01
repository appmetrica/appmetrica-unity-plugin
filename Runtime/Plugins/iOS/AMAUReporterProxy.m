
#import <AppMetricaCore/AppMetricaCore.h>
#import <AppMetricaCrashes/AppMetricaCrashes.h>
#import "AMAUReporterProxy.h"
#import "AMAUAdRevenueInfo.h"
#import "AMAUECommerceEvent.h"
#import "AMAUException.h"
#import "AMAURevenueInfo.h"
#import "AMAUUserProfile.h"
#import "AMAUUtils.h"

id<AMAAppMetricaReporting> amau_getReporter(char *apiKey)
{
    return [AMAAppMetrica reporterForAPIKey:amau_stringFromCString(apiKey)];
}

id<AMAAppMetricaCrashReporting> amau_getCrashReporter(char *apiKey)
{
    return [[AMAAppMetricaCrashes crashes] reporterForAPIKey:amau_stringFromCString(apiKey)];
}

void amau_reporterClearAppEnvironment(char *apiKey)
{
    [amau_getReporter(apiKey) clearAppEnvironment];
}

void amau_reporterPauseSession(char *apiKey)
{
    [amau_getReporter(apiKey) pauseSession];
}

void amau_reporterPutAppEnvironmentValue(char *apiKey, char *key, char *value)
{
    [amau_getReporter(apiKey) setAppEnvironmentValue:amau_stringFromCString(value)
                                              forKey:amau_stringFromCString(key)];
}

void amau_reporterReportAdRevenue(char *apiKey, char *adRevenueJson)
{
    AMAAdRevenueInfo *adRevenue = amau_deserializeAdRevenueInfo(adRevenueJson);
    if (adRevenue != nil) {
        [amau_getReporter(apiKey) reportAdRevenue:adRevenue onFailure:^(NSError *error) {
            NSLog(@"Failed to report AdRevenue to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        NSLog(@"Failed to deserialize AppMetrica AdRevenue: %s", adRevenueJson);
    }
}

void amau_reporterReportECommerce(char *apiKey, char *eCommerceJson)
{
    AMAECommerce *eCommerce = amau_deserializeECommerce(eCommerceJson);
    if (eCommerce != nil) {
        [amau_getReporter(apiKey) reportECommerce:eCommerce onFailure:^(NSError *error) {
            NSLog(@"Failed to report ECommerce to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        NSLog(@"Failed to deserialize AppMetrica ECommerce: %s", eCommerceJson);
    }
}

void amau_reporterReportErrorWithoutIdentifier(char *apiKey, char *messageCString, char *errorJson)
{
    NSString *message = amau_stringFromCString(messageCString);
    AMAPluginErrorDetails *error = amau_deserializeException(errorJson);
    if (error.backtrace.count == 0) {
        [[amau_getCrashReporter(apiKey) pluginExtension] reportErrorWithIdentifier:@"Errors without stacktrace"
                                                                           message:message
                                                                           details:error
                                                                         onFailure:^(NSError *error) {
            NSLog(@"Failed to report error to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        [[amau_getCrashReporter(apiKey) pluginExtension] reportError:error message:message onFailure:^(NSError *error) {
            NSLog(@"Failed to report error to AppMetrica: %@", [error localizedDescription]);
        }];
    }
}

void amau_reporterReportError(char *apiKey, char *identifier, char *message, char *error)
{
    [[amau_getCrashReporter(apiKey) pluginExtension] reportErrorWithIdentifier:amau_stringFromCString(identifier)
                                                                       message:amau_stringFromCString(message)
                                                                       details:amau_deserializeException(error)
                                                                     onFailure:^(NSError *error) {
        NSLog(@"Failed to report error to AppMetrica: %@", [error localizedDescription]);
    }];
}

void amau_reporterReportEvent(char *apiKey, char *message, char *jsonValue)
{
    [amau_getReporter(apiKey) reportEvent:amau_stringFromCString(message)
                               parameters:amau_dictionaryFromCString(jsonValue)
                                onFailure:^(NSError *error) {
        NSLog(@"Failed to report event to AppMetrica: %@", [error localizedDescription]);
    }];
}

void amau_reporterReportRevenue(char *apiKey, char *revenueJson)
{
    AMARevenueInfo *revenueInfo = amau_deserializeRevenueInfo(revenueJson);
    if (revenueInfo != nil) {
        [amau_getReporter(apiKey) reportRevenue:revenueInfo onFailure:^(NSError *error) {
            NSLog(@"Failed to report Revenue to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        NSLog(@"Failed to deserialize AppMetrica Revenue: %s", revenueJson);
    }
}

void amau_reporterReportUnhandledException(char *apiKey, char *exception)
{
    [[amau_getCrashReporter(apiKey) pluginExtension] reportUnhandledException:amau_deserializeException(exception)
                                                                    onFailure:^(NSError *error) {
        NSLog(@"Failed to report unhandled exception to AppMetrica: %@", [error localizedDescription]);
    }];
}

void amau_reporterReportUserProfile(char *apiKey, char *userProfileJson)
{
    AMAUserProfile *userProfile = amau_deserializeUserProfile(userProfileJson);
    if (userProfile != nil) {
        [amau_getReporter(apiKey) reportUserProfile:userProfile onFailure:^(NSError *error) {
            NSLog(@"Failed to report UserProfile to AppMetrica: %@", [error localizedDescription]);
        }];
    } else {
        NSLog(@"Failed to deserialize AppMetrica UserProfile: %s", userProfileJson);
    }
}

void amau_reporterResumeSession(char *apiKey)
{
    [amau_getReporter(apiKey) resumeSession];
}

void amau_reporterSendEventsBuffer(char *apiKey)
{
    [amau_getReporter(apiKey) sendEventsBuffer];
}

void amau_reporterSetDataSendingEnabled(char *apiKey, bool enabled)
{
    [amau_getReporter(apiKey) setDataSendingEnabled:enabled];
}

void amau_reporterSetUserProfileID(char *apiKey, char *userProfileID)
{
    [amau_getReporter(apiKey) setUserProfileID:amau_stringFromCString(userProfileID)];
}
