using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Camera cam;
 
    struct Room
    {
        const int plansPerRoom = 8;
        int id;
    }

    void Awake()
    {
        instance = this;

       // rooms = new List<Planes>();

    }

    public void addPlaneRoom(Planes plane)
    {
        //rooms.Add(plane);
    }

    private void Update()
    {

   

    }



}
