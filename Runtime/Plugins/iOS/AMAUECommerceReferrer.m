
#import "AMAUECommerceReferrer.h"
#import "AMAUECommerceScreen.h"
#import "AMAUUtils.h"

AMAECommerceReferrer *amau_deserializeECommerceReferrer(NSString *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromJSONString(json);
    if (dict == nil) {
        return nil;
    }

    return [[AMAECommerceReferrer alloc] initWithType:dict[@"Type"]
                                           identifier:dict[@"Identifier"]
                                               screen:amau_deserializeECommerceScreen(dict[@"Screen"])];
}
