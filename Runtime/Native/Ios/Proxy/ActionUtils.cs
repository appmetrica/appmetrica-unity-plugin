using JetBrains.Annotations;
using System;
using System.Runtime.InteropServices;

namespace Io.AppMetrica.Native.Ios.Proxy {
    internal static class ActionUtils {
        public static IntPtr ToIntPtr(object obj) {
            return obj == null ? IntPtr.Zero : GCHandle.ToIntPtr(GCHandle.Alloc(obj));
        }

        [CanBeNull]
        public static T FromIntPtr<T>(IntPtr actionPtr) where T : class {
            if (IntPtr.Zero.Equals(actionPtr)) {
                return null;
            }

            var gcHandle = GCHandle.FromIntPtr(actionPtr);
            return gcHandle.Target as T;
        }
    }
}
