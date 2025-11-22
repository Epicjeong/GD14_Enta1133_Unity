using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// Map created and radomized here
    /// </summary>
    internal class Map : MonoBehaviour
    {
        const int x = 3, y = 3;
        //Sets size of the map
        [SerializeField] public RoomBase[] roomPrefabs;
        [SerializeField] private float roomSize = 1;
        //Initial initialization of rooms on a map
        public RoomBase[,] layout;
        //bool exploring;
        //private Room currentRoom;

        //Keeps track of the amount of unique rooms visited
        int roomsUsed;
        public void Start()
        {
            
        }

        public void MakeMap()
        {
            layout = new RoomBase[x, y];
           
            for (int i = 0; i < x; i++)
            {
                
                for (int j = 0; j < y; j++)
                {
                    Vector3 coords = new Vector3(i * roomSize, 0, j * roomSize);
                    var roomInstance = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], transform);
                    roomInstance.transform.position = coords;
                    layout[i, j] = roomInstance;
                }
            }


            //Link rooms together so you can move between them
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    RoomBase currentRoom = layout[i, j];
                    RoomBase north = null, east = null, south = null, west = null;
                    //Links the room to the north
                    if (j > 0)
                    {
                        north = layout[i, j - 1];
                    }
                    //Links east room
                    if (i < 2)
                    {
                        east = layout[i + 1, j];
                    }
                    //Links south room
                    if (j < 2)
                    {
                        south = layout[i, j + 1];
                    }
                    //Links west room
                    if (i > 0)
                    {
                        west = layout[i - 1, j];
                    }
                    currentRoom.SetRooms(north, east, south, west);
                }
            }
        }
    }
}
