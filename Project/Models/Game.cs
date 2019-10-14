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

            Room room1 = new Room("Phantom Foyer", "You have entered the Phantom Foyer. Great white sheets are draped over the furniture. Everything seems to be covered in a layer of dust and cobwebs. You close the door behind you.");
            Room room2 = new Room("Lucifers Library", "You have entered Lucifers Library. Book shelves line the wall from floor to ceiling. Massive arm chairs, caked in a layer of dust, sit in front of the empty fireplace. A table sits between the two chairs, and upon the table sits a crystal ball.");
            Room room3 = new Room("Goulish Gallery", "You have entered the Goulish Gallery. It is a long corridor with paintings dotting the walls. You notice that the eyes in the paintings are looking at you. As you begin walking down the long hallway you begin to see ghostly appartitions floating in and out of the paintings. There are no exits to be seen.\n");
            Room room4 = new Room("Kursed Kitchen", "You have entered the Cursed Kitchen. You can see the same layer of dust settled on the marble countertops. There is a deep sink, full of rusted pots and pans. An assortment of dried herbs, undoubtedly stale, hanging from the cieling.  A large butcher block sits in the middle of the room, the knives still protruding from the wood. As you begin to take a step further, the knives in the butcher block begin to glow and rise into the air. With a sudden swish, the knives slice you to ribbons. \n\n\t\tGAME OVER");
            Room room5 = new Room("Torture Chamber", "You have entered what appears to be a torcher chamber. A Lone torch dimly lights the room. you can see old chains hanging from the walls on your left. At the center of the room hangs a cage holding a skeleton whose legs hang lazily off the edge. As you look to your right, you can see a pair of fierce glowing red eyes. Before you can manage a scream, the werewolf lunges at you and grabs you around the throat and with a quick shake and a snap. You become his meal. \n\n\t\tGAME OVER");
            Room room6 = new Room("Elizabeths Quarters", "You enter what looks to be sleeping chambers. A large portrait of a woman hangs above the bed. She looks oddly familiar and as you realize you slowly look down at the crystal ball and drop it at your feet. The glass shatters and you hear a scream and a ghost fly out of the broken remnants. You have succesfully freed Elizabeth Montgomery from a curse that was keeping locked in the mansion.\n\n\t\tYOU WIN!!");



            room1.Exits.Add("east", room2);
            room2.Exits.Add("west", room1);
            room2.Exits.Add("south", room3);
            room3.Exits.Add("north", room2);
            room3.Exits.Add("west", room5);
            room3.Exits.Add("east", room4);
            room3.Exits.Add("south", room6);

            Item item1 = new Item("crystal ball", "This will help you find the exit you seek.");

            room2.Items.Add(item1);

            CurrentRoom = room1;

        }

        public Game()
        {
            CurrentPlayer = new Player();
            Setup();
        }
    }
}