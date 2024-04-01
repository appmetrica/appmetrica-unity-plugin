
#include "AMAUUtils.h"

NSString *amau_stringFromCString(const char *string) {
    return string == nil ? nil : [NSString stringWithUTF8String:string];
}
 
char *amau_cStringFromString(NSString *string) {
    if (string == nil) return nil;
    const char *cString = [string UTF8String];

    char *res = (char *)malloc(strlen(cString) + 1);
    strcpy(res, cString);
    return res;
}

bool amau_isDictionaryOrNil(NSDictionary *dictionary) {
    return dictionary == nil || [dictionary isKindOfClass:[NSDictionary class]];
}

NSDictionary *amau_dictionaryFromJSONString(NSString *json) {
    NSError *error = nil;
    NSDictionary *dict = json == nil ? nil : [NSJSONSerialization JSONObjectWithData:[json dataUsingEncoding:NSUTF8StringEncoding]
                                                                             options:0
                                                                               error:&error];
    if (error == nil && amau_isDictionaryOrNil(dict)) {
        return dict;
    } else {
        [NSException raise:@"Failed parse json" format:@"%@ for json %@", error, json];
    }
}

NSDictionary *amau_dictionaryFromJSONStringOrNil(NSString *json) {
    NSError *error = nil;
    NSDictionary *dict = json == nil ? nil : [NSJSONSerialization JSONObjectWithData:[json dataUsingEncoding:NSUTF8StringEncoding]
                                                                             options:0
                                                                               error:&error];
    if (error == nil && amau_isDictionaryOrNil(dict)) {
        return dict;
    } else {
        return nil;
    }
}

NSDictionary *amau_dictionaryFromCString(const char *json) {
    return amau_dictionaryFromJSONString(amau_stringFromCString(json));
}

const char *amau_cStringJsonFromDictionary(NSDictionary *dict) {
    NSError *error = nil;
    NSData *json = [NSJSONSerialization dataWithJSONObject:dict options:0 error:&error];
    if (error == nil) {
        return amau_cStringFromString([[NSString alloc] initWithData:json encoding:NSUTF8StringEncoding]);
    } else {
        [NSException raise:@"Failed create json" format:@"%@ for json %@", error, [dict description]];
    }
}

bool amau_isArrayOrNil(NSArray *array) {
    return array == nil || [array isKindOfClass:[NSArray class]];
}

NSArray *amau_arrayFromJSONString(NSString *json) {
    NSError *error = nil;
    NSArray *array = json == nil ? nil : [NSJSONSerialization JSONObjectWithData:[json dataUsingEncoding:NSUTF8StringEncoding]
                                                                         options:0
                                                                           error:&error];
    if (error == nil && amau_isArrayOrNil(array)) {
        return array;
    } else {
        [NSException raise:@"Failed parse json" format:@"%@ for json %@", error, json];
    }
}

NSArray *amau_arrayFromCString(const char *json) {
    return amau_arrayFromJSONString(amau_stringFromCString(json));
}

NSDecimalNumber *amau_decimalFromString(NSString *str)
{
    NSDictionary *locale = [NSDictionary dictionaryWithObject:@"." forKey:NSLocaleDecimalSeparator];
    return [NSDecimalNumber decimalNumberWithString:str locale:locale];
}

NSDecimalNumber *amau_decimalFromCString(char *str)
{
    return amau_decimalFromString(amau_stringFromCString(str));
}
