using System;
using UnityEngine;
using System.Collections;

//From: https://github.com/foolmoron/PicosRapture/blob/master/Assets/Scripts/Extensions/ArrayExtensions.cs
//Credit to this guy github.com/foolmoron for making these extensions public

public static class ArrayExtensions
{

    public static T random<T>(this T[] array)
    {
        return array[Mathf.FloorToInt(UnityEngine.Random.value * array.Length)];
    }

    public static int Count<T>(this T[] array, Func<T, bool> countPredicate)
    {
        var count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (countPredicate(array[i]))
                count++;
        }
        return count;
    }

    public static void ForEach<T>(this T[] array, Action<T> action)
    {
        for (int i = 0; i < array.Length; i++)
        {
            action(array[i]);
        }
    }
}
