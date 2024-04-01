
#import "AMAURevenueInfo.h"
#import "AMAUUtils.h"

AMARevenueInfo *amau_deserializeRevenueInfo(char *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromCString(json);
    if (dict == nil) {
        return nil;
    }

    NSDecimalNumber *priceDecimal = [[NSDecimalNumber decimalNumberWithString:[dict[@"PriceMicros"] stringValue]]
                                    decimalNumberByDividingBy:[[NSDecimalNumber alloc] initWithInt:1e6]];
    AMAMutableRevenueInfo *revenue = [[AMAMutableRevenueInfo alloc] initWithPriceDecimal:priceDecimal
                                                                                currency:dict[@"Currency"]];
    if (dict[@"Quantity"] != nil) {
        [revenue setQuantity:[dict[@"Quantity"] unsignedIntegerValue]];
    }
    [revenue setProductID:dict[@"ProductID"]];
    [revenue setPayload:amau_dictionaryFromJSONStringOrNil(dict[@"Payload"])];
    [revenue setTransactionID:dict[@"TransactionID"]];
    if (dict[@"ReceiptData"] != nil) {
        [revenue setReceiptData:[[NSData alloc] initWithBase64EncodedString:dict[@"ReceiptData"] options:0]];
    }
    return [revenue copy];
}
