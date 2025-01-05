using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catsandslash.Classes
{
    // Le Chalutier a passé beaucoup de temps à la mer; il en a récupéré le secret de sa force régénératrice de PV
    public class Chalutier : Chabagarre
    {
        public Chalutier(string nom, int pointsDeVie, int nbDesAttaques)
        : base(nom, pointsDeVie, nbDesAttaques)
        {
        }
        public override void SubirDegats(int degats)
        {
            Random regenPVmodificateur = new Random();
            int modificateur = regenPVmodificateur.Next(1, 4); 

            int regenPV = degats / modificateur;
            PointsDeVie = PointsDeVie - degats + regenPV;
            Console.WriteLine(Nom + " reçoit " + degats + " dmg... mais la mer lui rend \u001b[32m" + regenPV +" PV\u001b[37m.");

        }
    }
}
