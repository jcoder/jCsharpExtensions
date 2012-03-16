using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Extension Methods for IEnumerable
/// </summary>
public static class IEnumerableExtensions
{

    /// <summary>
    /// Performs an action with each of the elements in this IEnumerable
    /// </summary>
    /// <param name="enumerable">this IEnumerable</param>
    /// <param name="action">action to be performed on each element</param>
    /// <returns>IEnumerable</returns>
    public static IEnumerable<T> WithEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        if (action == null)
        {
            action = (obj) => { };
        }
        foreach (T oneObject in enumerable)
        {
            action(oneObject);
            yield return oneObject;
        }
    }

    /// <summary>
    /// Concatinates all elements of this IEnumerable to a flat string, optionally quoting them
    /// </summary>
    /// <param name="enumerable">this IEnumerable</param>
    /// <param name="glue">glue between the elements</param>
    /// <param name="quoteStart">quote at start of each element</param>
    /// <param name="quoteEnd">quote at end of each element</param>
    /// <returns>flat string</returns>
    public static string ToFlatString<T>(this IEnumerable<T> enumerable, string glue, string quoteStart, string quoteEnd)
    {
        if (glue == null)
        {
            glue = ",";
        }
        if (quoteStart == null)
        {
            quoteStart = "";
        }
        if (quoteEnd == null)
        {
            quoteEnd = "";
        }
        StringBuilder strBuilder = new StringBuilder();
        bool useGlue = false;
        foreach (T oneObject in enumerable)
        {
            if (useGlue == true)
            {
                strBuilder.Append(glue);
            }
            else
            {
                useGlue = true;
            }
            strBuilder.Append(quoteStart).Append(oneObject).Append(quoteEnd);
        }
        return strBuilder.ToString();
    }

    /// <summary>
    /// Concatinates all elements of this IEnumerable to a flat string
    /// </summary>
    /// <param name="enumerable">this IEnumerable</param>
    /// <param name="glue">glue between the elements</param>
    /// <returns>flat string</returns>
    public static string ToFlatString<T>(this IEnumerable<T> enumerable, string glue)
    {
        return ToFlatString(enumerable, glue, "", "");
    }

    /// <summary>
    /// Concatinates all elements of this IEnumerable to a flat string
    /// </summary>
    /// <param name="enumerable">this IEnumerable</param>
    /// <param name="glue">glue between the elements</param>
    /// <param name="toStringFnc">function to convert each element to string</param>
    /// <returns>flat string</returns>
    public static string ToFlatString<T>(this IEnumerable<T> enumerable, string glue, Func<T, string> toStringFnc)
    {
        if (glue == null)
        {
            glue = ",";
        }
        if (toStringFnc == null)
        {
            toStringFnc = (obj) => { return (obj != null) ? obj.ToString() : "null"; };
        }
        StringBuilder strBuilder = new StringBuilder();
        bool useGlue = false;
        foreach (T oneObject in enumerable)
        {
            if (useGlue == true)
            {
                strBuilder.Append(glue);
            }
            else
            {
                useGlue = true;
            }
            strBuilder.Append(toStringFnc(oneObject));
        }
        return strBuilder.ToString();
    }

    /// <summary>
    /// Repeats this IEnumerable a given number of times
    /// </summary>
    /// <param name="enumerable">this IEnumerable</param>
    /// <param name="times">number of times to repeat this IEnumerable</param>
    /// <returns>IEnumerable</returns>
    public static IEnumerable<T> Repeated<T>(this IEnumerable<T> enumerable, int times)
    {
        if (times < 1)
        {
            yield break;
        }
        for (int i = 0; i < times; i++)
        {
            foreach (T oneObject in enumerable)
            {
                yield return oneObject;
            }
        }
    }

}

