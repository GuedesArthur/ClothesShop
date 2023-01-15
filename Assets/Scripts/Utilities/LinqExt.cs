using System;
using System.Collections.Generic;
using System.Linq;

public static class LinqExt
{
    /// <typeparam name="TObj">Class type</typeparam>
    /// <typeparam name="TPriority">Measured priority type</typeparam>
    /// <param name="evaluate">Measures the priority of each TObj</param>
    /// <returns>Minimal object measured by the evaluation <see cref="Func{T, TResult}"/></returns>
    public static TObj MinObj<TObj, TPriority>(this IEnumerable<TObj> objs, Func<TObj, TPriority> evaluate)
        where TPriority : IComparable<TPriority>
    {
        var min = objs.First();
        var minValue = evaluate.Invoke(min);

        foreach(var obj in objs)
        {
            var val = evaluate.Invoke(obj);
            if (val.CompareTo(minValue) >= 0) continue;

            (min, minValue) = (obj, val);
        }

        return min;
    }
}