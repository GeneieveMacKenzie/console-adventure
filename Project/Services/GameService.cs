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
            if (_game.CurrentRoom.Name == "Goulish Gallery")
            {
                Messages.Add(_game.CurrentRoom.GetTemplate3());
                return;
            }
            else
            {
                Messages.Add(_game.CurrentRoom.GetTemplate());
                return;
            }

   
        }
        public void Help()
        {
            Messages.Add("\n Go - Choose a direction for the room you want to enter \n Take Item - Add the item into your inventory \n Use Item - Use the item and remove it from your inventory \n Quit - Exit the game.");

        }

        public void Inventory()
        {
                if (_game.CurrentPlayer.Inventory.Count == 0)
                {
                    Messages.Add("You have no items in your inventory");
                    return;
                }
            foreach (Item item in _game.CurrentPlayer.Inventory)
            {
                Messages.Add($"\n {item.Name}: {item.Description}");
            }
        }

        public void Look()
        {
            if (_game.CurrentRoom.Name == "Goulish Gallery")
            {
                Messages.Add(_game.CurrentRoom.GetTemplate3());
                return;
            }
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
            Messages.Add($"Welcome {playerName},");
            Messages.Add(_game.CurrentRoom.GetTemplate());
        }
        ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
        public void TakeItem(string itemName)
        {
            if (_game.CurrentRoom.Items.Count == 0)
            {
                Messages.Add("no items to pick up");
                return;
            }
            foreach (Item item in _game.CurrentRoom.Items)
            {
                if (item.Name == itemName)
                {
                    Messages.Add($"{itemName} has been added to your inventory");
                    _game.CurrentPlayer.Inventory.Add(item);
                    _game.CurrentRoom.Items.Remove(item);//fix me
                    return;
                }
                else
                {
                    Messages.Add("item not available to take");
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
            if(_game.CurrentPlayer.Inventory.Count == 0)
            {
                Messages.Add("You have no items in your inventory");
                return;
            }
            foreach (Item item in _game.CurrentPlayer.Inventory)
            {
                if (item.Name == itemName && _game.CurrentRoom.Name == "Goulish Gallery")
                {
                    Messages.Add(_game.CurrentRoom.GetTemplate2());
                    _game.CurrentRoom.Items.Remove(item);
                    return;
                }
                else if (item.Name != itemName)
                {
                    Messages.Add("That is not a valid item in your inventory");
                    return;
                }
                    Messages.Add("A face appears in the crystal ball and in a loud screech you hear 'I am no help to you here'.");
                    return; 
            }

        }
    }
}
