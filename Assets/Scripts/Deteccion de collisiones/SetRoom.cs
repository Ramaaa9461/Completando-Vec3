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

        if (count == 6)
        {
            sendRoomToGameManager();
        }
    }

    void sendRoomToGameManager()
    {
        GameManager.instance.addRoom(room);
    }

}
