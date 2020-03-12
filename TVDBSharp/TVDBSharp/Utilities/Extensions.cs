using System;

namespace TVDBSharp.Utilities
{
    public static class Extensions
    {
        public static long ToEpoch(this DateTime date)
        {
            var timeDifference = date - new DateTime(1970, 1, 1);
            return (int)timeDifference.TotalSeconds;
        }
    }
}