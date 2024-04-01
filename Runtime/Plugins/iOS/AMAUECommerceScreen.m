
#import "AMAUECommerceScreen.h"
#import "AMAUUtils.h"

AMAECommerceScreen *amau_deserializeECommerceScreen(NSString *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromJSONString(json);
    if (dict == nil) {
        return nil;
    }

    return [[AMAECommerceScreen alloc] initWithName:dict[@"Name"]
                                 categoryComponents:dict[@"CategoriesPath"]
                                        searchQuery:dict[@"SearchQuery"]
                                            payload:dict[@"Payload"]];
}
