using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM;
using static AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM.SuggestMemoryCleanupResponse;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Dummy
{
    public class NullRAMMonitorProxy : RAMMonitorProxy
    {
        public NullRAMMonitorProxy() : base(null) { }

        public sealed override long GetAvailableRAM() => 0;

        public sealed override long GetTotalRAM() => 0;

        public sealed override float GetAvailableRAMPercentage() => 0f;

        public sealed override bool IsLowRAM() => false;

        public sealed override SuggestMemoryCleanupResponse SuggestMemoryCleanup() => Unknown;
    }
}