using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android;
using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime
{
    public class NullSDKMonitorClientProxy : SDKMonitorClientProxy
    {
        public NullSDKMonitorClientProxy() : base(null)
        {
        }

        public sealed override FeatureSupportResponse HandleFeatureSupport(int requiredApiLevel) =>
            FeatureSupportResponse.Unknown;

        public sealed override int GetSDKVersion() =>
            -1;
    }
}