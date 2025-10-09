
#import "AMAUAppMetricaLibraryAdapterProxy.h"
#import "AMAUUtils.h"

@import AppMetricaLibraryAdapter;

void amau_subscribeForAutoCollectedData(char *apiKey)
{
    [[AMAAppMetricaLibraryAdapter sharedInstance] subscribeForAutocollectedDataForApiKey:amau_stringFromCString(apiKey)];
}
