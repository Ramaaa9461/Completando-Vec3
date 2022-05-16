using CustomMath;
using UnityEngine;

public class SetIndividualPlane : MonoBehaviour
{
    Planes wallPlanes;
    public int min;
    public int max;


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
            min = 2;
            max = 3;
        }

        GetComponentInParent<SetRoom>().AddPlaneToRoom(wallPlanes);
    }
}

