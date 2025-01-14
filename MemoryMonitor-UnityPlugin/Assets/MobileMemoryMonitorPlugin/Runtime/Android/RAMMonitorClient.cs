using System;
using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android
{
    public enum SuggestMemoryCleanupResponse : byte
    {
        /// <summary>
        /// NOTE: Неизвестная строка.
        /// </summary>
        Unknown = 0,
        RAMUsageNormal = 1,
        LowRAMDetected = 2
    }

    public class RAMMonitorProxy
    {
        private readonly RAMMonitorClient ramMonitorClient;

        internal RAMMonitorProxy(RAMMonitorClient ramMonitorClient)
        {
            this.ramMonitorClient = ramMonitorClient;
        }

        public virtual long GetAvailableRAM()
        {
            return ramMonitorClient.GetAvailableRAM(MMMJavaBridge.GetContext());
        }

        public virtual long GetTotalRAM()
        {
            return ramMonitorClient.GetTotalRAM(MMMJavaBridge.GetContext());
        }

        public virtual float GetAvailableRAMPercentage()
        {
            return ramMonitorClient.GetAvailableRAMPercentage(MMMJavaBridge.GetContext());
        }

        public virtual bool IsLowRAM()
        {
            return ramMonitorClient.IsLowRAM(MMMJavaBridge.GetContext());
        }

        public virtual SuggestMemoryCleanupResponse SuggestMemoryCleanup()
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
            return MMMJavaBridge.CallStatic<long>(
                MMMJavaBridge.RAM_MONITOR,
                GET_AVAILABLE_RAM,
                context);
        }

        public long GetTotalRAM(AndroidJavaObject context)
        {
            return MMMJavaBridge.CallStatic<long>(
                MMMJavaBridge.RAM_MONITOR,
                GET_TOTAL_RAM,
                context);
        }

        public float GetAvailableRAMPercentage(AndroidJavaObject context)
        {
            // Response:
            // 0-100
            // Or -> if total ram 0 -> return 0

            return MMMJavaBridge.CallStatic<float>(
                MMMJavaBridge.RAM_MONITOR,
                GET_AVAILABLE_RAM_PERCENTAGE,
                context);
        }

        public bool IsLowRAM(AndroidJavaObject context)
        {
            return MMMJavaBridge.CallStatic<bool>(
                MMMJavaBridge.RAM_MONITOR,
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

            return MMMJavaBridge.CallStatic<string>(
                MMMJavaBridge.RAM_MONITOR,
                SUGGEST_MEMORY_CLEANUP,
                context);
        }
    }
}