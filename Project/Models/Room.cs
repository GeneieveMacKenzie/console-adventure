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
            string template = $"\n{Description}";
            foreach(var exit in Exits)
            {
                template += "\n\t Go " + exit.Key + " to enter " + exit.Value.Name + Environment.NewLine;
            }
            foreach(var item in Items)
            {
                template += item.Name + "-" + item.Description;
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