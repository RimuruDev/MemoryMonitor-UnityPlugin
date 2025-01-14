using System;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android;
using UnityEngine;
using UnityEngine.Events;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime
{
    [Serializable]
    public class MemoryMonitorEvent : UnityEvent { }

    [Serializable]
    public class MemoryMonitorLongEvent : UnityEvent<long> { }

    [Serializable]
    public class MemoryMonitorFloatEvent : UnityEvent<float> { }

    [Serializable]
    public class MemoryMonitorSuggestEvent : UnityEvent<SuggestMemoryCleanupResponse> { }

    public enum MemoryMonitorUpdateRate
    {
        None = 0,
        UpdateEvery1Second = 1,
        UpdateEvery2Seconds = 2,
        UpdateEvery5Seconds = 5,
        UpdateEvery10Seconds = 10,
    }

    public class MemoryMonitorProviderView : MonoBehaviour
    {
        [Header("Настройки обновления")]
        public MemoryMonitorUpdateRate updateRate = MemoryMonitorUpdateRate.UpdateEvery1Second;

        [Header("События")]
        public MemoryMonitorEvent OnLowMemoryEvent;
        public MemoryMonitorLongEvent OnAvailableRAMUpdated;
        public MemoryMonitorFloatEvent OnAvailableRAMPercentageUpdated;
        public MemoryMonitorSuggestEvent OnSuggestMemoryCleanup;

        private MemoryMonitor memoryMonitor;
        private float updateInterval;
        private float elapsedTime;

        private void Awake()
        {
            memoryMonitor = MemoryMonitor.Instance;
            UpdateIntervalFromRate();
        }
        
        private void UpdateIntervalFromRate()
        {
            updateInterval = (int)updateRate;
        }

        private void Update()
        {
            if (updateRate == MemoryMonitorUpdateRate.None || !HasSubscribers())
                return;

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= updateInterval)
            {
                elapsedTime = 0f;
                FetchMemoryData();
            }
        }

        private bool HasSubscribers()
        {
            return OnLowMemoryEvent.GetPersistentEventCount() > 0 ||
                   OnAvailableRAMUpdated.GetPersistentEventCount() > 0 ||
                   OnAvailableRAMPercentageUpdated.GetPersistentEventCount() > 0 ||
                   OnSuggestMemoryCleanup.GetPersistentEventCount() > 0;
        }

        private void FetchMemoryData()
        {
            if (memoryMonitor.IsLowRAM())
            {
                OnLowMemoryEvent?.Invoke();
            }

            var availableRAM = memoryMonitor.GetAvailableRAM();
            OnAvailableRAMUpdated?.Invoke(availableRAM);

            var ramPercentage = memoryMonitor.GetAvailableRAMPercentage();
            OnAvailableRAMPercentageUpdated?.Invoke(ramPercentage);
            
            var suggestMemoryCleanup = memoryMonitor.SuggestMemoryCleanup();
            OnSuggestMemoryCleanup?.Invoke(suggestMemoryCleanup);
        }
    }
}