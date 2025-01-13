using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android;
using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime
{
    public class MemoryMonitor : MonoBehaviour
    {
        private RAMMonitorProxy ramMonitorProxy;
        private SDKMonitorClientProxy sdkMonitorProxy;

        private void Awake()
        {
            var factory = new MMMFactory();
            ramMonitorProxy = factory.CreateRAMMonitorProxy();
            sdkMonitorProxy = factory.CreateSDKMonitorProxy();
        }

        /// <summary>
        /// Метод для получения доступной оперативной памяти.
        /// </summary>
        /// <returns></returns>
        public long GetAvailableRAM()
        {
            return ramMonitorProxy.GetAvailableRAM();
        }

        /// <summary>
        /// Метод для получения общей оперативной памяти.
        /// </summary>
        /// <returns></returns>
        public long GetTotalRAM()
        {
            return ramMonitorProxy.GetTotalRAM();
        }

        /// <summary>
        /// Метод для получения процентного значения доступной памяти.
        /// </summary>
        /// <returns></returns>
        public float GetAvailableRAMPercentage()
        {
            return ramMonitorProxy.GetAvailableRAMPercentage();
        }

        /// <summary>
        /// Метод для проверки, низкая ли память.
        /// </summary>
        /// <returns></returns>
        public bool IsLowRAM()
        {
            return ramMonitorProxy.IsLowRAM();
        }

        /// <summary>
        /// Метод для рекомендации очистки памяти.
        /// </summary>
        /// <returns></returns>
        public SuggestMemoryCleanupResponse SuggestMemoryCleanup()
        {
            return ramMonitorProxy.SuggestMemoryCleanup();
        }

        /// <summary>
        /// Метод для проверки уровня поддержки SDK.
        /// </summary>
        /// <param name="requiredApiLevel"></param>
        /// <returns></returns>
        public FeatureSupportResponse HandleFeatureSupport(int requiredApiLevel)
        {
            return sdkMonitorProxy.HandleFeatureSupport(requiredApiLevel);
        }

        /// <summary>
        /// Метод для получения версии SDK.
        /// </summary>
        /// <returns></returns>
        public string GetSDKVersion()
        {
            return sdkMonitorProxy.GetSDKVersion();
        }
    }
}