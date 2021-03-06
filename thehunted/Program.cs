using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thehunted
{
    class Program
    {
        const int cycles = 1000000;

        const int CLOSE_RANGE = 1;
        const int MEDIUM_RANGE = 2;
        const int LONG_RANGE = 3;
        const int STEAM = 1;
        const int ELECTRIC = 2;
        const int GUN = 3;
        const int FALKE = 4;
        const int ZAUNKOENIG = 5;
        const int ZAUNKOENIG2 = 6;
        const int FAT = 7;
        const int FAT2 = 8;

        const int max = 11;


        static void print_result(string name, double[] results)
        {
            //Console.Write(name + " = \t");
            for (int n = 0; n < max; n++)
            {
                double number = Math.Round(results[n] / cycles, 2);
                if (number <= 0.05)
                    Console.Write("-" + "\t");
                else
                    Console.Write(number + "\t");
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            double[] steam_close = new double[max];
            double[] steam_medium = new double[max];
            double[] steam_long = new double[max];

            double[] electric_close = new double[max];
            double[] electric_medium = new double[max];
            double[] electric_long = new double[max];

            double[] falke_close = new double[max];
            double[] falke_medium = new double[max];
            double[] falke_long = new double[max];

            double[] zaun_close = new double[max];
            double[] zaun_medium = new double[max];
            double[] zaun_long = new double[max];

            double[] zaun2_close = new double[max];
            double[] zaun2_medium = new double[max];
            double[] zaun2_long = new double[max];

            double[] gun_close = new double[max];
            double[] gun_medium = new double[max];
            double[] gun_long = new double[max];

            Dice.init();

            for (double i = 0; i < cycles; i++)
            {
                for (int n = 0; n < max; n++)
                {
                    steam_close[n] += weapon(n - 2, CLOSE_RANGE, STEAM);
                    steam_medium[n] += weapon(n - 2, MEDIUM_RANGE, STEAM);
                    steam_long[n] += weapon(n - 2, LONG_RANGE, STEAM);

                    electric_close[n] += weapon(n - 2, CLOSE_RANGE, ELECTRIC);
                    electric_medium[n] += weapon(n - 2, MEDIUM_RANGE, ELECTRIC);
                    electric_long[n] += weapon(n - 2, LONG_RANGE, ELECTRIC);

                    falke_close[n] += weapon(n - 2, CLOSE_RANGE, FALKE);
                    falke_medium[n] += weapon(n - 2, MEDIUM_RANGE, FALKE);
                    falke_long[n] += weapon(n - 2, LONG_RANGE, FALKE);

                    zaun_close[n] += weapon(n - 2, CLOSE_RANGE, ZAUNKOENIG);
                    zaun_medium[n] += weapon(n - 2, MEDIUM_RANGE, ZAUNKOENIG);
                    zaun_long[n] += weapon(n - 2, LONG_RANGE, ZAUNKOENIG);

                    zaun2_close[n] += weapon(n - 2, CLOSE_RANGE, ZAUNKOENIG2);
                    zaun2_medium[n] += weapon(n - 2, MEDIUM_RANGE, ZAUNKOENIG2);
                    zaun2_long[n] += weapon(n - 2, LONG_RANGE, ZAUNKOENIG2);

                    gun_close[n] += weapon(n - 2, CLOSE_RANGE, GUN);
                    gun_medium[n] += weapon(n - 2, MEDIUM_RANGE, GUN);
                    gun_long[n] += weapon(n - 2, LONG_RANGE, GUN);
                }
            }

            print_result("steam_close", steam_close);
            print_result("elec_close", electric_close);
            print_result("falke_close", falke_close);
            print_result("zaun_close", zaun_close);
            print_result("zaun2_close", zaun2_close);
            print_result("gun_close", gun_close);
            Console.WriteLine();

            print_result("steam_medium", steam_medium);
            print_result("elec_medium", electric_medium);
            print_result("falke_medium", falke_medium);
            print_result("zaun_medium", zaun_medium);
            print_result("zaun2_medium", zaun2_medium);
            print_result("gun_medium", gun_medium);
            Console.WriteLine();

            print_result("steam_long", steam_long);
            print_result("elec_long", electric_long);
            print_result("falke_long", falke_long);
            print_result("zaun_long", zaun_long);
            print_result("zaun2_long", zaun2_long);
            print_result("gun_long", gun_long);


        }

        static int weapon(int modifier, int range, int type)
        {
            int um = Dice.d6() + Dice.d6();     // unmodified
            int n = um;

            // U1: Hit Check
            if ((type == FALKE && um <= 5) || (type == ZAUNKOENIG && um <= 6) || (type == ZAUNKOENIG2 && um <= 7))
            {

            }
            else
            {
                n += modifier;
                if (type == ELECTRIC && range == MEDIUM_RANGE)
                    n += 1;
                if (type == ELECTRIC && range == LONG_RANGE)
                    n += 2;
                if (range == CLOSE_RANGE && n >= 9)
                    return 0;
                if (range == MEDIUM_RANGE && n >= 8)
                    return 0;
                if (range == LONG_RANGE && n >= 7)
                    return 0;
            }

            // U3: Damage Chart
            int damage = Dice.d6();
            if (type == GUN)
            {
                damage--;
                switch (damage)
                {
                    case 0:
                        return 2;
                    case 1:
                        return 2;
                    case 2:
                        return 1;
                    case 3:
                        return 1;
                    case 4:
                    case 5:
                    case 6:
                        return 1;
                }
            }
            else {

                // dud check
                if (Dice.d6() == 1)
                    return 0;

                switch (damage)
                {
                    case 0:
                        return 0;
                    case 1:
                        return 4;
                    case 2:
                        return 3;
                    case 3:
                        return 2;
                    case 4:
                    case 5:
                    case 6:
                        return 1;
                }
            }
            return 0;
        }
    }
}
