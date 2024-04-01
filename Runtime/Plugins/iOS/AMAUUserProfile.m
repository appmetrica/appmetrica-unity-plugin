
#import "AMAUUserProfile.h"
#import "AMAUUtils.h"

AMAUserProfileUpdate *amau_birthDateAttributeFromDictionary(NSDictionary *dictionary)
{
    NSString *type = dictionary[@"Type"];
    if ([type isEqualToString:@"BirthDateAgeUserProfileUpdate"]) {
        return [[AMAProfileAttribute birthDate] withAge:[dictionary[@"Age"] unsignedIntegerValue]];
    }
    if ([type isEqualToString:@"BirthDateYearUserProfileUpdate"]) {
        return [[AMAProfileAttribute birthDate] withYear:[dictionary[@"Year"] unsignedIntegerValue]];
    }
    if ([type isEqualToString:@"BirthDateMonthUserProfileUpdate"]) {
        return [[AMAProfileAttribute birthDate] withYear:[dictionary[@"Year"] unsignedIntegerValue]
                                                   month:[dictionary[@"Month"] unsignedIntegerValue]];
    }
    if ([type isEqualToString:@"BirthDateDaysUserProfileUpdate"]) {
        return [[AMAProfileAttribute birthDate] withYear:[dictionary[@"Year"] unsignedIntegerValue]
                                                   month:[dictionary[@"Month"] unsignedIntegerValue]
                                                     day:[dictionary[@"DayOfMonth"] unsignedIntegerValue]];
    }
    if ([type isEqualToString:@"BirthDateResetUserProfileUpdate"]) {
        return [[AMAProfileAttribute birthDate] withValueReset];
    }
    return nil;
}

AMAUserProfileUpdate *amau_customBoolAttributeUpdateFromDictionary(NSDictionary *dictionary)
{
    NSString *type = dictionary[@"Type"];
    if ([type isEqualToString:@"BooleanValueUserProfileUpdate"]) {
        NSString *key = dictionary[@"Key"];
        bool value = [dictionary[@"Value"] boolValue];
        if ([dictionary[@"IfUndefined"] boolValue]) {
            return [[AMAProfileAttribute customBool:key] withValueIfUndefined:value];
        }
        return [[AMAProfileAttribute customBool:key] withValue:value];
    }
    if ([type isEqualToString:@"BooleanResetUserProfileUpdate"]) {
        NSString *key = dictionary[@"Key"];
        return [[AMAProfileAttribute customBool:key] withValueReset];
    }
    return nil;
}

AMAUserProfileUpdate *amau_customCounterAttributeUpdateFromDictionary(NSDictionary *dictionary)
{
    NSString *type = dictionary[@"Type"];
    if ([type isEqualToString:@"CounterDeltaUserProfileUpdate"]) {
        NSString *key = dictionary[@"Key"];
        double value = [dictionary[@"Delta"] doubleValue];
        return [[AMAProfileAttribute customCounter:key] withDelta:value];
    }
    return nil;
}

AMAGenderType amau_genderTypeFromString(NSString *genderStr)
{
    if (genderStr == nil) {
        return AMAGenderTypeOther;
    }

    if ([genderStr isEqualToString:@"Female"]) {
        return AMAGenderTypeFemale;
    }
    if ([genderStr isEqualToString:@"Male"]) {
        return AMAGenderTypeMale;
    }

    return AMAGenderTypeOther;
}

AMAUserProfileUpdate *amau_genderAttributeFromDictionary(NSDictionary *dictionary)
{
    NSString *type = dictionary[@"Type"];
    if ([type isEqualToString:@"GenderValueUserProfileUpdate"]) {
        AMAGenderType value = amau_genderTypeFromString(dictionary[@"Value"]);
        return [[AMAProfileAttribute gender] withValue:value];
    }
    if ([type isEqualToString:@"GenderResetUserProfileUpdate"]) {
        return [[AMAProfileAttribute gender] withValueReset];
    }
    return nil;
}

