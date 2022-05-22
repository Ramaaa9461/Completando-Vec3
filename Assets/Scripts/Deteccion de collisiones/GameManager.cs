using CustomMath;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Camera cam;
    List<SetRoom> stRooms;
    List<Planes[]> rooms;
  
    public List<int> visibleRooms;
    public bool pointInAnotherRoom;
    int cameraRoomNumber = 0;
    int planeCount = 0;

    Dictionary<int, List<int>> connectingRooms;

    void Awake()
    {
        instance = this;

        rooms = new List<Planes[]>();
        visibleRooms = new List<int>();

        stRooms = new List<SetRoom>();
        connectingRooms = new Dictionary<int, List<int>>();
    }

    private void Start()
    {
        RoomsConnectionTree();
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
                        stRooms[i].SetRoomMS(true);
                    }
                }
                else
                {
                    planeCount = 0;
                    stRooms[i].SetRoomMS(false);
                    k = rooms[i].Length;
                }
            }
        }
    }
    void RoomsConnectionTree()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            connectingRooms.Add(i, new List<int>());
        }

        connectingRooms[0].Add(8);
        connectingRooms[0].Add(9);

        connectingRooms[1].Add(3);
        connectingRooms[1].Add(5);

        connectingRooms[2].Add(5);
        connectingRooms[2].Add(7);

        connectingRooms[3].Add(1);
        connectingRooms[3].Add(11);

        connectingRooms[4].Add(10);
        connectingRooms[4].Add(6);

        connectingRooms[5].Add(1);
        connectingRooms[5].Add(2);

        connectingRooms[6].Add(4);
        connectingRooms[6].Add(9);

        connectingRooms[7].Add(2);
        connectingRooms[7].Add(8);

        connectingRooms[8].Add(7);
        connectingRooms[8].Add(0);

        connectingRooms[9].Add(6);
        connectingRooms[9].Add(0);

        connectingRooms[10].Add(4);
        connectingRooms[10].Add(11);

        connectingRooms[11].Add(3);
        connectingRooms[11].Add(10);
    }

    //public void IsAPointInAnotherRoom(Vec3[] middlePoint)
    //{
    //    for (int i = 0; i < 6; i++)
    //    {
    //        for (int k = 0; k < middlePoint.Length; k++)
    //        {
    //            if (!rooms[cameraRoomNumber][i].GetSide(middlePoint[k]))
    //            {  
    //                planeCount = 0;
    //                midpointInAnotherRoom.Add(middlePoint[k]);
    //            }
    //        }
    //    }
    //}

    public int IsAPointInTheSameRoom(Vec3 middlePoint)
    {
        planeCount = 0;
        visibleRooms.Add(cameraRoomNumber);

        for (int i = 0; i < 6; i++)
        {
            if (rooms[cameraRoomNumber][i].GetSide(middlePoint))
            {
                planeCount++;

                if (planeCount == 6)
                {
                    return 0;
                }

            }
            else
            {
                for (int k = 0; k < visibleRooms.Count; k++)
                {
                    for (int j = 0; j < connectingRooms[k].Count; j++)
                    {
                        int pointRoom = SearchPointInRooms(middlePoint);

                        if (pointRoom == -1)
                        {
                            continue;
                        }

                        stRooms[pointRoom].SetRoomMS(true);

                        if (visibleRooms.Contains(pointRoom))
                        {
                            visibleRooms.Add(pointRoom);
                        }

                        return 1;
                    }
                }
            }
        }
        return -1;
    }
    
    void door()
    {



    }

    int SearchPointInRooms(Vec3 point)
    {
        int numberRoom = -1;

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
