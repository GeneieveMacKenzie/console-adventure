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
            Console.WriteLine("Welcome to my game, Do you want to play (y) yes or (n) no");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    new GameController().Run();
                    break;
                case "n":
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
