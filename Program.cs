using System;
using ConsoleAdventure.Project;
using ConsoleAdventure.Project.Controllers;

namespace ConsoleAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AskStartingQuestion();
        }

        public static void AskStartingQuestion()
        {
            Console.Clear();
            Console.WriteLine("ESCAPE FROM MONTGOMERY MANOR \n\nEvery town has a house at the end of the street, avoided by all and surrounded by legends. This is one of those houses. Montgomery Manor, named for its original owner Elizabeth Montgomery, who was executed for enchanting local townsfolk and kidnapping children. The locals burned her at the stake and for generations following, tales of witchcraft and murder have surrounded the house. Some say that the spirit of Elizabeth still haunts the mansion, patiently waiting for the return of the people who wronged her. \n\nDo you dare enter (y) yes or (n) no");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                case "yes":
                    new GameController().Run();
                    break;
                case "n":
                case "no":
                    Environment.Exit(0);
                    break;
                default:
                    System.Console.WriteLine("Invalid Option");
                    AskStartingQuestion();
                    break;
            }
        }
    }
}
