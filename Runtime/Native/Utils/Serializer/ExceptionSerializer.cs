using Io.AppMetrica.Internal;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ExceptionSerializer {
        private const string StacktraceItemRegexp = @"(?<class>[^\s()]+)[.:](?<method>[^\s\.()]+)\s?(?<params>\(.*\))?";
        private const string StacktraceItemWithFileRegexp = StacktraceItemRegexp + @".*(/|\||\\|at |in |\()(?<file>[^:)]+):(?<line>\d+)";

        [NotNull]
        public static string ToJsonString([NotNull] this Exception self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "ExceptionClass", self.GetType().FullName },
                { "Message", self.Message },
                { "StackTrace", GetStackTrace(self) },
                { "VirtualMachineVersion", GetVirtualMachineVersion() },
                { "PluginEnvironment", GetPluginEnvironment(self) },
            });
        }

        [NotNull]
        public static string GetFromLogs([CanBeNull] string condition, [CanBeNull] string stacktraceStr, [NotNull] string source) {
            var exceptionClass = "Exception";
            var message = "";
            if (condition != null) {
                var conditionParts = condition.Split(new[] { ":" }, 2, StringSplitOptions.None);
                exceptionClass = conditionParts.Length == 2 ? conditionParts[0].Trim() : "Exception";
                message = (conditionParts.Length == 2 ? conditionParts[1] : conditionParts[0]).Trim();
            }
            var env = GetCommonPluginEnvironment(source);
            IEnumerable<IDictionary<string, object>> stacktrace = null;
            try {
                stacktrace = GetStackTraceFromString(condition, stacktraceStr);
            } catch (Exception e) {
                env["APPMETRICA_STACKTRACE_ERROR"] = $"Failed to parse stacktrace with error: {e.Message}";
            }
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "ExceptionClass", exceptionClass },
                { "Message", message },
                { "StackTrace", stacktrace },
                { "VirtualMachineVersion", GetVirtualMachineVersion() },
                { "PluginEnvironment", env },
            });
        }

        [NotNull]
        private static string GetVirtualMachineVersion() {
            return Environment.Version.ToString(); // TODO: ???
        }

        [NotNull]
        private static IDictionary<string, string> GetCommonPluginEnvironment([CanBeNull] string source) {
            return new Dictionary<string, string> {
                { "Unity", Application.unityVersion },
                { "Source", source },
            };
        }

        [NotNull]
        private static IDictionary<string, string> GetPluginEnvironment([NotNull] Exception exception) {
            var env = GetCommonPluginEnvironment(exception.Source);
            if (exception.HelpLink != null) {
                env["HelpLink"] = exception.HelpLink;
            }
            foreach (DictionaryEntry entry in exception.Data) {
                env[entry.Key.ToString()] = entry.Value.ToString();
            }
            return env;
        }

        [NotNull]
        private static IEnumerable<IDictionary<string, object>> GetStackTrace([NotNull] Exception exception) {
            var stackTrace = new StackTrace(exception);
            var items = new List<IDictionary<string, object>>();
            for (var idx = 0; idx < stackTrace.FrameCount; idx++) {
                var frame = stackTrace.GetFrame(idx);
                if (frame != null) {
                    items.Add(GetStackTraceItem(frame));
                }
            }
            return items;
        }

        [NotNull]
        private static IDictionary<string, object> GetStackTraceItem([NotNull] StackFrame frame) {
            return new Dictionary<string, object> {
                { "FileName", frame.GetFileName() },
                { "ClassName", frame.GetMethod().DeclaringType?.FullName },
                { "MethodName", frame.GetMethod().Name },
                { "Line", frame.GetFileLineNumber() },
                { "Column", frame.GetFileColumnNumber() },
            };
        }

        [CanBeNull]
        private static IEnumerable<IDictionary<string, object>> GetStackTraceFromString(
            [CanBeNull] string condition,
            [CanBeNull] string value
        ) {
            return value?.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Where(it => {
                    var trimStr = it.Trim();
                    return trimStr.Length != 0 && !trimStr.StartsWith("Rethrow as"); // for inner exception
                })
                // for android crash first item is exception class + message
                .SkipWhile(it => "AndroidJavaException: " + it == condition)
                .Select(GetStackTraceItemFromString);
        }

        // UnityEngine.AndroidJNISafe.CheckException () (at /Users/bokken/buildslave/unity/build/Modules/AndroidJNI/AndroidJNISafe.cs:24)
        // at UnityEngine.AndroidJNISafe.CheckException () [0x0008d] in /Users/bokken/buildslave/unity/build/Modules/AndroidJNI/AndroidJNISafe.cs:24
        // CrashSceneManager:<ReportErrorMethodsGUI>b__10_5() (at /sample/Assets/AppMetricaSample/CrashSceneManager.cs:168)
        // CrashSceneManager.CSharpCrashGUI () (at <5592b27588074c6b8f13ce7f73fdcb59>:0)
        // at CrashSceneManager+<>c.<ReportErrorMethodsGUI>b__10_0 () [0x00000] in <7992989e29fa41c989068b22d7ae468e>:0
        // CrashHelper.crash(CrashHelper.java:8)
        // com.unity3d.player.UnityPlayer.nativeRender(Native Method)
        // com.unity3d.player.UnityPlayer.access$300(Unknown Source:0)
        // UnityEngine.AndroidJavaObject:CallStatic(String, Object[])
        [NotNull]
        private static IDictionary<string, object> GetStackTraceItemFromString([NotNull] string value) {
            var stackTraceLine = value.Trim();
            // stacktrace with file info
            var match = Regex.Match(stackTraceLine, StacktraceItemWithFileRegexp);
            if (!match.Success) {
                // stacktrace without file info
                match = Regex.Match(stackTraceLine, StacktraceItemRegexp);
                if (!match.Success) {
                    throw new FormatException($"Failed to parse stacktrace element '{stackTraceLine}'");
                }
            }

            var lineStr = GetGroupValueOrNull(match, "line");
            return new Dictionary<string, object> {
                { "FileName", GetGroupValueOrNull(match, "file") },
                { "ClassName", GetGroupValueOrNull(match, "class") },
                { "MethodName", GetGroupValueOrNull(match, "method") },
                { "Line", lineStr == null ? (int?)null : int.Parse(lineStr) },
                { "Column", null },
            };
        }

        [CanBeNull]
        private static string GetGroupValueOrNull([NotNull] Match match, [NotNull] string groupName) {
            return match.Groups[groupName].Success ? match.Groups[groupName].Value : null;
        }
    }
}
