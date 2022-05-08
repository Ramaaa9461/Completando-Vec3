using CustomMath;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetIndividualPlane : MonoBehaviour
{
    Planes wallPlanes;
    void Start()
    {
        setPlane();
    }
    void setPlane()
    {
        wallPlanes = new Planes(transform.forward, transform.position);

        GetComponentInParent<SetRoom>().AddPlaneToRoom(wallPlanes);
    }
}

