
#import "AMAUECommerceAmount.h"
#import "AMAUUtils.h"

AMAECommerceAmount *amau_deserializeECommerceAmount(NSString *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromJSONString(json);
    if (dict == nil) {
        return nil;
    }

    return [[AMAECommerceAmount alloc] initWithUnit:dict[@"Unit"]
                                              value:amau_decimalFromString(dict[@"Amount"])];
}
