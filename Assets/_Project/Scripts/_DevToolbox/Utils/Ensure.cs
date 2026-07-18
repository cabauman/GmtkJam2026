using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using UnityEngine;

#nullable enable

namespace GmtkJam2026.DevToolbox
{
    public static class Ensure
    {
        public static T ArgumentNotNull<T>([NotNull] T? obj, [CallerArgumentExpression("obj")] string paramName = "")
        {
            return obj == null
                ? throw new ArgumentNullException(paramName)
                : obj;
        }

        public static string ArgumentNotNullOrEmpty([NotNull] string? str, [CallerArgumentExpression("str")] string paramName = "")
        {
            Ensure.ArgumentNotNull(str, paramName);

            return str == ""
                ? throw new ArgumentException("Cannot be empty.", paramName)
                : str;
        }

        public static void NotNull([NotNull] object? obj, [CallerArgumentExpression("obj")] string paramName = "")
        {
            if (obj == null)
            {
                throw new ObjectNullException(paramName);
            }
        }

        public static string NotNullOrEmpty([NotNull] string? str, [CallerArgumentExpression("str")] string paramName = "")
        {
            Ensure.ArgumentNotNull(str, paramName);

            return str == ""
                ? throw new ArgumentException("Cannot be empty.", paramName)
                : str;
        }

        public static void NotNullOrEmpty<T>([NotNull] IList<T>? list, [CallerArgumentExpression("list")] string paramName = "")
        {
            NotNull(list, paramName);

            if (list.Count == 0)
            {
                throw new ArgumentException("Cannot be empty.", paramName);
            }
        }

        public sealed class ObjectNullException : Exception
        {
            public ObjectNullException(string name)
                : base($"Value cannot be null. (Name '{name}')")
            {
            }
        }
    }
}
