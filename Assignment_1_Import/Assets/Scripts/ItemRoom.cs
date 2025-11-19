using GD14_1133_DiceGame_Jeong_Yuri;
using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using System;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class ItemRoom : RoomBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Description for the room
    internal override void RoomDescription()
    {
        if (hasVisited == false)
        {
            Debug.Log("Its a room with some items in it");
        }
        //If already searched
        else
        {
            Debug.Log("An empty room");
        }
    }
    //When the room is entered
    internal override void OnRoomEntered()
    {
        hasVisited = true;
        RoomDescription();
    }
    //When the room is searched
    internal override void OnRoomSearched()
    {
        Debug.Log("There are some items laying around");
        Debug.Log("Sadly, you cant pick them up yet");
    }
    //When the room is exited
    internal override void OnRoomExit()
    {

    }
}
