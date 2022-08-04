using System;

namespace DistanceCalculator.Core.Extensions
{
    public static class DegreesExtensions
    {
        /// <summary>
        /// Convert degrees to Radians
        /// </summary>
        /// <param name="degrees">Degrees</param>
        /// <returns>The equivalent in radians</returns>
        public static double ToRadians(this double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
