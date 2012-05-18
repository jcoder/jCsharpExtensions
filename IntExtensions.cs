using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Extension Methods for int
/// </summary>
public static class IntExtensions
{

    /// <summary>
    /// Returns an enumerable range between this value and another value
    /// </summary>
    /// <param name="startValue">this int</param>
    /// <param name="endValue">end value (included)</param>
    /// <returns>IEnumerable</returns>
    public static IEnumerable<int> To(this int startValue, int endValue)
    {
        int step = (startValue <= endValue) ? 1 : -1;
        while (startValue <= endValue)
        {
            yield return startValue;
            startValue = startValue + step;
        }
    }

    /// <summary>
    /// Returns an enumerable range between this value and another value
    /// </summary>
    /// <param name="startValue">this int</param>
    /// <param name="endValue">end value (included)</param>
    /// <param name="step">step</param>
    /// <returns>IEnumerable</returns>
    public static IEnumerable<int> To(this int startValue, int endValue, int step)
    {
        if (step == 0) 
        {
            yield break;
        }
        if ((startValue > endValue) && (step > 0))
        {
            yield break;
        }
        if ((startValue < endValue) && (step < 0))
        {
            yield break;
        }
        while (startValue <= endValue)
        {
            yield return startValue;
            startValue = startValue + step;
        }
    }

}

