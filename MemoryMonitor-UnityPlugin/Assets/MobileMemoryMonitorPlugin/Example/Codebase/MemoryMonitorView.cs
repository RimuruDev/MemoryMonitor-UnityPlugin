using System;
using System.Linq;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime;
using TMPro;
using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Example.Codebase
{
    public class MemoryMonitorView : MonoBehaviour
    {
        [SerializeField] private TMP_Text ramInfoText;
        private MemoryMonitor memoryMonitorManager;

        private void Awake()
        {
            ramInfoText.text = "Awake";
            memoryMonitorManager= MemoryMonitor.Instance;
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

                    ramInfoText.text = $"RAM: {availableRAM} / {totalRAM} ({ramPercentage}%)\nIsLowRAM: {isLowRam}\nSuggest: {suggest.ToString()}\nVersion: {v}\nhandle-16: {handle}";
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