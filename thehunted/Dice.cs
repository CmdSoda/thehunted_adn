using System;
using System.Diagnostics;

namespace thehunted
{
    public class Dice
    {
        private static Random r;

        public static void init()
        {
            r = new Random((int)DateTime.Now.Ticks);
        }

        public static int d6()
        {
            int value = r.Next(1, 7);
            Debug.Assert(value >= 1 && value <= 6);
            return value;
        }
    }
}
