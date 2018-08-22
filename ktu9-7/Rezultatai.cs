using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktu9_7
{
    class Rezultatai
    {
        public int skaiciusSuma;
        public int skaitiklisSuma;
        public int vardiklisSuma;
        public int skaiciusSkirt;
        public int skaitiklisSkirt;
        public int vardiklisSkirt;

        public Rezultatai(int skaiciusSuma, int skaitiklisSuma, int vardiklisSuma, int skaiciusSkirt, int skaitiklisSkirt, int vardiklisSkirt)
        {
            this.skaiciusSuma = skaiciusSuma;
            this.skaitiklisSuma = skaitiklisSuma;
            this.vardiklisSuma = vardiklisSuma;
            this.skaiciusSkirt = skaiciusSkirt;
            this.skaitiklisSkirt = skaitiklisSkirt;
            this.vardiklisSkirt = vardiklisSkirt;
        }
    }
}
