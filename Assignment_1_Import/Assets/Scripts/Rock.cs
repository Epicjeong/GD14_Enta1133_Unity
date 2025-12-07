using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GD14_1133_DiceGame_Jeong_Yuri
{
    /// <summary>
    /// The rocks class
    /// Sets the rocks health
    /// </summary>
    internal class Rock : MonoBehaviour
    {
        //Stores the rocks max hp
        private int rockMaxHealth;
        //Keeps track of how close the rock is to breaking
        private int rockHealth;
        void Start()
        {
            //Gets the rock hp

            int setRockHealth = Random.Range(10, 20);
            rockHealth = setRockHealth;
            rockMaxHealth = rockHealth;
        }

        internal void BreakRock(Player player)
        {
            rockHealth = rockHealth - player.GetPlayerRoll();
        }

        //Lets other classes get the rocks health
        internal int GetRockHealth()
        {
            return rockHealth;
        }
        //Lets other classes get the rocks max health
        internal int GetRockMaxHealth()
        {
            return rockMaxHealth;
        }
    }
}
