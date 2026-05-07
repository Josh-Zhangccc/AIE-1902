using UnityEngine;

public static class LogControl
{
    // 日志总开关：true=开启普通日志，false=关闭普通日志
    public static bool enableLog = false;

    // 替代 Debug.Log
    public static void Log(object message)
   
    {
        if (enableLog)
        {
            Debug.Log(message);
        }
    }

    // 替代 Debug.LogWarning（不受开关影响，永远显示）
    public static void LogWarning(object message)
    {
        Debug.LogWarning(message);
    }

    // 替代 Debug.LogError（不受开关影响，永远显示）
    public static void LogError(object message)
    {
        Debug.LogError(message);
    }
}