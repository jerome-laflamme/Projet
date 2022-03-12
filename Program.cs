using System;
using Project;

namespace Projet 
{
    internal class Program
    {
        static void Main()
        {
            int input;
            decimal coins = 1, sommeRecue = 0;

            while (true) // MAIN LOOP
            {
                bool isComplete = false;
                input = getSelection(); // Demander le numero de bonbon
                Candy bonbonChoisi = GetCandy(input -1); // Enregistrer le bonbon choisi dans une variable de type Candy
                
                do {
                    if (bonbonChoisi.Stock < 1) 
                    {
                        Board.Print( $"{bonbonChoisi.Name} VIDE!", selection:input); // Imprimer que le bonbon choisi est hors stock
                        isComplete = true;
                    }
                    else
                    {
                        Board.Print(bonbonChoisi.Name, input, bonbonChoisi.Price);
                        while (bonbonChoisi.Price > sommeRecue && coins != 0) // Redemander de la monnaie tant qu'elle n'est pas 0 ou qu'elle n'a pas ete atteint
                        {
                            coins = GetCoin(); // chaque loop, on demande a l'utilisateur de rentrer la somme que j'enregistre dans un variable
                            sommeRecue += coins; // et je l'additionne a la somme recu
                            Board.Print(bonbonChoisi.Name, input, bonbonChoisi.Price, sommeRecue);
                        }
                        
                        if (coins == 0) //sorti du loop parce que coin == 0?
                        {
                            Board.Print("ANNULÉ", returned: sommeRecue);// si on entre 0,
                            isComplete = true;
                        }
                        else // Sorti du loop parce qu'on a assez de monnaie
                        {
                            // TRANSACTION COMPLETE
                            Board.Print("Prenez votre friandise...", input, bonbonChoisi.Price, sommeRecue, coins - bonbonChoisi.Price, bonbonChoisi.Name); // Final print
                            bonbonChoisi.Stock--; // retirer 1 bonbon de l'inventaire 
                            isComplete = true;
                        }
                    }
                } while (!isComplete);
                Console.WriteLine("\nAppuyez sur une touche pour acheter d'autre bonbon...");
                Console.ReadLine();
                Console.WriteLine("\n\n\n");
            }
        }

        public static Candy[] loadCandies() // Fonction qui retourne un array de Candy 
        {
            Candy[] candies; 
            Data dataManager = new Data();
            return dataManager.LoadCandies();
        }
        
        static int getSelection(int choix = 25) // retourne le choix de bonbon
        {
            Board.Print(); // Printer le board vierge
            
            int selection = 0;
            while (selection < 1 || selection > choix) // s'assurer que le choix soit entre 1 et 25
            {
                Console.Write("-> ");
                selection = int.Parse(Console.ReadLine());
            }
            return selection;
        }

        static Candy GetCandy(int choixBonbon) // retourne les informations du bonbon selectionne
        {
            Candy[] bonbon = loadCandies(); // Pour loader les bonbons
            return bonbon[choixBonbon]; //Et retourner le bonbon linker avec le choix de l'utilisateur
        } 

        static decimal GetCoin() // Fonction qui demande la monnaie
        {
            byte input;
            Console.WriteLine("[0] = Annuler");
            Console.WriteLine("[1] = 5c");
            Console.WriteLine("[2] = 10c");
            Console.WriteLine("[3] = 25c");
            Console.WriteLine("[4] = 1$");
            Console.WriteLine("[5] = 2$");
            Console.Write("-> ");
            input = Byte.Parse(Console.ReadLine());
            while (input > 5 || input < 0) // s'assure que le input soit entre 1 et 5 et redemande si ce nest pas le cas
            {
                Console.Write("->");
                input = Byte.Parse(Console.ReadLine());
            }

            switch (input) // input = montant
            { 
                default: // par defaut, aucune monnaie est entree
                    return 0;
              case 1:
                  return 0.05m;
              case 2:
                  return 0.1m;
              case 3:
                  return 0.25m;
              case 4:
                  return 1m;
              case 5:
                  return 2m;
              
            }

        }


    }
}