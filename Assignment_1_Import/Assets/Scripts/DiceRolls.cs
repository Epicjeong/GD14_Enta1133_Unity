using GD14_1133_DiceGame_Jeong_Yuri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    internal class DiceRolls
    {
        //The type of dice the player could roll
        int diceType;
        //The highest and lowest roll that can be rolled
        int minRoll = 1;
        int maxRoll;
        //Stores the result of the dice to add to the players score
        private int diceResult;

        //Rolls various dice once by creating an instance of Random, choosing from d6, d8, d12, and d20
        internal void RollDice(System.Random random)
        {

            //Gets the number the player chose
            diceType = random.Next(1, 4);
            int Roll;

            switch (diceType)
            {
                //Rolls a d6
                case 1:
                    maxRoll = 6;
                    Roll = random.Next(minRoll, maxRoll);
                    diceResult = Roll;
                    Debug.Log("The d6 rolled a " + diceResult);
                    break;

                //Rolls a d8
                case 2:
                    maxRoll = 8;
                    Roll = random.Next(minRoll, maxRoll);
                    diceResult = Roll;
                    Debug.Log("The d8 rolled a " + diceResult);
                    break;

                //Rolls a d12
                case 3:
                    maxRoll = 12;
                    Roll = random.Next(minRoll, maxRoll);
                    diceResult = Roll;
                    Debug.Log("The d12 rolled a " + diceResult);
                    break;

                //Rolls a d20
                case 4:
                    maxRoll = 20;
                    Roll = random.Next(minRoll, maxRoll);
                    diceResult = Roll;
                    Debug.Log("The d20 rolled a " + diceResult);
                    break;
            }
        }

        //Allows use of the dice result in other classes
        internal int GetDiceResult()
        {
            return diceResult;
        }
    }
}
