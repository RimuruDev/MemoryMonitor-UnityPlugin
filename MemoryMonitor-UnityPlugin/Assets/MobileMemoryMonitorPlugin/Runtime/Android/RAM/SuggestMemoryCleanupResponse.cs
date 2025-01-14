namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM
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
}