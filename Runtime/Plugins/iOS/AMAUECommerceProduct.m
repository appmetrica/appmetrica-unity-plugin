
#import "AMAUECommercePrice.h"
#import "AMAUECommerceProduct.h"
#import "AMAUUtils.h"

AMAECommerceProduct *amau_deserializeECommerceProduct(NSString *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromJSONString(json);
    if (dict == nil) {
        return nil;
    }

    return [[AMAECommerceProduct alloc] initWithSKU:dict[@"Sku"]
                                               name:dict[@"Name"]
                                 categoryComponents:dict[@"CategoriesPath"]
                                            payload:dict[@"Payload"]
                                        actualPrice:amau_deserializeECommercePrice(dict[@"ActualPrice"])
                                      originalPrice:amau_deserializeECommercePrice(dict[@"OriginalPrice"])
                                         promoCodes:dict[@"Promocodes"]];
}
