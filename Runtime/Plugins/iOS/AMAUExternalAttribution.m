
#include "AMAUExternalAttribution.h"
#include "AMAUUtils.h"

AMAAttributionSource amau_getExternalAttributionSource(char *source)
{
    NSString *sourceStr = amau_stringFromCString(source);
    if (sourceStr == nil) return nil;


    if ([sourceStr isEqualToString:@"AppsFlyer"]) {
        return kAMAAttributionSourceAppsflyer;
    }
    if ([sourceStr isEqualToString:@"Adjust"]) {
        return kAMAAttributionSourceAdjust;
    }
    if ([sourceStr isEqualToString:@"Kochava"]) {
        return kAMAAttributionSourceKochava;
    }
    if ([sourceStr isEqualToString:@"Tenjin"]) {
        return kAMAAttributionSourceTenjin;
    }
    if ([sourceStr isEqualToString:@"Airbridge"]) {
        return kAMAAttributionSourceAirbridge;
    }
    if ([sourceStr isEqualToString:@"Singular"]) {
        return kAMAAttributionSourceSingular;
    }

    return nil;
}
