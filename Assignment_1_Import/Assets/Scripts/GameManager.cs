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
    [SerializeField] private Map gameMapPrefab;
    [SerializeField] private PlayerController playerPrefab;
    private Map gameMap;
    private PlayerController playerController;
    //Keeps track of points
    int playerPoints = 0;
    int computerPoints = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        player = new Player();
        random = new System.Random();
        computer = new Computer();
        diceRoller = new DiceRolls();

        //Zeroes the game managers position
        transform.position = Vector3.zero;
        SetupMap();
        SpawnPlayer();
        DontDestroyOnLoad(gameObject);
    }

    //Instantiates the map
    private void SetupMap()
    {
        gameMap = Instantiate(gameMapPrefab, transform);
        gameMap.transform.position = Vector3.zero;
        gameMap.MakeMap();
    }

    //Instantiates player
    private void SpawnPlayer()
    {
        //Gives player a random starting room
        var randomStartRoom = gameMap.layout[Random.Range(0, gameMap.roomPrefabs.Length), Random.Range(0, gameMap.roomPrefabs.Length)];
        playerController = Instantiate(playerPrefab, transform);
        playerController.transform.position = randomStartRoom.transform.position;
        playerController.Setup();
    }
}
