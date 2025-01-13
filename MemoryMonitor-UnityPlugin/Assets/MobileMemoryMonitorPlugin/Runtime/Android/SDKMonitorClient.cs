namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android
{
    public enum FeatureSupportResponse : byte
    {
        // NOTE: Неизвестное число.
        Unknown = 0,
        LowApiLevel = 1,
        FeatureSupport = 2,
    }
    
    internal class SDKMonitorClientProxy
    {
        private readonly SDKMonitorClient sdkMonitorClient;

        internal SDKMonitorClientProxy(SDKMonitorClient sdkMonitorClient)
        {
            this.sdkMonitorClient = sdkMonitorClient;
        }

        public string GetSDKVersion()
        {
            return sdkMonitorClient.GetSDKVersion();
        }

        public FeatureSupportResponse HandleFeatureSupport(int requiredApiLevel)
        {
            const int ERROR_LOW_API = -1;
            const int FEATURE_SUPPORTED = 0;

            var info = sdkMonitorClient.HandleFeatureSupport(requiredApiLevel);

            return info switch
            {
                FEATURE_SUPPORTED => FeatureSupportResponse.FeatureSupport,
                ERROR_LOW_API => FeatureSupportResponse.LowApiLevel,
                _ => FeatureSupportResponse.Unknown
            };
        }
    }

    internal class SDKMonitorClient
    {
        // Methods ===
        private const string READ_SDK_VERSION = "ReadSDKVersion";
        private const string HANDLE_FEATURE_SUPPORT = "HandleFeatureSupport";

        public string GetSDKVersion()
        {
            return MMMJavaBridge.CallStatic<string>(READ_SDK_VERSION);
        }

        public int HandleFeatureSupport(int requiredApiLevel)
        {
            // Response:
            // ERROR_LOW_API = -1
            // FEATURE_SUPPORTED = 0
            return MMMJavaBridge.CallStatic<int>(HANDLE_FEATURE_SUPPORT, requiredApiLevel);
        }
    }
}