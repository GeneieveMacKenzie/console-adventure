using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

    public class GameController : IGameController
    {
        private GameService _gameService = new GameService();

        //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
        public bool playing = true;
        public void Run()
        {
            Console.Clear();
            InitialSetup();
            while(playing)
            {
                Print();
                GetUserInput();
            }
        }

        public void InitialSetup()
        {
            System.Console.WriteLine("What is your player name?");
            _gameService.Setup(Console.ReadLine());
        }

        //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
        public void GetUserInput()
        {
            Console.WriteLine("\n\n\nWhat would you like to do? \n(h)help, (l)look, (g)go, (t)take item, i (inventory), (u) use item, (q)Quit,");
            string input = Console.ReadLine().ToLower() + " ";
            string command = input.Substring(0, input.IndexOf(" "));
            string option = input.Substring(input.IndexOf(" ") + 1).Trim();
            switch(command){
                case "h":
                case "help":
                    _gameService.Help();
                    break;
                case "l":
                case "look":
                    _gameService.Look();
                    break;
                case "go":
                case "g":
                    Console.WriteLine("Which direction do you want to go?");
                    _gameService.Go(option);
                    break;
                case "t":
                case "take":
                    _gameService.TakeItem(option);
                    break;
                case "u":
                case "use":
                    _gameService.UseItem(option);
                    break;
                case "q":
                case "quit":
                    _gameService.Quit();
                    break;
                case "i":
                case "inventory":
                    _gameService.Inventory();
                    break;
                default:
                    Console.WriteLine("That is not a valid option");
                    GetUserInput();
                    break;
            }
            //NOTE this will take the user input and parse it into a command and option.
            //IE: take silver key => command = "take" option = "silver key"

        }

        //NOTE this should print your messages for the game.
        private void Print()
        {
            Console.Clear();
            foreach (string message in _gameService.Messages)
            {
                Console.WriteLine(message);
            }
            _gameService.Messages.Clear();
        }
    }
}