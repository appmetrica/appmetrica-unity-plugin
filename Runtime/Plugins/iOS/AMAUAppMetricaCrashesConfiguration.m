
#import "AMAUAppMetricaCrashesConfiguration.h"
#import "AMAUUtils.h"

AMAAppMetricaCrashesConfiguration *amau_deserializeAppMetricaCrashesConfiguration(char *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromCString(json);
    if (dict == nil) {
        return nil;
    }
    
    AMAAppMetricaCrashesConfiguration *config = [[AMAAppMetricaCrashesConfiguration alloc] init];
    
    if (dict[@"CrashReporting"] != nil) {
        config.autoCrashTracking = [dict[@"CrashReporting"] boolValue];
    }
    
    return config;
}
