namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.SDK
{
    internal class SDKMonitorClient
    {
        // Methods ===
        private const string READ_SDK_VERSION = "ReadSDKVersion";
        private const string HANDLE_FEATURE_SUPPORT = "HandleFeatureSupport";

        public int GetSDKVersion()
        {
            return MMJavaBridge.CallStatic<int>(
                MMJavaBridge.SDK_MONITOR,
                READ_SDK_VERSION);
        }

        public int HandleFeatureSupport(int requiredApiLevel)
        {
            // Response:
            // ERROR_LOW_API = -1
            // FEATURE_SUPPORTED = 0
            
            return MMJavaBridge.CallStatic<int>(
                MMJavaBridge.SDK_MONITOR,
                HANDLE_FEATURE_SUPPORT,
                requiredApiLevel);
        }
    }
}