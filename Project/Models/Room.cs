using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
    public class Room : IRoom
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, IRoom> Exits { get; set; }

        public IRoom Go(string direction)
        {
            if(Exits.ContainsKey(direction))
            {
                return Exits[direction];
            }
            return this;
        }


        public string GetTemplate()
        {
            string template = $"\n{Description}\n";
            foreach(var exit in Exits)
            {
                template += "\n\t\t Go " + exit.Key + " to enter " + exit.Value.Name + Environment.NewLine + "\n";
            }
            foreach(var item in Items)
            {
                template += "\n" + item.Name + ": " + item.Description;
            }
            return template;
            

        }

        public string GetTemplate3()
        {
            string template = $"\n{Description}\n";
            return template;
        }

        public string GetTemplate2()
        {
            string template = "Suddenly doors appear on each wall in the gallery and you hear a sound coming from the crystal ball. 'North, East, South, West. I will not say which one is best but I will tell thee, to the North is what you have seen. Going east could get scary and west will surely be hairy. Mark my words, I cannot deny that if you go south you'll most certainly die.' \n\n";
            foreach(var exit in Exits)
            {
                template += "\n\t Go " + exit.Key + " to enter " + exit.Value.Name + Environment.NewLine;
            }

            return template;
        }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Exits = new Dictionary<string, IRoom>();
        }
    }
}