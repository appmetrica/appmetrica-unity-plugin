
#include "AMAUException.h"
#include "AMAUUtils.h"

AMAStackTraceElement *amau_deserializeStackTraceItem(NSDictionary *dict)
{
    AMAStackTraceElement *item = [[AMAStackTraceElement alloc] init];
    if (dict[@"FileName"] != nil) {
        item.fileName = dict[@"FileName"];
    }
    if (dict[@"ClassName"] != nil) {
        item.className = dict[@"ClassName"];
    }
    if (dict[@"MethodName"] != nil) {
        item.methodName = dict[@"MethodName"];
    }
    if (dict[@"Line"] != nil) {
        item.line = dict[@"Line"];
    }
    if (dict[@"Column"] != nil) {
        item.column = dict[@"Column"];
    }
    return item;
}

NSArray<AMAStackTraceElement *> *amau_deserializeStackTrace(NSArray *frames)
{
    NSMutableArray<AMAStackTraceElement *> *items = [[NSMutableArray alloc] init];
    for (NSDictionary *frameDict in frames) {
        [items addObject:amau_deserializeStackTraceItem(frameDict)];
    }
    return items;
}

AMAPluginErrorDetails *amau_deserializeException(char *json)
{
    if (json == nil) {
        return nil;
    }
    
    NSDictionary *dict = amau_dictionaryFromCString(json);
    if (dict == nil) {
        return nil;
    }
    
    AMAPluginErrorDetails *error = [[AMAPluginErrorDetails alloc] init];
    error.platform = kAMAPlatformUnity;
    if (dict[@"ExceptionClass"] != nil) {
        error.exceptionClass = dict[@"ExceptionClass"];
    }
    if (dict[@"Message"] != nil) {
        error.message = dict[@"Message"];
    }
    if (dict[@"StackTrace"] != nil) {
        error.backtrace = amau_deserializeStackTrace(dict[@"StackTrace"]);
    }
    if (dict[@"VirtualMachineVersion"] != nil) {
        error.virtualMachineVersion = dict[@"VirtualMachineVersion"];
    }
    if (dict[@"PluginEnvironment"] != nil) {
        error.pluginEnvironment = dict[@"PluginEnvironment"];
    }
    return error;
}
