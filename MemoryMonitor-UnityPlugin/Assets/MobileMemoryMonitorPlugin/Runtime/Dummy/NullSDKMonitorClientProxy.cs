using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.SDK;
using static AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.SDK.FeatureSupportResponse;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Dummy
{
    public class NullSDKMonitorClientProxy : SDKMonitorClientProxy
    {
        public NullSDKMonitorClientProxy() : base(null) { }

        public sealed override FeatureSupportResponse HandleFeatureSupport(int requiredApiLevel) => Unknown;

        public sealed override int GetSDKVersion() => -1;
    }
}