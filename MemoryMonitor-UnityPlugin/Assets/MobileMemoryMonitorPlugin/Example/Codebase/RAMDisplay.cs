using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM;
using TMPro;
using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Example.Codebase
{
    public class RAMDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text availableRAMText;
        [SerializeField] private TMP_Text ramPercentageText;
        [SerializeField] private TMP_Text lowRamText;
        [SerializeField] private TMP_Text suggestMemoryText;
        
        public void UpdateAvailableRAM(long availableRAM)
        {
            availableRAMText.text = $"Available RAM: {availableRAM / (1024 * 1024)} MB";
        }
        
        public void UpdateRAMPercentage(float percentage)
        {
            ramPercentageText.text = $"RAM Usage: {percentage:F2}%";
        }

        public void IsLowRam()
        {
            lowRamText.text = "LOW RAM";
        }
        
        public void UpdateSuggestMemory(SuggestMemoryCleanupResponse response)
        {
            switch (response)
            {
                case SuggestMemoryCleanupResponse.LowRAMDetected:
                    suggestMemoryText.text = "Low RAM detected! Consider closing background apps.";
                    break;
                case SuggestMemoryCleanupResponse.RAMUsageNormal:
                    suggestMemoryText.text = "RAM usage is within acceptable limits.";
                    break;
                case SuggestMemoryCleanupResponse.Unknown:
                    suggestMemoryText.text = "Unknown memory status.";
                    break;
            }
        }
    }
}