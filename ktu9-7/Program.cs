using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktu9_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int eiluciuSkaicius;
            Duomenys[] duomenys;

            duomenuNuskaitymas(out eiluciuSkaicius, out duomenys);

            Rezultatai[] rezultatai = rezSkaiciavimas(eiluciuSkaicius, duomenys);

            spausdinimas(eiluciuSkaicius, duomenys, rezultatai);
        }

        private static Rezultatai[] rezSkaiciavimas(int eiluciuSkaicius, Duomenys[] duomenys)
        {
            Rezultatai[] rezultatai = new Rezultatai[eiluciuSkaicius];
            for (int i = 0; i < eiluciuSkaicius; i++)
            {
                int skaiciusSuma = 0;
                int skaitiklisSuma = 0;
                int vardiklisSuma = 0;
                int skaiciusSkirt = 0;
                int skaitiklisSkirt = 0;
                int vardiklisSkirt = 0;
                suma(ref skaiciusSuma, ref skaitiklisSuma, ref vardiklisSuma, duomenys, i);
                skirtumas(ref skaiciusSkirt, ref skaitiklisSkirt, ref vardiklisSkirt, duomenys, i);
                rezultatai[i] = new Rezultatai(skaiciusSuma, skaitiklisSuma, vardiklisSuma, skaiciusSkirt, skaitiklisSkirt, vardiklisSkirt);
            }

            return rezultatai;
        }

        private static void duomenuNuskaitymas(out int eiluciuSkaicius, out Duomenys[] duomenys)
        {
            string[] tekstas =
                System.IO.File.ReadAllLines(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu9-7\ktu9-7\duomenys.txt");
            eiluciuSkaicius = Convert.ToInt32(tekstas[0]);
            duomenys = new Duomenys[eiluciuSkaicius];
            for (int i = 0; i < eiluciuSkaicius; i++)
            {
                string eile = tekstas[i + 1];
                string[] eilute = eile.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                int[] skaiciai = Array.ConvertAll(eilute, int.Parse);
                duomenys[i] = new Duomenys(skaiciai[0], skaiciai[1], skaiciai[2], skaiciai[3], skaiciai[4], skaiciai[5]);
            }
        }

        private static void suma(ref int skaiciusSum, ref int skaitiklisSum, ref int vardiklisSum, Duomenys[] duomenys, int i)
        {
            int a = duomenys[i].skaicius1;
            int b = duomenys[i].skaitiklis1;
            int c = duomenys[i].vardiklis1;
            int x = duomenys[i].skaicius2;
            int y = duomenys[i].skaitiklis2;
            int z = duomenys[i].vardiklis2;

            skaitiklisSum = (a * c + b) * z + (x * z + y) * c;
            vardiklisSum = c * z;
            skaiciusSum = skaitiklisSum / vardiklisSum;
            skaitiklisSum = skaitiklisSum % vardiklisSum;
            if(skaitiklisSum == 0)
            {
                vardiklisSum = 0;
            }

            prastinimas(ref skaitiklisSum, ref vardiklisSum);
        }

        private static void skirtumas(ref int skaiciusSkirt, ref int skaitiklisSkirt, ref int vardiklisSkirt, Duomenys[] duomenys, int i)
        {
            int a = duomenys[i].skaicius1;
            int b = duomenys[i].skaitiklis1;
            int c = duomenys[i].vardiklis1;
            int x = duomenys[i].skaicius2;
            int y = duomenys[i].skaitiklis2;
            int z = duomenys[i].vardiklis2;

            skaitiklisSkirt = (a * c + b) * z - (x * z + y) * c;
            vardiklisSkirt = c * z;
            skaiciusSkirt = skaitiklisSkirt / vardiklisSkirt;
            skaitiklisSkirt = skaitiklisSkirt % vardiklisSkirt;
            if(skaitiklisSkirt == 0)
            {
                vardiklisSkirt = 0;
            }

            prastinimas(ref skaitiklisSkirt, ref vardiklisSkirt);
        }

        private static void prastinimas(ref int skaitiklisSum, ref int vardiklisSum)
        {
            for (int j = skaitiklisSum; j > 0; j--)
            {
                if (skaitiklisSum % j == 0 && vardiklisSum % j == 0)
                {
                    skaitiklisSum = skaitiklisSum / j;
                    vardiklisSum = vardiklisSum / j;
                    break;
                }
            }
        }

        private static void spausdinimas(int eiluciuSkaicius, Duomenys[] duomenys, Rezultatai[] rezultatai)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu9-7\ktu9-7\rezultatai.txt"))
            {
                file.WriteLine(string.Format("{0,-12}{1,-12}{2,-12}{3}", "vienas", "du", "Suma", "Skirtumas"));
                for (int i = 0; i < eiluciuSkaicius; i++)
                {
                    file.WriteLine("{0,-12}{1,-12}{2,-12}{3}", duomenys[i].skaicius1 + " " + duomenys[i].skaitiklis1 + "/" 
                        + duomenys[i].vardiklis1,
                        duomenys[i].skaicius2 + " " + duomenys[i].skaitiklis2 + "/" + duomenys[i].vardiklis2,
                        rezultatai[i].skaiciusSuma + " " + rezultatai[i].skaitiklisSuma + "/" + rezultatai[i].vardiklisSuma,
                        rezultatai[i].skaiciusSkirt + " " + rezultatai[i].skaitiklisSkirt + "/" + rezultatai[i].vardiklisSkirt);

                }
            }
        }
    }
}
