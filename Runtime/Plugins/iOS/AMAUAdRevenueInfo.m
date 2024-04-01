
#import "AMAUAdRevenueInfo.h"
#import "AMAUUtils.h"

AMAAdType amau_adTypeFromString(NSString *adType)
{
    if (adType == nil) {
        return AMAAdTypeUnknown;
    }

    if ([adType isEqualToString:@"Native"]) {
        return AMAAdTypeNative;
    }
    if ([adType isEqualToString:@"Banner"]) {
        return AMAAdTypeBanner;
    }
    if ([adType isEqualToString:@"Rewarded"]) {
        return AMAAdTypeRewarded;
    }
    if ([adType isEqualToString:@"Interstitial"]) {
        return AMAAdTypeInterstitial;
    }
    if ([adType isEqualToString:@"Mrec"]) {
        return AMAAdTypeMrec;
    }
    if ([adType isEqualToString:@"Other"]) {
        return AMAAdTypeOther;
    }

    return AMAAdTypeUnknown;
}

AMAAdRevenueInfo *amau_deserializeAdRevenueInfo(char *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromCString(json);
    if (dict == nil) {
        return nil;
    }
    
    NSDecimalNumber *adRevenueValue = amau_decimalFromString(dict[@"AdRevenue"]);
    AMAMutableAdRevenueInfo *adRevenue = [[AMAMutableAdRevenueInfo alloc] initWithAdRevenue:adRevenueValue
                                                                                   currency:dict[@"Currency"]];
    
    if (dict[@"AdNetwork"] != nil) {
        adRevenue.adNetwork = dict[@"AdNetwork"];
    }
    if (dict[@"AdPlacementId"] != nil) {
        adRevenue.adPlacementID = dict[@"AdPlacementId"];
    }
    if (dict[@"AdPlacementName"] != nil) {
        adRevenue.adPlacementName = dict[@"AdPlacementName"];
    }
    if (dict[@"AdType"] != nil) {
        adRevenue.adType = amau_adTypeFromString(dict[@"AdType"]);
    }
    if (dict[@"AdUnitId"] != nil) {
        adRevenue.adUnitID = dict[@"AdUnitId"];
    }
    if (dict[@"AdUnitName"] != nil) {
        adRevenue.adUnitName = dict[@"AdUnitName"];
    }
    if (dict[@"Payload"] != nil && amau_isDictionaryOrNil(dict[@"Payload"])) {
        adRevenue.payload = dict[@"Payload"];
    }
    if (dict[@"Precision"] != nil) {
        adRevenue.precision = dict[@"Precision"];
    }
    
    return adRevenue;
}
