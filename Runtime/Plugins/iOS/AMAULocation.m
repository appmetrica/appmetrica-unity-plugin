
#import "AMAULocation.h"
#import "AMAUUtils.h"

CLLocation *amau_deserializeLocation(NSString *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromJSONString(json);
    if (dict == nil) {
        return nil;
    }
    
    return [[CLLocation alloc] initWithLatitude:[dict[@"Latitude"] doubleValue]
                                      longitude:[dict[@"Longitude"] doubleValue]];
}
