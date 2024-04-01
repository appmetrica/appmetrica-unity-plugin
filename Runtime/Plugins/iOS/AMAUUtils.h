
typedef const void *AMAUAction;

NSString *amau_stringFromCString(const char *string);
char *amau_cStringFromString(NSString *string);
bool amau_isDictionaryOrNil(NSDictionary *dictionary);
NSDictionary *amau_dictionaryFromJSONString(NSString *json);
NSDictionary *amau_dictionaryFromJSONStringOrNil(NSString *json);
NSDictionary *amau_dictionaryFromCString(const char *json);
const char *amau_cStringJsonFromDictionary(NSDictionary *dict);
bool amau_isArrayOrNil(NSArray *array);
NSArray *amau_arrayFromJSONString(NSString *json);
NSArray *amau_arrayFromCString(const char *json);
NSDecimalNumber *amau_decimalFromString(NSString *str);
NSDecimalNumber *amau_decimalFromCString(char *str);
