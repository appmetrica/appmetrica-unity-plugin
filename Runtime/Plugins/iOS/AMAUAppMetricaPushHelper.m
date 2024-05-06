
#include "AMAUAppMetricaPushHelper.h"
#include "AMAUAppMetricaProxy.h"

@implementation AMAUAppMetricaPushHelper

+ (void)activateAppMetricaByUnityConfig:(char *)config
{
    amau_activate(config);
}

@end