AMAUserProfileUpdate *amau_nameAttributeFromDictionary(NSDictionary *dictionary)
{
    NSString *type = dictionary[@"Type"];
    if ([type isEqualToString:@"NameValueUserProfileUpdate"]) {
        NSString *value = dictionary[@"Value"];
        return [[AMAProfileAttribute name] withValue:value];
    }
    if ([type isEqualToString:@"NameResetUserProfileUpdate"]) {
        return [[AMAProfileAttribute name] withValueReset];
    }
    return nil;
}

AMAUserProfileUpdate *amau_notificationEnabledAttributeFromDictionary(NSDictionary *dictionary)
{
    NSString *type = dictionary[@"Type"];
    if ([type isEqualToString:@"NotificationsEnabledValueUserProfileUpdate"]) {
        bool value = [dictionary[@"Value"] boolValue];
        return [[AMAProfileAttribute notificationsEnabled] withValue:value];
    }
    if ([type isEqualToString:@"NotificationsEnabledResetUserProfileUpdate"]) {
        return [[AMAProfileAttribute notificationsEnabled] withValueReset];
    }
    return nil;
}

AMAUserProfileUpdate *amau_customNumberAttributeUpdateFromDictionary(NSDictionary *dictionary)
{
    NSString *type = dictionary[@"Type"];
    if ([type isEqualToString:@"NumberValueUserProfileUpdate"]) {
        NSString *key = dictionary[@"Key"];
        double value = [dictionary[@"Value"] doubleValue];
        if ([dictionary[@"IfUndefined"] boolValue]) {
            return [[AMAProfileAttribute customNumber:key] withValueIfUndefined:value];
        }
        return [[AMAProfileAttribute customNumber:key] withValue:value];
    }
    if ([type isEqualToString:@"NumberResetUserProfileUpdate"]) {
        NSString *key = dictionary[@"Key"];
        return [[AMAProfileAttribute customNumber:key] withValueReset];
    }
    return nil;
}

AMAUserProfileUpdate *amau_customStringAttributeUpdateFromDictionary(NSDictionary *dictionary)
{
    NSString *type = dictionary[@"Type"];
    if ([type isEqualToString:@"StringValueUserProfileUpdate"]) {
        NSString *key = dictionary[@"Key"];
        NSString *value = dictionary[@"Value"];
        if ([dictionary[@"IfUndefined"] boolValue]) {
            return [[AMAProfileAttribute customString:key] withValueIfUndefined:value];
        }
        return [[AMAProfileAttribute customString:key] withValue:value];
    }
    if ([type isEqualToString:@"StringResetUserProfileUpdate"]) {
        NSString *key = dictionary[@"Key"];
        return [[AMAProfileAttribute customString:key] withValueReset];
    }
    return nil;
}

AMAUserProfileUpdate *amau_userProfileUpdateFromDictionary(NSDictionary *dictionary)
{
    return amau_birthDateAttributeFromDictionary(dictionary)
        ?: amau_customBoolAttributeUpdateFromDictionary(dictionary)
        ?: amau_customCounterAttributeUpdateFromDictionary(dictionary)
        ?: amau_genderAttributeFromDictionary(dictionary)
        ?: amau_nameAttributeFromDictionary(dictionary)
        ?: amau_notificationEnabledAttributeFromDictionary(dictionary)
        ?: amau_customNumberAttributeUpdateFromDictionary(dictionary)
        ?: amau_customStringAttributeUpdateFromDictionary(dictionary);
}

AMAUserProfile *amau_deserializeUserProfile(char *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSArray *list = amau_arrayFromCString(json);
    if (list == nil) {
        return nil;
    }
    
    AMAMutableUserProfile *userProfile = [[AMAMutableUserProfile alloc] init];
    
    for (NSDictionary *userProfileUpdateDict in list) {
        AMAUserProfileUpdate *update = amau_userProfileUpdateFromDictionary(userProfileUpdateDict);
        if (update != nil) {
            [userProfile apply:update];
        }
    }
    
    return userProfile;
}
