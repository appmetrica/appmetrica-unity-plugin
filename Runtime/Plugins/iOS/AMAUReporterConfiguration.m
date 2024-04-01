
#import "AMAUReporterConfiguration.h"
#import "AMAUUtils.h"

AMAReporterConfiguration *amau_deserializeReporterConfiguration(char *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromCString(json);
    if (dict == nil) {
        return nil;
    }
    
    AMAMutableReporterConfiguration *config = [[AMAMutableReporterConfiguration alloc] initWithAPIKey:dict[@"ApiKey"]];
    
    if (dict[@"DataSendingEnabled"] != nil) {
        config.dataSendingEnabled = [dict[@"DataSendingEnabled"] boolValue];
    }
    if (dict[@"DispatchPeriodSeconds"] != nil) {
        config.dispatchPeriod = [dict[@"DispatchPeriodSeconds"] unsignedIntegerValue];
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
    if (dict[@"SessionTimeout"] != nil) {
        config.sessionTimeout = [dict[@"SessionTimeout"] unsignedIntegerValue];
    }
    if (dict[@"UserProfileID"] != nil) {
        config.userProfileID = dict[@"UserProfileID"];
    }
    
    return config;
}
