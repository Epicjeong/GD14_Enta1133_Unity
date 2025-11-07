using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    internal class Computer
    {
        //Keeps track of the computer's dice rolls and the total of all dice rolls
        private int computerRoll;
        private int computerScore;
        internal void ComputerTurn(DiceRolls diceRoller, System.Random random)
        {
            //Creates the instance of diceroller so the computer can roll dice
            DiceRolls diceroller = new DiceRolls();
            diceRoller.RollDice(random);

            //Gets the dice result from the diceroller and adds it to the computers total rolls
            int diceresult = diceRoller.GetDiceResult();
            computerRoll = diceresult;
            computerScore = computerScore + computerRoll;
            Debug.Log("The Computer's total score is now " + computerScore);
        }

        //Allows other classes to get the computers roll
        internal int GetComputerRoll()
        {
            return computerRoll;
        }
    }
}
