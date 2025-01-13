using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android
{
    public enum SuggestMemoryCleanupResponse : byte
    {
        // NOTE: Неизвестная строка.
        Unknown = 0,
        RAMUsageNormal = 1,
        LowRAMDetected = 2
    }
    
    public class StorageMonitorProxy
    {
        private readonly RAMMonitorClient ramMonitorClient;

        internal StorageMonitorProxy(RAMMonitorClient ramMonitorClient)
        {
            this.ramMonitorClient = ramMonitorClient;
        }

        public long GetAvailableRAM()
        {
            return ramMonitorClient.GetAvailableRAM(MMMJavaBridge.GetContext());
        }

        public long GetTotalRAM()
        {
            return ramMonitorClient.GetTotalRAM(MMMJavaBridge.GetContext());
        }

        public float GetAvailableRAMPercentage()
        {
            return ramMonitorClient.GetAvailableRAMPercentage(MMMJavaBridge.GetContext());
        }

        public bool IsLowRAM()
        {
            return ramMonitorClient.IsLowRAM(MMMJavaBridge.GetContext());
        }

        public SuggestMemoryCleanupResponse SuggestMemoryCleanup()
        {
            var info = ramMonitorClient.SuggestMemoryCleanup(MMMJavaBridge.GetContext());

            return info switch
            {
                "Low RAM detected! Consider closing background apps." => SuggestMemoryCleanupResponse.LowRAMDetected,
                "RAM usage is within acceptable limits." => SuggestMemoryCleanupResponse.RAMUsageNormal,
                _ => SuggestMemoryCleanupResponse.Unknown
            };
        }
    }

    internal class RAMMonitorClient
    {
        // Methods ===
        private const string GET_AVAILABLE_RAM = "GetAvailableRAM";
        private const string GET_TOTAL_RAM = "GetTotalRAM";
        private const string GET_AVAILABLE_RAM_PERCENTAGE = "GetAvailableRAMPercentage";
        private const string IS_LOW_RAM = "IsLowRAM";
        private const string SUGGEST_MEMORY_CLEANUP = "SuggestMemoryCleanup";

        public long GetAvailableRAM(AndroidJavaObject context)
        {
            return context.Call<long>(GET_AVAILABLE_RAM);
        }

        public long GetTotalRAM(AndroidJavaObject context)
        {
            return context.Call<long>(GET_TOTAL_RAM);
        }

        public float GetAvailableRAMPercentage(AndroidJavaObject context)
        {
            // Response:
            // 0-100
            // Or -> if total ram 0 -> return 0

            return context.Call<float>(GET_AVAILABLE_RAM_PERCENTAGE);
        }

        public bool IsLowRAM(AndroidJavaObject context)
        {
            return context.Call<bool>(IS_LOW_RAM);
        }

        public string SuggestMemoryCleanup(AndroidJavaObject context)
        {
            // Response:
            //  true: "Low RAM detected! Consider closing background apps."
            //  false: "RAM usage is within acceptable limits."
            //
            // JAVA:
            // if (IsLowRAM(context))
            //     return "Low RAM detected! Consider closing background apps.";
            //
            // return "RAM usage is within acceptable limits.";

            return context.Call<string>(SUGGEST_MEMORY_CLEANUP);
        }
    }
}