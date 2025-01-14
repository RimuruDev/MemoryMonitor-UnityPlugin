using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM
{
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
            return MMJavaBridge.CallStatic<long>(
                MMJavaBridge.RAM_MONITOR,
                GET_AVAILABLE_RAM,
                context);
        }

        public long GetTotalRAM(AndroidJavaObject context)
        {
            return MMJavaBridge.CallStatic<long>(
                MMJavaBridge.RAM_MONITOR,
                GET_TOTAL_RAM,
                context);
        }

        public float GetAvailableRAMPercentage(AndroidJavaObject context)
        {
            // Response:
            // 0-100
            // Or -> if total ram 0 -> return 0

            return MMJavaBridge.CallStatic<float>(
                MMJavaBridge.RAM_MONITOR,
                GET_AVAILABLE_RAM_PERCENTAGE,
                context);
        }

        public bool IsLowRAM(AndroidJavaObject context)
        {
            return MMJavaBridge.CallStatic<bool>(
                MMJavaBridge.RAM_MONITOR,
                IS_LOW_RAM,
                context);
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

            return MMJavaBridge.CallStatic<string>(
                MMJavaBridge.RAM_MONITOR,
                SUGGEST_MEMORY_CLEANUP,
                context);
        }
    }
}