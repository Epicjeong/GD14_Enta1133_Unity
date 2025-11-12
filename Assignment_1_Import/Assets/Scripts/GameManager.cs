using GD14_1133_DiceGame_Jeong_Yuri;
using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using System.Collections.Specialized;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    Player player;
    Computer computer;
    DiceRolls diceRoller;
    System.Random random;
    //Keeps track of points
    int playerPoints = 0;
    int computerPoints = 0;
    [SerializeField] private Map gameMapPrefab;
    [SerializeField] private PlayerController PlayerPrefab; 
    private Map gameMap;
    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        player = new Player();
        random = new System.Random();
        computer = new Computer();
        diceRoller = new DiceRolls();

        UnityEngine.Debug.Log("oihdsfuhagh");
        transform.position = Vector3.zero;
        SetupMap();

    //    //Welcomes the player and creates and the instance of the player's class, which asks the players name
    //    Debug.Log("Welcome, I am Yuri Jeong writing this at September 23, 2025. I would ask your name, but I cant do that at the moment");
    //    player.PlayerTurn(diceRoller, random);

    //    //Starts the computer's turn and creates the instance of the computers class
    //    Debug.Log("Now it is the computer's turn, who will also choose from the same dice you chose form");
    //    computer.ComputerTurn(diceRoller, random);

    //    //Compares the rolls of the player and the computer
    //    int playerRoll = player.GetPlayerRoll();
    //    int computerRoll = computer.GetComputerRoll();
    //    //Player win
    //    if (playerRoll > computerRoll)
    //    {
    //        Debug.Log("You rolled " + playerRoll + ", which is greater than " + computerRoll + ", which the computer rolled so you get a point");
    //        playerPoints++;
    //        Debug.Log("You now have " + playerPoints + " points");
    //    }
    //    //Computer win
    //    if (playerRoll < computerRoll)
    //    {
    //        Debug.Log("The computer rolled " + computerRoll + ", which is greater than " + playerRoll + ", which you rolled so the computer gets a point");
    //        computerPoints++;
    //        Debug.Log("The computer now has " + computerPoints + " points");
    //    }
    //    //Tie
    //    if (playerRoll == computerRoll)
    //    {
    //        Debug.Log("As it is a tie, no points will be awarded");
    //    }

    //    //Displays the current points
    //    Debug.Log("The score is now " + playerPoints + " for you and " + computerPoints + " for the computer");
    //    Debug.Log("Goodbye");
    }

    private void SetupMap()
    {
        gameMap = Instantiate(gameMapPrefab, transform);
        gameMap.transform.position = Vector3.zero;
    }

    private void SpawnPlayer()
    {
        Debug.Log(" a ");
        var randomStartRoom = gameMap.layout[Random.Range(0, gameMap.roomPrefabs.Length), Random.Range(gameMap.roomPrefabs.Length, 0)];
        playerController = Instantiate(PlayerPrefab, transform);
        playerController.transform.position = new Vector3(randomStartRoom.transform.position.x, 0, randomStartRoom.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
