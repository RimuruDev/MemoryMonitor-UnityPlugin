// ReSharper disable MemberCanBePrivate.Global

using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android
{
    internal class MMMJavaBridge
    {
        internal const string UNITY_PLAYER = "com.unity3d.player.UnityPlayer";
        internal const string CURRENT_ACTIVITY = "currentActivity";

        internal const string PLUGIN_PACKAGE = "com.abyssmoth.mobilememorymonitor";
        internal const string RAM_MONITOR = PLUGIN_PACKAGE + ".RAMMonitor";
        internal const string SDK_MONITOR = PLUGIN_PACKAGE + ".SDKMonitor";
        internal const string STORAGE_MONITOR = PLUGIN_PACKAGE + ".StorageMonitor";

        public static AndroidJavaObject GetContext()
        {
            using var unityPlayer = new AndroidJavaClass(UNITY_PLAYER);

            return unityPlayer.GetStatic<AndroidJavaObject>(CURRENT_ACTIVITY);
        }

        public static void Call(string methodName, params object[] args)
        {
            using var plugin = new AndroidJavaClass(PLUGIN_PACKAGE);

            plugin.CallStatic(methodName, args);
        }

        public static TResult CallStatic<TResult>(string methodName, params object[] args)
        {
            using var plugin = new AndroidJavaClass(PLUGIN_PACKAGE);

            return plugin.CallStatic<TResult>(methodName, args);
        }
    }
}