using TMPro;
using UnityEngine;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Example.Codebase.Test_MemoryMonitorProviderView
{
    public sealed class RAMDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text availableRAMText;
        [SerializeField] private TMP_Text ramPercentageText;
        [SerializeField] private TMP_Text lowRamText;
        [SerializeField] private TMP_Text suggestMemoryText;
        
        public void UpdateAvailableRAM(long availableRAM) => 
            availableRAMText.text = $"Available RAM: {availableRAM / (1024 * 1024)} MB";

        public void UpdateRAMPercentage(float percentage) => 
            ramPercentageText.text = $"RAM Usage: {percentage:F2}%";

        public void IsLowRam() => 
            lowRamText.text = "LOW RAM";

        public void UpdateSuggestMemory(SuggestMemoryCleanupResponse response) =>
            suggestMemoryText.text = response switch
            {
                SuggestMemoryCleanupResponse.LowRAMDetected => "Low RAM detected! Consider closing background apps.",
                SuggestMemoryCleanupResponse.RAMUsageNormal => "RAM usage is within acceptable limits.",
                SuggestMemoryCleanupResponse.Unknown => "Unknown memory status.",
                _ => suggestMemoryText.text
            };
    }
}