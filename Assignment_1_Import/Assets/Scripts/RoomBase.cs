using UnityEngine;

public class RoomBase : MonoBehaviour
{

    [SerializeField] private GameObject NorthEntry, EastEntry, SouthEntry, WestEntry;
    private RoomBase north, east, south, west;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
