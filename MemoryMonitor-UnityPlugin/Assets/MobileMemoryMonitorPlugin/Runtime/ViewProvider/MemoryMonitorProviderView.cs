using UnityEngine;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.ViewProvider.Events;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.ViewProvider
{
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