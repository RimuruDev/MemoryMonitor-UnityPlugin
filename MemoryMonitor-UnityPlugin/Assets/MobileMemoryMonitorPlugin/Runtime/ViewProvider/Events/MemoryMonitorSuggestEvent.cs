using System;
using UnityEngine.Events;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.ViewProvider.Events
{
    [Serializable]
    public class MemoryMonitorSuggestEvent : UnityEvent<SuggestMemoryCleanupResponse> { }
}