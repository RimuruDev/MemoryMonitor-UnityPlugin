using AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android;
using UnityEngine;

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
    }
}