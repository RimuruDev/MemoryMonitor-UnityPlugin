using UnityEngine;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Factory;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.RAM;
using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android.SDK;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime
{
    /// <summary>
    /// Главный класс для работы с мониторингом памяти и SDK. Предоставляет Singleton API для доступа к функционалу.
    /// </summary>
    public class MemoryMonitor
    {
        private static MemoryMonitor instance;

        private readonly RAMMonitorProxy ramMonitorProxy;
        private readonly SDKMonitorClientProxy sdkMonitorProxy;

        /// <summary>
        /// Приватный конструктор для инициализации фабрики и прокси.
        /// </summary>
        private MemoryMonitor()
        {
            ramMonitorProxy = MemoryMonitorFactory.CreateRAMMonitorProxy();
            sdkMonitorProxy = MemoryMonitorFactory.CreateSDKMonitorProxy();
        }

        /// <summary>
        /// Статическое свойство для доступа к Singleton-экземпляру MemoryMonitor.
        /// </summary>
        public static MemoryMonitor Instance =>
            instance ??= new MemoryMonitor();

        /// <summary>
        /// Сбрасывает статические данные при перезагрузке домена.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics() =>
            instance = null;

        /// <summary>
        /// Получает доступную оперативную память в байтах.
        /// </summary>
        public long GetAvailableRAM() =>
            ramMonitorProxy.GetAvailableRAM();

        /// <summary>
        /// Получает общую оперативную память в байтах.
        /// </summary>
        public long GetTotalRAM() =>
            ramMonitorProxy.GetTotalRAM();

        /// <summary>
        /// Получает процент доступной оперативной памяти.
        /// </summary>
        public float GetAvailableRAMPercentage() =>
            ramMonitorProxy.GetAvailableRAMPercentage();

        /// <summary>
        /// Проверяет, находится ли устройство в состоянии низкого объёма оперативной памяти.
        /// </summary>
        public bool IsLowRAM() =>
            ramMonitorProxy.IsLowRAM();

        /// <summary>
        /// Предоставляет рекомендации по очистке памяти.
        /// </summary>
        public SuggestMemoryCleanupResponse SuggestMemoryCleanup() =>
            ramMonitorProxy.SuggestMemoryCleanup();

        /// <summary>
        /// Проверяет поддержку определённого уровня API устройства.
        /// </summary>
        public FeatureSupportResponse HandleFeatureSupport(int requiredApiLevel) =>
            sdkMonitorProxy.HandleFeatureSupport(requiredApiLevel);

        /// <summary>
        /// Получает версию SDK устройства.
        /// </summary>
        public int GetSDKVersion() =>
            sdkMonitorProxy.GetSDKVersion();

        #region :D Методы для удобной работы с памятью ;3

        /// <summary>
        /// Получает доступную оперативную память в мегабайтах.
        /// </summary>
        /// <returns>Доступная память в МБ.</returns>
        public float GetAvailableRAMInMB()
        {
            var availableRAM = GetAvailableRAM();
            
            if (availableRAM <= 0)
                return 0;
            
            return availableRAM / (1024f * 1024f);
        }

        /// <summary>
        /// Получает доступную оперативную память в гигабайтах.
        /// </summary>
        /// <returns>Доступная память в ГБ.</returns>
        public float GetAvailableRAMInGB()
        {
            var availableRAM = GetAvailableRAM();
            
            if (availableRAM <= 0)
                return 0;
            
            return availableRAM / 1024f;
        }

        /// <summary>
        /// Получает доступную оперативную память в строковом формате с единицами.
        /// </summary>
        /// <returns>Доступная память как строка с единицами.</returns>
        public string GetAvailableRAMAsString()
        {
            return $"{GetAvailableRAMInGB():F2} GB";
        }

        /// <summary>
        /// Получает процент доступной оперативной памяти как целое число.
        /// </summary>
        /// <returns>Процент доступной памяти как целое число.</returns>
        public int GetAvailableRAMPercentageAsInt()
        {
            return Mathf.FloorToInt(GetAvailableRAMPercentage());
        }

        #endregion
    }
}