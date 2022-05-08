using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Camera cam;
    List<Planes[]> rooms;

    void Awake()
    {
        instance = this;

        rooms = new List<Planes[]>();
    }

    public void addRoom(Planes[] room)
    {
        rooms.Add(room);
    }

    
}
