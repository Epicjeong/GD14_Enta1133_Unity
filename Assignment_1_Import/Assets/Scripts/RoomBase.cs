using GD14_1133_DiceGame_Jeong_Yuri;
using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using UnityEngine;
using Random = System.Random;

public abstract class RoomBase : MonoBehaviour
{

    [SerializeField] private GameObject NorthEntry, EastEntry, SouthEntry, WestEntry;
    private RoomBase north, east, south, west;
    //Checks if the room is visited or not
    public bool hasVisited = false;

    //Description for the room
    internal abstract void RoomDescription();
    //When the room is entered
    internal virtual void OnRoomEntered()
    {
        hasVisited = true;
    }
    //When the room is searched
    internal abstract void OnRoomSearched();

    //When the room is exited
    internal abstract void OnRoomExit();

    public void SetRooms(RoomBase roomNorth, RoomBase roomEast, RoomBase roomSouth, RoomBase roomWest)
    {
        north = roomNorth;
        NorthEntry.SetActive(north == null);
        east = roomEast;
        EastEntry.SetActive(east == null);
        south = roomSouth;
        SouthEntry.SetActive(south == null);
        west = roomWest;
        WestEntry.SetActive(west == null);
    }
}
