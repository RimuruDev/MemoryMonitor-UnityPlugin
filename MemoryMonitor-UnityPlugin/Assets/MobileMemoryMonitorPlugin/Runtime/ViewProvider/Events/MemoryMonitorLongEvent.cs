using System;
using UnityEngine.Events;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.ViewProvider.Events
{
    [Serializable]
    public class MemoryMonitorLongEvent : UnityEvent<long> { }
}