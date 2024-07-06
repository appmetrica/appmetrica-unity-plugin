
#import "AMAUAppMetricaConfiguration.h"
#import "AMAULocation.h"
#import "AMAUUtils.h"

AMAAppMetricaPreloadInfo *amau_deserializeAppMetricaPreloadInfo(NSString *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromJSONString(json);
    if (dict == nil) {
        return nil;
    }
    
    AMAAppMetricaPreloadInfo *info = [[AMAAppMetricaPreloadInfo alloc] initWithTrackingIdentifier:dict[@"TrackingId"]];
    if (dict[@"AdditionalParams"] != nil) {
        NSDictionary *params = dict[@"AdditionalParams"];
        for (NSString *key in params) {
            [info setAdditionalInfo:params[key] forKey:key];
        }
    }
    
    return info;
}


AMAAppMetricaConfiguration *amau_deserializeAppMetricaConfiguration(char *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromCString(json);
    if (dict == nil) {
        return nil;
    }
    
    AMAAppMetricaConfiguration *config = [[AMAAppMetricaConfiguration alloc] initWithAPIKey:dict[@"ApiKey"]];
    
    if (dict[@"AppBuildNumber"] != nil) {
        config.appBuildNumber = [dict[@"AppBuildNumber"] stringValue];
    }
    if (dict[@"AppEnvironment"] != nil) {
        config.appEnvironment = dict[@"AppEnvironment"];
    }
    if (dict[@"AppOpenTrackingEnabled"] != nil) {
        config.appOpenTrackingEnabled = [dict[@"AppOpenTrackingEnabled"] boolValue];
    }
    if (dict[@"AppVersion"] != nil) {
        config.appVersion = dict[@"AppVersion"];
    }
    if (dict[@"DataSendingEnabled"] != nil) {
        config.dataSendingEnabled = [dict[@"DataSendingEnabled"] boolValue];
    }
    if (dict[@"DispatchPeriodSeconds"] != nil) {
        config.dispatchPeriod = [dict[@"DispatchPeriodSeconds"] unsignedIntegerValue];
    }
    if (dict[@"FirstActivationAsUpdate"] != nil) {
        config.handleFirstActivationAsUpdate = [dict[@"FirstActivationAsUpdate"] boolValue];
    }
    if (dict[@"Location"] != nil) {
        config.customLocation = amau_deserializeLocation(dict[@"Location"]);
    }
    if (dict[@"LocationTracking"] != nil) {
        config.locationTracking = [dict[@"LocationTracking"] boolValue];
    }
    if (dict[@"Logs"] != nil) {
        config.logsEnabled = [dict[@"Logs"] boolValue];
    }
    if (dict[@"MaxReportsCount"] != nil) {
        config.maxReportsCount = [dict[@"MaxReportsCount"] unsignedIntegerValue];
    }
    if (dict[@"MaxReportsInDatabaseCount"] != nil) {
        config.maxReportsInDatabaseCount = [dict[@"MaxReportsInDatabaseCount"] unsignedIntegerValue];
    }
    if (dict[@"PreloadInfo"] != nil) {
        config.preloadInfo = amau_deserializeAppMetricaPreloadInfo(dict[@"PreloadInfo"]);
    }
    if (dict[@"RevenueAutoTrackingEnabled"] != nil) {
        config.revenueAutoTrackingEnabled = [dict[@"RevenueAutoTrackingEnabled"] boolValue];
    }
    if (dict[@"SessionTimeout"] != nil) {
        config.sessionTimeout = [dict[@"SessionTimeout"] unsignedIntegerValue];
    }
    if (dict[@"SessionsAutoTrackingEnabled"] != nil) {
        config.sessionsAutoTracking = [dict[@"SessionsAutoTrackingEnabled"] boolValue];
    }
    if (dict[@"UserProfileID"] != nil) {
        config.userProfileID = dict[@"UserProfileID"];
    }
    
    if (config.sessionsAutoTracking) {
        config.handleActivationAsSessionStart = YES;
    }
    
    return config;
}
