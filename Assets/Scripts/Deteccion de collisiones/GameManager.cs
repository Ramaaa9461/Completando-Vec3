using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Camera cam;
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
    }

    public void addRoom(Planes[] room)
    {
        rooms.Add(room);
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
                        return true;
                    }
                }
                else
                {
                    planeCount = 0;
                    pointInAnotherRoom = true;
                    midpointInAnotherRoom = middlePoint[k];
                    return false;
                }
            }
        }

        return pointInAnotherRoom; // No deberia llegar nunca
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
                    }
                }
                else
                {
                    //no esta, corto la ejecucion y paso a la sigueinte habitacion
                    planeCount = 0;
                    k = rooms[i].Length;
                }
            }
        }

        if (inRoom)
        {
            Debug.Log(cameraRoomNumber);
        }
        if (pointInAnotherRoom)
        {
            Debug.Log(midpointInAnotherRoom);

        }

    }
}
