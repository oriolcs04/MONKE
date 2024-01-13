using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{


    public int openPath; // 1 top, 2 left, 3 right, 4 bottom

    void SpawnNewIsle()
    {
        switch (openPath)
        {
            case 1: // top

                break; 
            case 2: // left

                break;
            case 3: // right

                break; 
            case 4: // bottom

                break;
        }
    } 


    //List<Room> rooms = new List<Room>();    
    //List<Vector2> takenPos = new List<Vector2>();

    //float roomSizeX, roomSizeY;

    //public Room spawn;
    //public Room final;
    //public Room lvl1;
    //public Room lvl2;
    //public Room lvl3;
    //public Room lvl4;
    //public Room lvl5;
    //public Room lvl6;
    //public Room npc1;
    //public Room npc2;

    //public Room roomToPlace;

    

    //private void Start()
    //{
    //    roomSizeX = gameObject.GetComponent<Grid>().cellSize.x;
    //    roomSizeY = gameObject.GetComponent<Grid>().cellSize.y;

    //    // add the rooms to the rooms list
    //    rooms.Add(lvl1);
    //    rooms.Add(lvl2);
    //    rooms.Add(lvl3);
    //    rooms.Add(lvl4);
    //    rooms.Add(lvl5);
    //    rooms.Add(lvl6);
    //    rooms.Add(npc1);
    //    rooms.Add(npc2);

    //    takenPos.Add(new Vector2(0, 0));

    //    // generate the world
    //    DrawMap();
    //    DrawEnd();
    //}

    //private void DrawEnd()
    //{
    //    throw new NotImplementedException();
    //}

    //private void DrawMap()
    //{
    //    roomToPlace = rooms[UnityEngine.Random.Range(0, rooms.Count + 1)];

    //    if (CheckSuitableRandomRoom(roomToPlace))
    //    {

    //    }
    //}

    //private bool CheckSuitableRandomRoom(Room roomToPlace)
    //{
    //    return roomToPlace;
    //}
}
