
#import "AMAUECommerceEvent.h"
#import "AMAUECommerceAmount.h"
#import "AMAUECommerceCartItem.h"
#import "AMAUECommerceOrder.h"
#import "AMAUECommercePrice.h"
#import "AMAUECommerceProduct.h"
#import "AMAUECommerceReferrer.h"
#import "AMAUECommerceScreen.h"
#import "AMAUUtils.h"

AMAECommerce *amau_deserializeECommerce(char *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromCString(json);
    if (dict == nil) {
        return nil;
    }
    
    NSString *type = dict[@"Type"];
    if ([type isEqualToString:@"AddCartItemECommerceEvent"]) {
        return [AMAECommerce addCartItemEventWithItem:amau_deserializeECommerceCartItem(dict[@"CartItem"])];
    }
    if ([type isEqualToString:@"BeginCheckoutECommerceEvent"]) {
        return [AMAECommerce beginCheckoutEventWithOrder:amau_deserializeECommerceOrder(dict[@"Order"])];
    }
    if ([type isEqualToString:@"PurchaseECommerceEvent"]) {
        return [AMAECommerce purchaseEventWithOrder:amau_deserializeECommerceOrder(dict[@"Order"])];
    }
    if ([type isEqualToString:@"RemoveCartItemECommerceEvent"]) {
        return [AMAECommerce removeCartItemEventWithItem:amau_deserializeECommerceCartItem(dict[@"CartItem"])];
    }
    if ([type isEqualToString:@"ShowProductCardECommerceEvent"]) {
        return [AMAECommerce showProductCardEventWithProduct:amau_deserializeECommerceProduct(dict[@"Product"])
                                                      screen:amau_deserializeECommerceScreen(dict[@"Screen"])];
    }
    if ([type isEqualToString:@"ShowProductDetailsECommerceEvent"]) {
        return [AMAECommerce showProductDetailsEventWithProduct:amau_deserializeECommerceProduct(dict[@"Product"])
                                                       referrer:amau_deserializeECommerceReferrer(dict[@"Referrer"])];
    }
    if ([type isEqualToString:@"ShowScreenECommerceEvent"]) {
        return [AMAECommerce showScreenEventWithScreen:amau_deserializeECommerceScreen(dict[@"Screen"])];
    }

    return nil;
}
