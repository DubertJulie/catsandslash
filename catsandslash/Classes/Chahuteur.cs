using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catsandslash.Classes
{
    // Le chahuteur est un chat particulièrement résistant 
    public class Chahuteur : Chabagarre
    {
        private bool ArmureLourde;
        public Chahuteur(string nom, int pointsDeVie, int nbDesAttaques, bool armurelourde)
        : base(nom, pointsDeVie, nbDesAttaques)
        {
            ArmureLourde = armurelourde;
        }

        public override void SubirDegats(int degats)
        {
            Random armure = new Random();
            int isArmure = armure.Next(1, 3); // une chance sur deux

            if (isArmure == 1)
            {
                ArmureLourde = true;
                Console.WriteLine(Nom + " ne subit aucun dégât grâce à son armure ! La chance !");
                ArmureLourde = false;
            }
            else
            {
                PointsDeVie = PointsDeVie - degats;
            }
        }
    }
}
