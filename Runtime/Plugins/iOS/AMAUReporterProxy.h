
void amau_reporterClearAppEnvironment(char *apiKey);
void amau_reporterPauseSession(char *apiKey);
void amau_reporterPutAppEnvironmentValue(char *apiKey, char *key, char *value);
void amau_reporterReportAdRevenue(char *apiKey, char *adRevenue);
void amau_reporterReportECommerce(char *apiKey, char *ecommerce);
void amau_reporterReportErrorWithoutIdentifier(char *apiKey, char *message, char *error);
void amau_reporterReportError(char *apiKey, char *identifier, char *message, char *error);
void amau_reporterReportEvent(char *apiKey, char *message, char *jsonValue);
void amau_reporterReportRevenue(char *apiKey, char *revenue);
void amau_reporterReportUnhandledException(char *apiKey, char *exception);
void amau_reporterReportUserProfile(char *apiKey, char *profile);
void amau_reporterResumeSession(char *apiKey);
void amau_reporterSendEventsBuffer(char *apiKey);
void amau_reporterSetDataSendingEnabled(char *apiKey, bool enabled);
void amau_reporterSetUserProfileID(char *apiKey, char *userProfileID);
