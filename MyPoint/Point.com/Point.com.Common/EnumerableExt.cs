using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
// ReSharper disable CheckNamespace

namespace System
// ReSharper restore CheckNamespace
{
    public static class EnumerableExt
    {
        public static TValue LoadValue<TKey, TValue>(this  IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> resolveValue)
        {
            if (!dictionary.ContainsKey(key))
            {
                TValue resultValue = resolveValue();
                dictionary.Add(key, resultValue);
            }
            return dictionary[key];
        }
        public static void AddOrCover<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        public static void Combine<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                var values = dictionary[key];
                values.Add(value);
                dictionary[key] = values;
            }
            else
            {
                dictionary.Add(key, new List<TValue>() { value });
            }
        }

        public static bool IsHasRow<T>(this IEnumerable<T> enumerable)
        {
            bool flag = null != enumerable && enumerable.Any();
            return flag;
        }

        public static bool IsNull<T>(this T t) where T : class
        {
            bool flag = t == null;
            return flag;
        }
        /// <summary>
        /// 有对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsNotNull<T>(this T t) where T : class
        {
            bool flag = t != null;
            return flag;
        }

        public static List<T> Remove<T>(this IEnumerable<T> enumerable, Func<T, bool> matchFunction)
        {
            List<T> lst = null;
            if (enumerable.IsHasRow())
            {
                lst = new List<T>();
                foreach (var item in enumerable)
                {
                    if (matchFunction(item))
                    {
                        continue;
                    }
                    lst.Add(item);
                }
            }
            return lst;
        }

        public static List<T> Update<T>(this IEnumerable<T> enumerable, Func<T, bool> matchFunction, Func<T, T> updateFunction)
        {
            List<T> lst = null;
            if (enumerable.IsHasRow())
            {
                lst = new List<T>();
                foreach (var item in enumerable)
                {
                    var tempT = item;
                    if (matchFunction(item))
                    {
                        tempT = updateFunction(item);
                    }
                    lst.Add(tempT);
                }
            }
            return lst;
        }
    }

    public delegate void FuncVoid<in T1>(T1 t);
}