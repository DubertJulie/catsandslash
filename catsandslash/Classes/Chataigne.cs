using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catsandslash.Classes
{
    // Le Chataigne est un petit chat caractériel et piquant - littéralement 
    public class Chataigne : Chabagarre
    {
        private bool Poison;
        public Chataigne(string nom, int pointsDeVie, int nbDesAttaques, bool poison)
        : base(nom, pointsDeVie, nbDesAttaques) // Appelle le constructeur de Guerrier
        {
            Poison = poison;
        }

        public override int Attaquer()
        {
            Random rng = new Random();
            degats = rng.Next(1, 7); // 1 - 6 

            Random poisonneur = new Random();
            int poisonner = poisonneur.Next(1, 4); // 1 - 3 

            if (poisonner == 3) // une chance sur trois de devenir un (em)poisonneur !
            {
                Poison = true;
            } else
            {
                Poison = false;
            }

            if (Poison == true) {
                degats += 2; 
                Console.WriteLine(Nom + " empoisonne son adversaire ! Il inflige \u001b[31;1m" + degats + " dmg\u001b[37m . Ouch !");

            } else
            {
                Console.WriteLine(Nom + " inflige \u001b[31;1m" + degats + " dmg\u001b[37m.");
            }
            return degats;
        }
    }
}