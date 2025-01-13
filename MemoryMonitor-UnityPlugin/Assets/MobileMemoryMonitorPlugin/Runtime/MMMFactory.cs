#if UNITY_ANDROID && !UNITY_EDITOR
#define UNITY_ANDROID_RUNTIME
#endif

using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime
{
    public class MMMFactory
    {
        public RAMMonitorProxy CreateRAMMonitorProxy()
        {
#if UNITY_ANDROID_RUNTIME
            var client = new RAMMonitorClient();
            return new RAMMonitorProxy(client);
#else
            return new NullRAMMonitorProxy();
#endif
        }

        public SDKMonitorClientProxy CreateSDKMonitorProxy()
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