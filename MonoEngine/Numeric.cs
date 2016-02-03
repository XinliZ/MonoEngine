using System;
using System.Diagnostics;

namespace MonoEngine
{
    public static class Numeric
    {
        public static T CircularIncreaseInRange<T>(T newItem, T maxValue, T minValue) where T : struct, IComparable
        {
            Debug.Assert(maxValue.CompareTo(minValue) > 0);
            if (newItem.CompareTo(maxValue) > 0)
            {
                newItem = minValue;
            }
            else if (newItem.CompareTo(minValue) < 0)
            {
                newItem = maxValue;
            }
            return newItem;
        }
    }
}
