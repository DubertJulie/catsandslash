using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace catsandslash.Classes
{
    public class Chabagarre
    {
        // attributs
        private string _nom;
        private int _pointsDeVie;
        private int _nbDesAttaques;

        // propriétés 
        public string Nom { get { return _nom; } set { _nom = value; } }
        public int PointsDeVie { get { return _pointsDeVie; } set { _pointsDeVie = value; } }
        public int NbDesAttaques { get { return _nbDesAttaques; } set { _nbDesAttaques = value; } }
        public static int degats { get; set; } = 0;


        // constructor 
        public Chabagarre(string nom, int pointsDeVie, int nbDesAttaques)
        {
            Nom = nom;
            PointsDeVie = pointsDeVie;
            NbDesAttaques = nbDesAttaques;
        }

        public void AfficherInfos() // Afficher dans la console les informations du guerrier
        {
            string str = " /\\_/\\\r\n( o.o )\r\n > ^ <";
            Console.WriteLine(str);
            Console.WriteLine(Nom + " | " + PointsDeVie + " PV");
        }

        // Attaque classique du chabagarre
        public virtual int Attaquer()
        {
            Random rng = new Random();
            degats = rng.Next(1, 7); // 1 - 6 

            Console.WriteLine(Nom + " inflige \u001b[31;1m" + degats + " dmg\u001b[37m ! Aïe !");
            return degats;
        }

        public virtual void SubirDegats(int degats)
        {
            // Console.WriteLine(Nom + " reçoit " + degats + " dmg");
            PointsDeVie = PointsDeVie - degats;
        }

    }
}