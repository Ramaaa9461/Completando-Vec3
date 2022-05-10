using CustomMath;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetIndividualPlane : MonoBehaviour
{
    Planes wallPlanes;
    [SerializeField] int min;
    [SerializeField] int max;


    void Start()
    {
        setPlane();
    }
    void setPlane()
    {
        wallPlanes = new Planes(transform.forward, transform.position);

        if (transform.name == "Rigth" || transform.name == "Forward")
        {
      //Chequear valores donde deberia estar la puerta
        }

        GetComponentInParent<SetRoom>().AddPlaneToRoom(wallPlanes);
    }
}

