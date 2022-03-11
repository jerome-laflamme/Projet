using System;
using Project;

namespace Projet 
{
    internal class Program
    {
        static void Main()
        {
            
            Candy bonbonChoisi = GetCandy(getSelection()); // Enregistrer le bonbon choisi dans une variable de type Candy en demandant le numero du bonbon
            
            Console.WriteLine(bonbonChoisi.Stock);
            

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
            while (selection < 1 || selection > choix)
            {
                Console.Write("->");
                selection = int.Parse(Console.ReadLine());
            }
            return selection;
        }

        static Candy GetCandy(int choixBonbon)
        {
            Candy[] bonbon = loadCandies(); // Pour loader les bonbons
            return bonbon[choixBonbon]; //Et retourner le bonbon linker avec le choix de l'utilisateur
        }

        static float GetCoin()
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
                  return 0;
              case 1:
                  return 0.05f;
              case 2:
                  return 0.1f;
              case 3:
                  return 0.25f;
              case 4:
                  return 1f;
              case 5:
                  return 2f;
            }

            return 0;
        }


    }
}