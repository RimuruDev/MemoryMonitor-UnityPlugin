using System;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime;
using TMPro;
using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Example.Codebase
{
    public class MemoryMonitorView : MonoBehaviour
    {
        public MemoryMonitor memoryMonitorManager;
        [SerializeField] private TMP_Text ramInfoText;

        private void Awake()
        {
            ramInfoText.text = "Awake";
        }

        private void Start()
        {
            ramInfoText.text = "Start";
        }

        private void Update()
        {
            try
            {
                if (ramInfoText != null)
                {
                    var availableRAM = memoryMonitorManager.GetAvailableRAM();
                    var totalRAM = memoryMonitorManager.GetTotalRAM();
                    var ramPercentage = memoryMonitorManager.GetAvailableRAMPercentage();
                    var isLowRam = memoryMonitorManager.IsLowRAM();
                    var suggest = memoryMonitorManager.SuggestMemoryCleanup();
                    var v = memoryMonitorManager.GetSDKVersion();
                    var handle = memoryMonitorManager.HandleFeatureSupport(16);

                    ramInfoText.text = $"RAM: {availableRAM} / {totalRAM} ({ramPercentage}%)\n IsLowRAM: {isLowRam}\n Suggest: {suggest.ToString()}\nVersion: {v}\nhandle-16: {handle}";
                }
                else
                {
                    ramInfoText.text = "NULL";
                }
            }
            catch (System.Exception ex)
            {
                ramInfoText.text = ex.Message;
            }
        }
    }
}