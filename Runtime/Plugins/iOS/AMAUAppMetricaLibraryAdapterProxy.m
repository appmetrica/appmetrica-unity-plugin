
#import "AMAUAppMetricaLibraryAdapterProxy.h"
#import "AMAUUtils.h"

@import AppMetricaLibraryAdapter;

void amau_subscribeForAutoCollectedData(char *apiKey)
{
    [[AMAAnalyticsLibraryAdapter sharedInstance] subscribeForAutocollectedDataForApiKey:amau_stringFromCString(apiKey)];
}
