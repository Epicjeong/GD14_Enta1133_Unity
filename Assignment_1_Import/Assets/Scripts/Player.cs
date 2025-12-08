using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.UI;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// The players class
    /// Proceeds through the players turn
    /// Stores some player specific values
    /// </summary>
    public class Player : MonoBehaviour
    {
        //The number the player rolled
        private int playerRoll;
        //The value of what the player has collected
        private int playerScore;
        //The pickaxes durability
        public int playerSidesLeft;
        //The durability restored by items
        int durabilityRestored;
        //The value you have obtained from gems
        int valueFromGems;
        //Egg
        int hasEgg;
        //The item the player gets from item rooms
        int itemGained;

        private TextMeshProUGUI displayDura;

        private void Start()
        {
            displayDura = GetComponent<TextMeshProUGUI>();
        }

        //The players turn
        internal void PlayerTurn(Player player, DiceRolls diceroller, System.Random random)
        {
            //Starts the dice roller aslong as you have durability left
            if (playerSidesLeft == 0)
            {
                //Debug.Log("As you are out of durability, you will now exit the mine");
                //playerRoll = 0;
                //endGame.PlayerWin(player, scoreKeep, map);
            }
            else
            {
                diceroller.RollDice(random);
                playerRoll = diceroller.GetDiceResult();
                int sidesUsed = playerRoll;
                playerSidesLeft = playerSidesLeft - sidesUsed;
                Debug.Log("You used " + sidesUsed + " of your durability, your pickaxe has " + playerSidesLeft + " more durability");
                //Puts breaks every now and again so the player has time to read
            }
        }

        //Keeps track of what items have been obtained
        Dictionary<string, int> inventory = new Dictionary<string, int>
        {
            {"Duct tape", 0 },
            {"Weird glue", 0 },
            {"Gem", 0 },
            {"Magnifying glass", 0 }
        };

        //Obtains items
        internal void GainItems(Player player)
        {
            //Randomizes which items are gained
            itemGained = Random.Range(1, 4);
            if (itemGained == 1)
            {
                //Duct tape heals durability
                inventory["Duct tape"]++;
            }
            else if (itemGained == 2)
            {
                //Weird glue heals durability but is more random
                inventory["Weird glue"]++;
            }
            else if (itemGained == 3)
            {
                //Gems adds more to total value of rocks
                inventory["Gem"]++;
                Gem gem = new Gem();
                //gem.ItemAction(player);
                valueFromGems = valueFromGems + gem.gemValue;
            }
            else if (itemGained == 4)
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
        internal int GetItemGained()
        {
            return itemGained;
        }
    }
}
