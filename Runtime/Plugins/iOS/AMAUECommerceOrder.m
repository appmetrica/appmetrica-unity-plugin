
#import "AMAUECommerceCartItem.h"
#import "AMAUECommerceOrder.h"
#import "AMAUUtils.h"

AMAECommerceOrder *amau_deserializeECommerceOrder(NSString *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromJSONString(json);
    if (dict == nil) {
        return nil;
    }

    NSArray<NSString *> *jsonCartItems = [dict mutableArrayValueForKey:@"CartItems"];
    NSMutableArray<AMAECommerceCartItem *> *cartItems = [NSMutableArray arrayWithCapacity:[jsonCartItems count]];
    for (NSString *jsonCartItem in jsonCartItems) {
        [cartItems addObject:amau_deserializeECommerceCartItem(jsonCartItem)];
    }
    
    return [[AMAECommerceOrder alloc] initWithIdentifier:dict[@"Identifier"]
                                               cartItems:cartItems
                                                 payload:dict[@"Payload"]];
}
