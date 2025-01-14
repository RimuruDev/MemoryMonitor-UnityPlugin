using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM
{
    internal class RAMMonitorClient
    {
        private const string IS_LOW_RAM = "IsLowRAM";
        private const string GET_TOTAL_RAM = "GetTotalRAM";
        private const string GET_AVAILABLE_RAM = "GetAvailableRAM";
        private const string SUGGEST_MEMORY_CLEANUP = "SuggestMemoryCleanup";
        private const string GET_AVAILABLE_RAM_PERCENTAGE = "GetAvailableRAMPercentage";

        public long GetAvailableRAM(AndroidJavaObject context) =>
            CallRAMMonitorAPI<long>(context, GET_AVAILABLE_RAM);

        public long GetTotalRAM(AndroidJavaObject context) =>
            CallRAMMonitorAPI<long>(context, GET_TOTAL_RAM);

        public float GetAvailableRAMPercentage(AndroidJavaObject context) =>
            CallRAMMonitorAPI<float>(context, GET_AVAILABLE_RAM_PERCENTAGE);

        public bool IsLowRAM(AndroidJavaObject context) =>
            CallRAMMonitorAPI<bool>(context, IS_LOW_RAM);

        public string SuggestMemoryCleanup(AndroidJavaObject context) =>
            CallRAMMonitorAPI<string>(context, SUGGEST_MEMORY_CLEANUP);

        private T CallRAMMonitorAPI<T>(AndroidJavaObject context, string method) =>
            MMJavaBridge.CallStatic<T>(
                MMJavaBridge.RAM_MONITOR,
                method,
                context);
    }
}