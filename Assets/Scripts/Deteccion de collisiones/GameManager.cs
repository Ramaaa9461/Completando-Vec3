using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Camera cam;
    List<SetRoom> stRooms;
    List<Planes[]> rooms;

    Vec3 midpointInAnotherRoom;
    bool inRoom;
    public bool pointInAnotherRoom;
    int cameraRoomNumber = 0;
    int planeCount = 0;

    void Awake()
    {
        instance = this;

        rooms = new List<Planes[]>();
        stRooms = new List<SetRoom>();
    }

    private void Start()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            stRooms[i].SetRoomMS(false);
        }
    }

    public void addRoom(Planes[] room, SetRoom roomParent)
    {
        rooms.Add(room);
        stRooms.Add(roomParent);
    }

    private void Update()
    {

        for (int i = 0; i < rooms.Count; i++)
        {
            for (int k = 0; k < rooms[i].Length; k++)
            {
                if (rooms[i][k].GetSide(cam.transform.position))
                {
                    planeCount++;

                    if (planeCount == rooms[i].Length)
                    {
                        cameraRoomNumber = i;
                        inRoom = true;
                        stRooms[i].SetRoomMS(true);
                    }
                }
                else
                {
                    //no esta, corto la ejecucion y paso a la sigueinte habitacion
                    planeCount = 0;
                    stRooms[i].SetRoomMS(false);
                    k = rooms[i].Length;
                }
            }
        }

        stRooms[SearchPointInRooms(midpointInAnotherRoom)].SetRoomMS(true);
    }

    public bool IsAPointInAnotherRoom(Vec3[] middlePoint)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int k = 0; k < middlePoint.Length; k++)
            {
                if (rooms[cameraRoomNumber][i].GetSide(middlePoint[k]))
                {
                    planeCount++;

                    if (planeCount == 6)
                    {
                        pointInAnotherRoom = false;
                        return false;
                    }
                }
                else
                {
                    planeCount = 0;
                    pointInAnotherRoom = true;
                    midpointInAnotherRoom = middlePoint[k];
                    return true;
                }
            }
        }

        return pointInAnotherRoom; // No deberia llegar nunca
    }

    int SearchPointInRooms(Vec3 point)
    {
        int numberRoom = 0;

        for (int i = 0; i < rooms.Count; i++)
        {
            for (int k = 0; k < rooms[i].Length; k++)
            {
                if (rooms[i][k].GetSide(point))
                {
                    planeCount++;

                    if (planeCount == rooms[i].Length)
                    {
                        numberRoom = i;
                    }
                }
                else
                {
                    planeCount = 0;
                    k = rooms[i].Length;
                }
            }
        }

        return numberRoom;
    }
}
