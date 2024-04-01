
#import "AMAUStartupParamsCallbackProxy.h"

static NSString *const kAMAUStartupParamsUUIDRealKey = @"appmetrica_uuid";
static NSString *const kAMAUStartupParamsDeviceIDRealKey = @"appmetrica_device_id";
static NSString *const kAMAUStartupParamsDeviceIDHashRealKey = @"appmetrica_device_id_hash";

NSArray *amau_fixStartupParamsKeys(NSArray *keys)
{
    NSDictionary *keyMap = @{
        kAMAUStartupParamsUUIDRealKey: kAMAUUIDKey,
        kAMAUStartupParamsDeviceIDRealKey: kAMADeviceIDKey,
        kAMAUStartupParamsDeviceIDHashRealKey: kAMADeviceIDHashKey,
    };
    NSMutableArray *actualKeys = [[NSMutableArray alloc] init];
    for (NSString *key in keys) {
        [actualKeys addObject:keyMap[key] ?: key];
    }
    return [actualKeys copy];
}

const char *amau_serializeStartupParamsResult(NSDictionary<AMAStartupKey,id> *identifiers) 
{
    if (identifiers == nil) return nil;
    
    NSDictionary *keyMap = @{
        kAMAUUIDKey: kAMAUStartupParamsUUIDRealKey,
        kAMADeviceIDKey: kAMAUStartupParamsDeviceIDRealKey,
        kAMADeviceIDHashKey: kAMAUStartupParamsDeviceIDHashRealKey,
    };
    NSMutableDictionary *parameters = [[NSMutableDictionary alloc] init];
    for (NSString *key in identifiers) {
        parameters[keyMap[key] ?: key] = @{
            @"id": identifiers[key],
            @"status": @"OK",
        };
    }
    return amau_cStringJsonFromDictionary(@{
        @"parameters": parameters,
    });
}

const char *amau_serializeStartupParamsError(NSError *error)
{
    if (error == nil) return nil;
    
    NSString *value = @"UNKNOWN";
    if ([error.domain isEqualToString:NSURLErrorDomain]) {
        value = @"NETWORK";
    }
    return amau_cStringJsonFromDictionary(@{
        @"value": value,
    });
}
