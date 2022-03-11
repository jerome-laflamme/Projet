using System;
using Project;

namespace Projet 
{
    internal class Program
    {
        static void Main()
        {
            Candy[] bonbon = loadCandies(); // Pour loader les bonbons
            
            // EXEMPLE POUR CALLER Console.WriteLine(bonbon[1].Name);
            getSelection(); // Demander quel bonbon tu veux
            getCandy();

        }

        public static Candy[] loadCandies()
        {
            Candy[] candies;
            Data dataManager = new Data(); 
            candies = dataManager.LoadCandies();
            return candies;
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

        static void getCandy()
        {
            return;
        }
        
        
    }
}