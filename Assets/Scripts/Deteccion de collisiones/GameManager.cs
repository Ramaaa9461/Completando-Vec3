using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Camera cam;
    List<Planes[]> planes;

    void Awake()
    {
        instance = this;

        planes = new List<Planes[]>();

    }

    public void addRoom(Planes[] room)
    {
        planes.Add(room);
    }





}
