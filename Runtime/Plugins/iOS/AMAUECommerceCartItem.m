
#import "AMAUECommerceCartItem.h"
#import "AMAUECommercePrice.h"
#import "AMAUECommerceProduct.h"
#import "AMAUECommerceReferrer.h"
#import "AMAUUtils.h"

AMAECommerceCartItem *amau_deserializeECommerceCartItem(NSString *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromJSONString(json);
    if (dict == nil) {
        return nil;
    }

    return [[AMAECommerceCartItem alloc] initWithProduct:amau_deserializeECommerceProduct(dict[@"Product"])
                                                quantity:amau_decimalFromString(dict[@"Quantity"])
                                                 revenue:amau_deserializeECommercePrice(dict[@"Revenue"])
                                                referrer:amau_deserializeECommerceReferrer(dict[@"Referrer"])];
}
