// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

using UnityEngine;

namespace AbyssMoth.MobileMemoryMonitorPlugin.Runtime.Android
{
    internal class MMJavaBridge
    {
        internal const string UNITY_PLAYER = "com.unity3d.player.UnityPlayer";
        internal const string CURRENT_ACTIVITY = "currentActivity";

        internal const string PLUGIN_PACKAGE = "com.abyssmoth.mobilememorymonitor";
        internal const string RAM_MONITOR = PLUGIN_PACKAGE + ".RAMMonitor";
        internal const string SDK_MONITOR = PLUGIN_PACKAGE + ".SDKMonitor";
        internal const string STORAGE_MONITOR = PLUGIN_PACKAGE + ".StorageMonitor";

        /// <summary>
        /// Получает текущий Android Activity (контекст приложения).
        /// </summary>
        /// <returns></returns>
        public static AndroidJavaObject GetContext()
        {
            using var unityPlayer = new AndroidJavaClass(UNITY_PLAYER);
            return unityPlayer.GetStatic<AndroidJavaObject>(CURRENT_ACTIVITY);
        }

        /// <summary>
        /// Вызывает статический метод Java-класса.
        /// </summary>
        /// <param name="className">Имя Java-класса.</param>
        /// <param name="methodName">Имя статического метода.</param>
        /// <param name="args">Аргументы метода.</param>
        public static void CallStatic(string className, string methodName, params object[] args)
        {
            using var plugin = new AndroidJavaClass(className);
            plugin.CallStatic(methodName, args);
        }

        /// <summary>
        /// Вызывает статический метод Java-класса и возвращает результат.
        /// </summary>
        /// <typeparam name="TResult">Тип возвращаемого значения.</typeparam>
        /// <param name="className">Имя Java-класса.</param>
        /// <param name="methodName">Имя статического метода.</param>
        /// <param name="args">Аргументы метода.</param>
        public static TResult CallStatic<TResult>(string className, string methodName, params object[] args)
        {
            using var plugin = new AndroidJavaClass(className);
            return plugin.CallStatic<TResult>(methodName, args);
        }

        /// <summary>
        /// Вызывает нестатический метод Java-объекта.
        /// </summary>
        /// <param name="javaObject">Java-объект.</param>
        /// <param name="methodName">Имя метода.</param>
        /// <param name="args">Аргументы метода.</param>
        public static void Call(AndroidJavaObject javaObject, string methodName, params object[] args)
        {
            javaObject.Call(methodName, args);
        }

        /// <summary>
        /// Вызывает нестатический метод Java-объекта и возвращает результат.
        /// </summary>
        /// <typeparam name="TResult">Тип возвращаемого значения.</typeparam>
        /// <param name="javaObject">Java-объект.</param>
        /// <param name="methodName">Имя метода.</param>
        /// <param name="args">Аргументы метода.</param>
        public static TResult Call<TResult>(AndroidJavaObject javaObject, string methodName, params object[] args)
        {
            return javaObject.Call<TResult>(methodName, args);
        }
    }
}