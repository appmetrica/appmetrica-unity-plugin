
#import "AMAUStartupParamsCallbackProxy.h"

void amau_activate(char *configJson);
void amau_activateReporter(char *configJson);
void amau_clearAppEnvironment();
char *amau_getDeviceID();
char *amau_getLibraryVersion();
char *amau_getUuid();
bool amau_isActivated();
void amau_pauseSession();
void amau_putAppEnvironmentValue(char *key, char *value);
void amau_putErrorEnvironmentValue(char *key, char *value);
void amau_reportAdRevenue(char *adRevenueJson);
void amau_reportAppOpen(char *deeplink);
void amau_reportECommerce(char *eCommerceJson);
void amau_reportErrorWithoutIdentifier(char *message, char *error);
void amau_reportError(char *identifier, char *message, char *error);
void amau_reportEvent(char *message, char *paramsJson);
void amay_reportExternalAttribution(char *source, char *value);
void amau_reportRevenue(char *revenueJson);
void amau_reportUnhandledException(char *exception);
void amau_reportUserProfile(char *userProfileJson);
void amau_requestStartupParams(char *identifiersJson, AMAUStartupParamsCallbackDelegate delegate, AMAUAction actionPtr);
void amau_resumeSession();
void amau_sendEventsBuffer();
void amau_setDataSendingEnabled(bool enabled);
void amau_setLocation(char *location);
void amau_setLocationTracking(bool enabled);
void amau_setUserProfileID(char *userProfileID);
void amau_touchReporter(char *apiKey);
