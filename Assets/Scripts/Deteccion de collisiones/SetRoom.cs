using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRoom : MonoBehaviour
{
    Planes[] room = new Planes[6];
    int count = 0;
   public void AddPlaneToRoom(Planes planeToAdd)
    {
        room[count] = planeToAdd;
        count++;
    }

    void sendRoomToGameManager()
    {
        if (count == 6)
        {
            GameManager.instance.addRoom(room);
        }
    }

}
