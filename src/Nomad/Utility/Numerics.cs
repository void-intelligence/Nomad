// © 2020 VOID-INTELLIGENCE ALL RIGHTS RESERVED

using System;
using static System.Math;

namespace Nomad.Utility
{
    public static class Numerics
    {
        private static readonly Random Rnd;

        static Numerics()
        {
            Rnd = new Random();
        }
        
        public static int Next()
        {
            return Rnd.Next();
        }

        public static int Next(int maxValue)
        {
            return Rnd.Next(maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return Rnd.Next(minValue, maxValue);
        }

        public static double NextDouble()
        {
            return Rnd.NextDouble();
        }

        public static double NextDouble(double minValue, double maxValue)
        {
            return Rnd.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static double NextNormal()
        {
            return Sqrt(-2.0 * Log(1.0 - Rnd.NextDouble())) * Sin(2.0 * PI * (1.0 - Rnd.NextDouble()));
        }

        public static double NextNormal(double mean, double sd)
        {
            return sd * NextNormal() + mean;
        }
    }
}
