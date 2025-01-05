using System;
using catsandslash.Classes;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ecran d'accueil
            Console.WriteLine(".--------------------------------------------------------------.\r\n|                                                              |\r\n|                                                              |\r\n|                _          ___         _           _          |\r\n|       ___ __ _| |_ ___   ( _ )    ___| | __ _ ___| |__       |\r\n|      / __/ _ | __/ __|  / _ \\/\\ / __| |/ _ / __| '_ \\      |\r\n|     | (_| (_| | |_\\__ \\ | (_>  < \\__ \\ | (_| \\__ \\ | | |     |\r\n|      \\___\\__,_|\\__|___/  \\___/\\/ |___/_|\\__,_|___/_| |_|     |\r\n|                                                              |\r\n|                                                              |\r\n'--------------------------------------------------------------'");
            Console.WriteLine("Appuie sur n'importe quelle touche pour commencer...");
            Console.ReadKey();

            // Création de mes chabagarreurs par défaut
            List<Chabagarre> Chabagarreurs = new List<Chabagarre>();
            Chabagarreurs.Add(new Chabagarre("Julo", 45, 3));
            Chabagarreurs.Add(new Chalumeau("Flambo", 45, 3));
            Chabagarreurs.Add(new Chalutier("Goutt'do", 45, 3));
            Chabagarreurs.Add(new Chataigne("Kipik", 45, 3, false));
            Chabagarreurs.Add(new Chahuteur("Koudepel", 45, 3, false));

            bool jeuEnCours = true;

            // Fonction qui gère l'affichage du menu
            void AfficherMenu()
            {
                Console.WriteLine(".--------------------------------------------------------------.\r\n|                                                              |\r\n|                                                              |\r\n|                _          ___         _           _          |\r\n|       ___ __ _| |_ ___   ( _ )    ___| | __ _ ___| |__       |\r\n|      / __/ _ | __/ __|  / _ \\/\\ / __| |/ _ / __| '_ \\      |\r\n|     | (_| (_| | |_\\__ \\ | (_>  < \\__ \\ | (_| \\__ \\ | | |     |\r\n|      \\___\\__,_|\\__|___/  \\___/\\/ |___/_|\\__,_|___/_| |_|     |\r\n|                                                              |\r\n|                                                              |\r\n'--------------------------------------------------------------'");
                Console.WriteLine("1. Créer un chabagarreur");
                Console.WriteLine("2. Afficher tous les chabagarreurs");
                Console.WriteLine("3. Commencer un combat");
                Console.WriteLine("4. Quitter");
                Console.Write("Choisis une option : ");
            }

            // Fonction pour créer mes différents chabagarreurrs
            void CreerChabagarre()
            {
                Console.WriteLine("Entre le nom de ton petit chat :");
                string nom = Console.ReadLine();

                Console.WriteLine("Choisis la classe de ton petit chat :");
                Console.WriteLine("1 - " + "\u001B[93mChabagarre\u001b[0m| Un petit chat combattif");
                Console.WriteLine("2 - " + "\u001b[31mChalumeau\u001b[0m | Un petit chat de type feu");
                Console.WriteLine("3 - " + "\u001b[35mChahuteur\u001b[0m | Un petit chat de type terre");
                Console.WriteLine("4 - " + "\u001b[32mChataigne\u001b[0m | Un petit chat de type plante");
                Console.WriteLine("5 - " + "\u001b[34mChalutier\u001b[0m | Un petit chat de type eau");
                int choixDeClasse = Int32.Parse(Console.ReadLine());
                string[] classes = ["Chabagarre", "Chalumeau", "Chahuteur", "Chataigne", "Chalutier"];

                Random Pdv = new Random();
                int pdv = Pdv.Next(40, 51);
                Console.WriteLine("Ton petit chat sera un " + classes[choixDeClasse - 1] + " et il aura " + pdv + " points de vie. Bon courage !");

                switch (choixDeClasse)
                {
                    case 1:
                        Chabagarreurs.Add(new Chabagarre(nom, pdv, 3));
                        break;
                    case 2:
                        Chabagarreurs.Add(new Chalumeau(nom, pdv, 3));
                        break;
                    case 3:
                        Chabagarreurs.Add(new Chahuteur(nom, pdv, 3, false));
                        break;
                    case 4:
                        Chabagarreurs.Add(new Chataigne(nom, pdv, 3, false));
                        break;
                    case 5:
                        Chabagarreurs.Add(new Chalutier(nom, pdv, 3));
                        break;
                }
            }

            // Fonction pour afficher la liste des chabagarreurs
            void AfficherChabagarreurs()
            {
                int i = 1;
                if (Chabagarreurs.Count == 0)
                { Console.WriteLine("Oups... Tous les chabagarreurs ont déserté pour l'instant !"); }
                else
                {
                    Console.WriteLine("\n--- LISTE DES CHABAGARREURS ---\n\n");
                    foreach (var chats in Chabagarreurs)
                    {
                        Console.WriteLine("N°" + i + " - " + chats.Nom + " (" + chats.GetType().Name + "), " + chats.PointsDeVie + "PV");
                        i++;
                        Console.WriteLine("-------------------------------");
                    }
                    Console.WriteLine("\n");
                }
            }

            // Système de combat en tour à tour 
            void LancerCombat()
            {
                // Pré-stockage 
                Chabagarre attaquant = null;
                Chabagarre defenseur = null;
                Chabagarre joueur1 = null;
                Chabagarre joueur2 = null;

                // Choix des petits chats
                if (Chabagarreurs.Count >= 2)
                {
                    Console.WriteLine("Le joueur 1 choisit son petit chat...");
                    AfficherChabagarreurs();
                    int player1;
                    while (!int.TryParse(Console.ReadLine(), out player1) || player1 < 1 || player1 > Chabagarreurs.Count) // Contrôle de saisie 
                    {
                        Console.Write("Entrée invalide ! Choisis un numéro de petit chat compris entre 1 et " + Chabagarreurs.Count + " : ");
                    }
                    joueur1 = Chabagarreurs[player1 - 1];

                    Console.Clear();
                    Console.WriteLine("Le joueur 2 choisit son petit chat...");
                    AfficherChabagarreurs();
                    int player2;
                    while (!int.TryParse(Console.ReadLine(), out player2) || player2 < 1 || player2 > Chabagarreurs.Count || player2 == player1) // Contrôle de saisie 
                    {
                        Console.Write("Entrée invalide ! Choisis un numéro de petit chat compris entre 1 et " + Chabagarreurs.Count + " : ");
                    }

                    if (player1 != player2)
                    {
                        joueur2 = Chabagarreurs[player2 - 1];
                        Console.WriteLine("Joueur 1 : " + joueur1.Nom);
                        Console.WriteLine("Joueur 2 : " + joueur2.Nom);

                        // Qui commence le combat
                        Random initiative = new Random();
                        int init = initiative.Next(1, 3);

                        if (init == 1)
                        {
                            Console.WriteLine("Le sort a tranché... C'est " + joueur1.Nom + " qui commence !");
                            attaquant = joueur1;
                            defenseur = joueur2;
                            Console.WriteLine("Appuie sur n'importe quelle touche pour lancer le combat !");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Le sort a tranché... C'est " + joueur2.Nom + " qui commence !");
                            attaquant = joueur2;
                            defenseur = joueur1;
                            Console.WriteLine("Appuie sur n'importe quelle touche pour lancer le combat !");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }

                }

                bool combatEnCours = true;
                // Récupération des PV initiaux pour les réattribuer en fin de combat
                int pointsInitiauxJoueur1 = joueur1.PointsDeVie;
                int pointsInitiauxJoueur2 = joueur2.PointsDeVie;

                while (combatEnCours)
                {
                    if (attaquant != null && defenseur != null)
                    {
                        while (attaquant.PointsDeVie > 0 && defenseur.PointsDeVie > 0)
                        {
                            joueur1.AfficherInfos();
                            Console.WriteLine("\n--- VS ---\n");
                            joueur2.AfficherInfos();
                            Console.WriteLine("----------");
                            defenseur.SubirDegats(attaquant.Attaquer());
                            Thread.Sleep(1500); // Délai entre les attaques
                            Console.Clear();

                            if (defenseur.PointsDeVie <= 0)
                            {
                                Console.WriteLine(defenseur.Nom + " a été vaincu ! :(");
                                Console.WriteLine(attaquant.Nom + " remporte le combat !");
                                joueur1.PointsDeVie = pointsInitiauxJoueur1;
                                joueur2.PointsDeVie = pointsInitiauxJoueur2;
                                Console.WriteLine("Appuie sur n'importe quelle touche pour revenir au menu...");
                                Console.ReadKey();
                                combatEnCours = false;
                                break;
                            }

                            // Stockage pour le tour à tour, attaquant devient défenseur et vice versa
                            var changementJoueur = attaquant;
                            attaquant = defenseur;
                            defenseur = changementJoueur;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Le combat ne peut pas commencer.");
                        combatEnCours = false;
                    }
                }
            }


            do
            {
                Console.Clear();
                AfficherMenu();

                int choixMenu;
                while (!int.TryParse(Console.ReadLine(), out choixMenu) || choixMenu < 1 || choixMenu > 4)
                {
                    Console.WriteLine("Choisis une option valide du menu !");
                }

                switch (choixMenu)
                {
                    case 1:
                        Console.Clear();
                        CreerChabagarre();
                        Console.WriteLine("Appuie sur n'importe quelle touche pour retourner au menu !");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        AfficherChabagarreurs();
                        Console.WriteLine("Appuie sur n'importe quelle touche pour retourner au menu !");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        LancerCombat();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Au revoir !");
                        jeuEnCours = false;
                        break;
                    default:
                        Console.WriteLine("Choix invidalide, réessaie pour voir ?");
                        break;
                }
            } while (jeuEnCours);


        }
    }
}