namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.SDK
{
    internal class SDKMonitorClient
    {
        private const string READ_SDK_VERSION = "ReadSDKVersion";
        private const string HANDLE_FEATURE_SUPPORT = "HandleFeatureSupport";

        public int GetSDKVersion() =>
            MMJavaBridge.CallStatic<int>(
                MMJavaBridge.SDK_MONITOR,
                READ_SDK_VERSION);

        public int HandleFeatureSupport(int requiredApiLevel) =>
            MMJavaBridge.CallStatic<int>(
                MMJavaBridge.SDK_MONITOR,
                HANDLE_FEATURE_SUPPORT,
                requiredApiLevel);
    }
}