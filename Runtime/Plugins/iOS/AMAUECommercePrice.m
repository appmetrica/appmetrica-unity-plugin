
#import "AMAUECommerceAmount.h"
#import "AMAUECommercePrice.h"
#import "AMAUUtils.h"

AMAECommercePrice *amau_deserializeECommercePrice(NSString *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromJSONString(json);
    if (dict == nil) {
        return nil;
    }

    NSArray<NSString *> *jsonInternalComponents = [dict mutableArrayValueForKey:@"InternalComponents"];
    NSMutableArray<AMAECommerceAmount *> *internalComponents = [NSMutableArray arrayWithCapacity:[jsonInternalComponents count]];
    for (NSString *jsonInternalComponent in jsonInternalComponents) {
        [internalComponents addObject:amau_deserializeECommerceAmount(jsonInternalComponent)];
    }
    
    return [[AMAECommercePrice alloc] initWithFiat:amau_deserializeECommerceAmount(dict[@"Fiat"])
                                internalComponents:internalComponents];
}
