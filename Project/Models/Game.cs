using System;
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

            Room room1 = new Room("Phantom Foyer", "You have entered the Phantom Foyer. The walls and furniture are draped in cobwebs and hidden behind thick layers of dust. There are two doors, identical in appearance, one to the east and one to the west.");
            Room room6 = new Room("Lucifers Library", "You have entered Lucifers Library. You see bookshelves lining the walls with books haphazourdly strewn about the shelves.");
            Room room2 = new Room("Goulish Gallery", "You have entered the Goulish Gallery. ");
            Room room3 = new Room("Cursed Kitchen", "You have entered room 3");
            Room room4 = new Room("Chilling Chamber", "You have entered room 4");
            Room room5 = new Room("room5", "You have entered room 5");

            //the way out is just ahead, dont be scared to look under the bed

            room1.Exits.Add("east", room2);
            room1.Exits.Add("west", room6); //winning room
            room2.Exits.Add("west", room1);
            room2.Exits.Add("south", room3);
            room3.Exits.Add("north", room2);
            room3.Exits.Add("west", room5);
            room3.Exits.Add("east", room4);

            Item item1 = new Item("Crystal Ball", "Testing description");
            Item protonpack = new Item("proton pack", "The Proton Pack is an energy weapon used for weakening ghosts and aiding in capturing them.");

            room1.Items.Add(protonpack);
            room3.Items.Add(item1);
            room4.Items.Add(item1);
            room5.Items.Add(item1);
            CurrentRoom = room1;

        }

        public Game()
        {
            CurrentPlayer = new Player();
            Setup();
        }
    }
}