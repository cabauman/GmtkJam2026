using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace System.Runtime.InteropServices
{
    [ExcludeFromCodeCoverage]
    public static class CollectionsMarshal
    {
#pragma warning disable SX1309 // Field should begin with an underscore
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value null
        class ListDummy<T>
        {
            public T[] Items;
            int size;
            int version;
        }
#pragma warning restore CS0649
#pragma warning restore SX1309

        public static Span<T> AsSpan<T>(List<T> list)
        {
            return UnsafeUtility.As<List<T>, ListDummy<T>>(ref list).Items.AsSpan(0, list.Count);
            //return Unsafe.As<ListDummy<T>>(list).Items.AsSpan(0, list.Count);
        }
    }
}
