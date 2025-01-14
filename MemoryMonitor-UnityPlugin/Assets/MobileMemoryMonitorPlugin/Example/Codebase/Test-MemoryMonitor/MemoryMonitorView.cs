using TMPro;
using UnityEngine;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Example.Codebase.Test_MemoryMonitor
{
    public class MemoryMonitorView : MonoBehaviour
    {
        [SerializeField] private TMP_Text ramInfoText;
        private MemoryMonitor memoryMonitorManager;

        private void Awake() => 
            memoryMonitorManager= MemoryMonitor.Instance;

        private void Update()
        {
            try
            {
                if (ramInfoText != null)
                {
                    const int testRequiredApiLevel = 16;
                    
                    var availableRAM = memoryMonitorManager.GetAvailableRAM();
                    var totalRAM = memoryMonitorManager.GetTotalRAM();
                    var ramPercentage = memoryMonitorManager.GetAvailableRAMPercentage();
                    var isLowRam = memoryMonitorManager.IsLowRAM();
                    var suggest = memoryMonitorManager.SuggestMemoryCleanup();
                    var v = memoryMonitorManager.GetSDKVersion();
                    var handle = memoryMonitorManager.HandleFeatureSupport(testRequiredApiLevel);

                    ramInfoText.text = $"RAM: {availableRAM} / {totalRAM} ({ramPercentage}%)\nIsLowRAM: {isLowRam}\nSuggest: {suggest.ToString()}\nVersion: {v}\nhandle-16: {handle}";
                }
                else
                {
                    ramInfoText.text = "ramInfoText NULL...";
                }
            }
            catch (System.Exception ex)
            {
                ramInfoText.text = ex.Message;
            }
        }
    }
}