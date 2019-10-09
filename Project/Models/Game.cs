using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
    public class Game : IGame
    {

        public IRoom CurrentRoom { get; set; }
        public IPlayer CurrentPlayer { get; set; }

        //NOTE Make yo rooms here...
        public void Setup()
        {

            Room room1 = new Room("Room1", "You entered the first room");
            Room room2 = new Room("room2", "You have entered room 2");
            Room room3 = new Room("room3", "You have entered room 3");
            Room room4 = new Room("room4", "You have entered room 4");
            Room room5 = new Room("room5", "You have entered room 5");

            room1.AddExit(room2);
            room2.AddExit(room1);

            room2.AddExit(room3);
            room2.AddExit(room4);
            room4.AddExit(room2);
            room4.AddExit(room5);
            


            //Add Exits
        }
        public Game()
        {
            Player = new Player();
            Setup();
        }
    }
}