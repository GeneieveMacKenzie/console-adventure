using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
    public class GameService : IGameService
    {
        private IGame _game { get; set; }

        public List<string> Messages { get; set; }
        public GameService()
        {
            _game = new Game();
            Messages = new List<string>();
        }
        public void Go(string direction)
        {
            string from = _game.CurrentRoom.Name;
            _game.CurrentRoom = _game.CurrentRoom.Go(direction);
            string to = _game.CurrentRoom.Name;
            if (from == to)
            {
                Messages.Add("Invalid direction");
                return;
            }
            Messages.Add($"Welcome to {to}");
            Messages.Add(_game.CurrentRoom.GetTemplate());

        }
        public void Help()
        {
            Messages.Add("\n Go - This will allow you to choose a direction for the room you want to enter \n Take Item - This will add the item into your inventory \n Use Item - This will use the item and remove it from your inventory \n Quit - This will exit the game.");

        }

        public void Inventory()
        {
            foreach(Item item in _game.CurrentPlayer.Inventory)
            {
                if(_game.CurrentPlayer.Inventory.Count == 0)
                {
                    Messages.Add("You have no items in your inventory");
                }
            Messages.Add($"Inventory: {item}");
            }
        }

        public void Look()
        {
            Messages.Add(_game.CurrentRoom.GetTemplate());
        }

        public void Quit()
        {
            Environment.Exit(0);
        }
        ///<summary>
        ///Restarts the game 
        ///</summary>
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void Setup(string playerName)
        {
            Messages.Add($"Welcome to {_game.CurrentPlayer.Name}");
            Messages.Add(_game.CurrentRoom.GetTemplate());
        }
        ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
        public void TakeItem(string itemName)
        {
            foreach(Item item in _game.CurrentRoom.Items)
            {
                if (item.Name == itemName)
                {
                    Messages.Add($"{itemName} has been added to your inventory");
                    _game.CurrentPlayer.Inventory.Add(item);
                    _game.CurrentRoom.Items.Remove(item);
                }
                else
                {
                Messages.Add("No items available");
                Messages.Add(itemName);
                Messages.Add(item.Name);
                }
            }
        }
        ///<summary>
        ///No need to Pass a room since Items can only be used in the CurrentRoom
        ///Make sure you validate the item is in the room or player inventory before
        ///being able to use the item
        ///</summary>
        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}
