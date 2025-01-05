using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catsandslash.Classes
{
    // Le chalumeau est un petit chat tout feu, tout flamme et qui peut faire très mal
    public class Chalumeau : Chabagarre
    {
        private bool ArmureLourde;
        public Chalumeau(string nom, int pointsDeVie, int nbDesAttaques)
        : base(nom, pointsDeVie, nbDesAttaques)
        {
        }
        public override int Attaquer()
        {
            Random rng = new Random();
            degats = rng.Next(1, 5); // 1 - 4 

            if (degats == 1 || degats == 2)
            {
                degats += 1;
                Console.WriteLine("Brûlure au premier degré ! " + Nom + " inflige \u001b[31;1m" + degats + " dmg\u001b[37m.");
            } else if (degats == 3 || degats == 4)
                {
                degats += 2;
                Console.WriteLine("Brûlure au second degré ! " + Nom + " inflige \u001b[31;1m" + degats + " dmg\u001b[37m.");
            }
            else
            {
                degats += 3;
                Console.WriteLine("Brûlure au troisième degré ! " + Nom + " inflige \u001b[31;1m" + degats + " dmg\u001b[37m.");
            }

            return degats;
        }
    }
}
