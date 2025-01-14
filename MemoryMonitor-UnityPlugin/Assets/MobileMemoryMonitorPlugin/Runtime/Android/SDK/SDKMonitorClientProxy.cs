namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.SDK
{
    public class SDKMonitorClientProxy
    {
        private readonly SDKMonitorClient sdkMonitorClient;

        internal SDKMonitorClientProxy(SDKMonitorClient sdkMonitorClient) =>
            this.sdkMonitorClient = sdkMonitorClient;

        public virtual int GetSDKVersion() =>
            sdkMonitorClient.GetSDKVersion();

        public virtual FeatureSupportResponse HandleFeatureSupport(int requiredApiLevel)
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
}