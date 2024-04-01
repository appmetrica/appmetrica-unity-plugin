using Io.AppMetrica.Internal;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Io.AppMetrica.Native.Utils.Serializer {
    internal static class ExceptionSerializer {
        [NotNull]
        public static string ToJsonString([NotNull] this Exception self) {
            return JSONEncoder.Encode(new Dictionary<string, object> {
                { "ExceptionClass", self.GetType().FullName },
                { "Message", self.Message },
                { "StackTrace", GetStackTrace(self) },
                { "VirtualMachineVersion", Environment.Version.ToString() }, // TODO: ???
                { "PluginEnvironment", GetPluginEnvironment(self) },
            });
        }

        [CanBeNull]
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

        private static IDictionary<string, string> GetPluginEnvironment([NotNull] Exception exception) {
            var env = new Dictionary<string, string> {
                { "Unity", Application.unityVersion },
                { "Source", exception.Source },
            };
            if (exception.HelpLink != null) {
                env["HelpLink"] = exception.HelpLink;
            }
            foreach (DictionaryEntry entry in exception.Data) {
                env[entry.Key.ToString()] = entry.Value.ToString();
            }
            return env;
        }
    }
}
