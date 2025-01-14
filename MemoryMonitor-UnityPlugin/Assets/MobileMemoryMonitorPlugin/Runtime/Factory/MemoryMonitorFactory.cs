#if UNITY_ANDROID && !UNITY_EDITOR
#define UNITY_ANDROID_RUNTIME
#endif

using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.SDK;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Factory.Dummy;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Factory
{
    public static class MemoryMonitorFactory
    {
        public static RAMMonitorProxy CreateRAMMonitorProxy()
        {
#if UNITY_ANDROID_RUNTIME
            var client = new RAMMonitorClient();
            return new RAMMonitorProxy(client);
#else
            return new NullRAMMonitorProxy();
#endif
        }

        public static SDKMonitorClientProxy CreateSDKMonitorProxy()
        {
#if UNITY_ANDROID_RUNTIME
            var client = new SDKMonitorClient();
            return new SDKMonitorClientProxy(client);
#else
            return new NullSDKMonitorClientProxy();
#endif
        }
    }
}