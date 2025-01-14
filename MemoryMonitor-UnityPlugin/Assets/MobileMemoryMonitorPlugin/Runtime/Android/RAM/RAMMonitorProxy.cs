namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM
{
    public class RAMMonitorProxy
    {
        private readonly RAMMonitorClient ramMonitorClient;

        internal RAMMonitorProxy(RAMMonitorClient ramMonitorClient)
        {
            this.ramMonitorClient = ramMonitorClient;
        }

        public virtual long GetAvailableRAM()
        {
            return ramMonitorClient.GetAvailableRAM(MMJavaBridge.GetContext());
        }

        public virtual long GetTotalRAM()
        {
            return ramMonitorClient.GetTotalRAM(MMJavaBridge.GetContext());
        }

        public virtual float GetAvailableRAMPercentage()
        {
            return ramMonitorClient.GetAvailableRAMPercentage(MMJavaBridge.GetContext());
        }

        public virtual bool IsLowRAM()
        {
            return ramMonitorClient.IsLowRAM(MMJavaBridge.GetContext());
        }

        public virtual SuggestMemoryCleanupResponse SuggestMemoryCleanup()
        {
            var info = ramMonitorClient.SuggestMemoryCleanup(MMJavaBridge.GetContext());

            return info switch
            {
                "Low RAM detected! Consider closing background apps." => SuggestMemoryCleanupResponse.LowRAMDetected,
                "RAM usage is within acceptable limits." => SuggestMemoryCleanupResponse.RAMUsageNormal,
                _ => SuggestMemoryCleanupResponse.Unknown
            };
        }
    }
}