using System;
using Project;

namespace Projet 
{
    internal class Program
    {
        static void Main()
        {
            int input;
            decimal coins = 0;
            
            
            while (true)
            {
                input = getSelection(); // Demander le numero de bonbon
                Candy bonbonChoisi = GetCandy(input +1); // Enregistrer le bonbon choisi dans une variable de type Candy
                if (bonbonChoisi.Stock < 1) {
                    Board.Print( $"{bonbonChoisi.Name} VIDE!", selection:input); // Imprimer que le bonbon choisi est hors stock
                }
                else {
                    Board.Print( bonbonChoisi.Name, input, bonbonChoisi.Price);
                    while (bonbonChoisi.Price >= coins){
                        
                        coins += GetCoin(); // Demander d'ajouter de la monnaie jusqu'a ce que le montant demande soit atteint
                    }
                }
            }
        }

        public static Candy[] loadCandies() // Fonction qui retourne un array de Candy 
        {
            Candy[] candies; 
            Data dataManager = new Data();
            return dataManager.LoadCandies();
        }
        
        static int getSelection(int choix = 25)
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

        static Candy GetCandy(int choixBonbon)
        {
            Candy[] bonbon = loadCandies(); // Pour loader les bonbons
            return bonbon[choixBonbon]; //Et retourner le bonbon linker avec le choix de l'utilisateur
        }

        static decimal GetCoin()
        {
            byte input;
            Console.WriteLine("[0] = Annuler");
            Console.WriteLine("[1] = 5c");
            Console.WriteLine("[2] = 10c");
            Console.WriteLine("[3] = 25c");
            Console.WriteLine("[4] = 1$");
            Console.WriteLine("[5] = 2$");
            Console.Write("->");
            input = Byte.Parse(Console.ReadLine());
            while (input > 5 || input < 0)
            {
                Console.Write("->");
                input = Byte.Parse(Console.ReadLine());
            }

            switch (input) // input = montant
            {
              case  0:
                  break;
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

            return 0;
        }


    }
}