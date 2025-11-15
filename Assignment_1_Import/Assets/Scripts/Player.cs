using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// The players class
    /// Proceeds through the players turn
    /// Stores some player specific values
    /// </summary>
    internal class Player
    {
        //The number of sides the player starts with
        int startingSides;
        //The number the player rolled
        private int playerRoll;
        //The value of what the player has collected
        private int playerScore;
        //The pickaxes durability
        private int playerSidesLeft;
        //The durability restored by items
        int durabilityRestored;
        //The value you have obtained from gems
        int valueFromGems;
        //Egg
        int hasEgg;

        //Sets the amount of durability the player starts with
        internal void SetPlayerSides()
        {
            //The inventory is reset here as the player would need to set the durability at the start of the loop anyways
            inventory["Duct tape"] = 0;
            inventory["Weird glue"] = 0;
            inventory["Gem"] = 0;
            inventory["Magnifying glass"] = 0;
            valueFromGems = 0;
            hasEgg = 0;
            startingSides = 0;

            while (startingSides < 30)
            {
                int.TryParse(Console.ReadLine(), out startingSides);
                if (startingSides < 30)
                {
                    Debug.Log("Please input a valid option");
                }
            }
            playerSidesLeft = startingSides;
        }

        //The players turn
        //internal void PlayerTurn(Player player, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        //{
        //    //Starts the dice roller aslong as you have durability left
        //    if ( playerSidesLeft == 0)
        //    {
        //        Debug.Log("As you are out of durability, you will now exit the mine");
        //        playerRoll = 0;
        //        endGame.PlayerWin(player, scoreKeep, map);
        //    }
        //    else
        //    {
        //        diceroller.RollDice(player);
        //        playerRoll = diceroller.GetDiceResult();
        //        int sidesUsed = diceroller.GetSidesUsed();
        //        playerSidesLeft = playerSidesLeft - sidesUsed;
        //        Debug.Log("You used " + sidesUsed + " of your durability, your pickaxe has " + playerSidesLeft + " more durability");
        //        //Puts breaks every now and again so the player has time to read
        //        Debug.Log("Press enter to continue");
        //        Console.ReadLine();
        //    }
        //}

        //Keeps track of what items have been obtained
        Dictionary<string, int> inventory = new Dictionary<string, int>
        {
            {"Duct tape", 0 },
            {"Weird glue", 0 },
            {"Gem", 0 },
            {"Magnifying glass", 0 }
        };

        //Obtains items
        internal void GainItems(Player player, Random random, DiceRolls diceroller,  Map map)
        {
            //Randomizes which items are gained
            int randomItem = random.Next(1, 4);
            if (randomItem == 1)
            {
                //Duct tape heals durability
                Debug.Log("You got duct tape, it can restore some of your pickaxes durability");
                inventory["Duct tape"]++;
                Debug.Log("You now have " + inventory["Duct tape"] + " duct tape");
            }
            else if (randomItem == 2)
            {
                //Weird glue heals durability but is more random
                Debug.Log("You got weird glue, it can restore a more random of your pickaxes durability");
                inventory["Weird glue"]++;
                Debug.Log("You now have " + inventory["Weird glue"] + " weird glue");
            }
            else if (randomItem == 3)
            {
                //Gems adds more to total value of rocks
                Debug.Log("You got a gem, which adds to your total rock value");
                inventory["Gem"]++;
                Gem gem = new Gem();
                gem.ItemAction(player, random, diceroller, map);
                Debug.Log("The gem was worth " + gem.gemValue);
                valueFromGems = valueFromGems + gem.gemValue;
                Debug.Log("You now have " + valueFromGems + " value from gems");
                Debug.Log("You now have " + inventory["Gem"] + " gem");
            }
            else if (randomItem == 4)
            {
                //Magnifying glass resets a room as if it has not been used
                Debug.Log("You got a magnifying glass, which finds more items or rocks depending on the room");
                inventory["Magnifying glass"]++;
                Debug.Log("You now have " + inventory["Magnifying glass"] + " magnifying glass");
            }
        }

        //Uses the items the player has in the inventory
        //internal void UseInventory(Player player, Rock rock, Random random, DiceRolls diceroller, ScoreKeeper scoreKeep, EndGame endGame, Map map)
        //{
        //    int inventoryChoice;
        //    Debug.Log("You currently have " + inventory["Duct tape"] + " duct tape, " + inventory["Weird glue"] + " weird glue and " + inventory["Magnifying glass"] + " magnifying glass");
        //    Debug.Log("You have " + inventory["Gem"] + " gem that add to $" + valueFromGems + " in additional value");
        //    Debug.Log("Press 1 to use duct tape (if any), 2 for weird glue (if any) and anything else to exit inventory");
        //    //This prevents using the magnifying glass while mining and the pandoras box that would open
        //    if (rock.GetRockHealth() <= 0)
        //    {
        //        Debug.Log("Or if you have a magnifying glass and not currently mining, press 3 to use a magnifying glass");
        //    }
        //    int.TryParse(Console.ReadLine(), out inventoryChoice);
        //    if (inventory["Duct tape"] > 0 || inventory["Weird glue"] > 0)
        //    {
        //        //Use duct tape
        //        if (inventoryChoice == 1 && inventory["Duct tape"] > 0)
        //        {
        //            DuraItem selectedItem;
        //            selectedItem = new DuctTape();
        //            selectedItem.ItemAction(player, rock, random, diceroller, scoreKeep, endGame, map);
        //            durabilityRestored = selectedItem.duraRestored;
        //            inventory["Duct tape"]--;
        //            Debug.Log("You have " + inventory["Duct tape"] + " duct tape left");
        //        }
        //        //Use weird glue
        //        else if (inventoryChoice == 2 && inventory["Weird glue"] > 0)
        //        {
        //            DuraItem selectedItem;
        //            selectedItem = new WeirdGlue();
        //            selectedItem.ItemAction(player, rock, random, diceroller, scoreKeep, endGame, map);
        //            durabilityRestored = selectedItem.duraRestored;
        //            inventory["Weird glue"]--;
        //            Debug.Log("You have " + inventory["Weird glue"] + " weird glue left");
        //        }
        //        playerSidesLeft = playerSidesLeft + durabilityRestored;
        //        Debug.Log("Your pickaxe restored " + durabilityRestored + " durability");
        //        Debug.Log("Your pickaxe now has " + playerSidesLeft + " durability");
        //    }
        //    //Use magnifying glass
        //    if (inventoryChoice == 3 && inventory["Magnifying glass"] > 0 && rock.GetRockHealth() <= 0)
        //    {
        //        inventory["Magnifying glass"]--;
        //        Debug.Log("You have " + inventory["Magnifying glass"] + " magnifying glass left");
        //        UtilItem selectedItem;
        //        selectedItem = new MagnifyGlass();
        //        selectedItem.ItemAction(player, rock, random, diceroller, scoreKeep, endGame, map);
        //    }
            
        //}

        //Lets other classes get the players roll
        internal int GetPlayerRoll()
        {
            return playerRoll;
        }
        //Lets other classes get the amount of sides the player has left
        internal int GetPlayerSidesLeft()
        {
            return playerSidesLeft;
        }
        //Lets other classes get the players score
        internal int GetPlayerScore()
        {
            return playerScore;
        }
        //Lets other classes get the value from gems
        internal int GetValueFromGems()
        {
            return valueFromGems;
        }
        internal int GetHasEgg()
        {
            return hasEgg;
        }
        internal int SetHasEgg()
        {
            hasEgg = 1;
            return hasEgg;
        }
    }
}
