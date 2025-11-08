using GD14_1133_DiceGame_Jeong_Yuri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    internal class Player
    {
        //Keeps track of the player's name, dice rolls and the total of all dice rolls
        private string playerName;
        private int playerRoll;
        private int playerScore;

        internal void PlayerTurn(DiceRolls diceRoller, System.Random random)
        {
            //The player goes first so they get the instructions before the computer does anything
            Debug.Log("Either way, you should Prepare To Die, as you and a computer will roll either a d6, 8, 12, or 20");
            //Creates the instance of DiceRolls so the player can choose and roll their dice
            diceRoller.RollDice(random);

            //Adds the dice result to the players total rolls
            int diceresult = diceRoller.GetDiceResult();
            playerRoll = diceresult;
            playerScore = playerScore + diceresult;
            Debug.Log("Your total score is now " + playerScore);
        }

        //Allows other classes to get the players roll
        internal int GetPlayerRoll()
        {
            return playerRoll;
        }
        //Allows other classes to access the player's name
        internal string GetPlayerName()
        {
            return playerName;
        }
    }
}
