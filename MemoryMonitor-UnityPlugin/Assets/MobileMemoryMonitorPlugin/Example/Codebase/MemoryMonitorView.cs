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

                    ramInfoText.text = $"RAM: {availableRAM} / {totalRAM} ({ramPercentage}%)";
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