using System;
using System.Collections.Generic;

public static class GameUtils
{
    // Generic method to transform a collection using Func<T, TResult>
    public static List<TResult> Transform<T, TResult>(IEnumerable<T> collection, Func<T, TResult> transformer)
    {
        var result = new List<TResult>();
        foreach (var item in collection)
        {
            result.Add(transformer(item));
        }
        return result;
    }
}