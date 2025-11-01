using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// Actually starts the game
    /// Gets the players name
    /// Instantiates the classes used throughout the game
    /// </summary>
    internal class GameController : MonoBehaviour
    {
        //Keeps track of player name
        private string playerName;
        //Readies the custom classes that are used in other classes
        //Not in the order they appear but it looks more satisfying this way
        Map map;
        //Rock rock;
        //Random random;
        Player player;
        //EndGame endGame;
        DiceRolls diceroller;
        //ScoreKeeper scoreKeep;

        public void Start()
        {
            //Welcomes the player and creates and the instance of the players class, which asks the players name
            Debug.Log("Welcome, I am Yuri Jeong writing this at October 17, 2025. What is your name?");
            StartGame();
        }


        internal void StartGame()
        {
            //Instantiates every class that is used across classes
            player = new Player();
            //endGame = new EndGame();
            //rock = new Rock();
           // diceroller = new DiceRolls();
           // scoreKeep = new ScoreKeeper();
            map = new Map();
            //random = new System.Random();
            //Asks the players name
            //playerName = Console.ReadLine();
            //Funny secret to people who decide not to input anything
            if (playerName == "")
            {
                Debug.Log("Well its rude to judge a name, or a lack of one at that matter");
            }
            //Explains rules and asks if the player wants to play
            Debug.Log("Hello " + playerName + ", let me explain the game that will be played");
            Debug.Log("");
            Debug.Log("You will be placed into a randomly generated mine with a pickaxe that has a certain amount of durability");
            Debug.Log("The mine is a grid, each square on that grid can be a treasure room or an item room");
            Debug.Log("In an item room, you could find items that help you in your mining, like duct tape to restore durability");
            Debug.Log("In a treasure room, you will find a cool rock that has value to it, and commence the mining");
            Debug.Log("");
            Debug.Log("When mining, the rock has a random amount of health that you must deplete by using your durability");
            Debug.Log("You can choose how much durability to use at a time, then the amount of durability you chose will roll a dice");
            Debug.Log("The durability you chose wil be the highest possible roll of the dice, so if you chose 7 the max roll is 7");
            Debug.Log("Using items found by searching item rooms, you can increase the durability of your pickaxe");
            Debug.Log("At the start of a swing, you can use 1 item if you have any, so dont worry about saving them up");
            Debug.Log("");
            Debug.Log("Once the rocks health is depleted, you will gain the rocks max health as value in $");
            Debug.Log("When you leave the mine, your total value will be displayed and the game will end");
            Debug.Log("Your end goal is to exit the mine with at least #30 in rocks");
            Debug.Log("If you ever reach 0 durability, you will automatically leave the mine and end the game");
            Debug.Log("Now with that explained, are you ready to Randominez? Please enter y for yes, n for no");
            map.Start();
            //AskToPlay playmygame = new AskToPlay();
            //playmygame.PlayMyGame(map, player, rock, random, diceroller, scoreKeep, endGame);
            //Gonna say goodbye
            Debug.Log("Goodbye");
        }
        //Lets other classes get the players name
        internal string GetPlayerName()
        {
            Debug.Log(playerName);
            return playerName;
        }
    }
}
