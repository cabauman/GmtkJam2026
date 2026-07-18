using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

#nullable enable

namespace GmtkJam2026.DevToolbox
{
    public static class ULog
    {
        [ThreadStatic]
        private static StringBuilder _sb = new(256);

        [HideInCallstack]
        [Conditional("ULOG_LEVEL_TRACE")]
        public static void Trace(
            string message,
            UnityEngine.Object? context = null,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0)
        {
            UnityEngine.Debug.Log(FormatMessage(message, callerFilePath, callerMemberName, callerLineNumber), context);
        }

        [HideInCallstack]
        [Conditional("ULOG_LEVEL_TRACE")]
        [Conditional("ULOG_LEVEL_DEBUG")]
        public static void Debug(
            string message,
            UnityEngine.Object? context = null,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0)
        {
            UnityEngine.Debug.Log(FormatMessage(message, callerFilePath, callerMemberName, callerLineNumber), context);
        }

        [HideInCallstack]
        [Conditional("ULOG_LEVEL_TRACE")]
        [Conditional("ULOG_LEVEL_DEBUG")]
        [Conditional("ULOG_LEVEL_INFO")]
        public static void Info(
            string message,
            UnityEngine.Object? context = null,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0)
        {
            UnityEngine.Debug.Log(FormatMessage(message, callerFilePath, callerMemberName, callerLineNumber), context);
        }

        [HideInCallstack]
        [Conditional("ULOG_LEVEL_TRACE")]
        [Conditional("ULOG_LEVEL_DEBUG")]
        [Conditional("ULOG_LEVEL_INFO")]
        [Conditional("ULOG_LEVEL_WARN")]
        public static void Warn(
            string message,
            UnityEngine.Object? context = null,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0)
        {
            UnityEngine.Debug.LogWarning(FormatMessage(message, callerFilePath, callerMemberName, callerLineNumber), context);
        }

        [HideInCallstack]
        [Conditional("ULOG_LEVEL_TRACE")]
        [Conditional("ULOG_LEVEL_DEBUG")]
        [Conditional("ULOG_LEVEL_INFO")]
        [Conditional("ULOG_LEVEL_WARN")]
        [Conditional("ULOG_LEVEL_ERROR")]
        public static void Error(
            string message,
            UnityEngine.Object? context = null,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0)
        {
            UnityEngine.Debug.LogError(FormatMessage(message, callerFilePath, callerMemberName, callerLineNumber), context);
        }

        private static string FormatMessage(string message, string callerFilePath, string callerMemberName, int callerLineNumber)
        {
            _sb.Clear();
            ReadOnlySpan<char> fileName = System.IO.Path.GetFileName(callerFilePath.AsSpan());
            return _sb
                .Append('[')
                .Append(fileName)
                .Append(':')
                .Append(callerMemberName)
                .Append(':')
                .Append(callerLineNumber)
                .Append(']')
                .Append(' ')
                .Append(message)
                .ToString();
        }
    }
}
