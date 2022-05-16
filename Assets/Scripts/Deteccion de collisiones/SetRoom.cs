using CustomMath;
using UnityEngine;

public class SetRoom : MonoBehaviour
{
    Planes[] room = new Planes[6];
 
    int count = 0;

    public void AddPlaneToRoom(Planes planeToAdd)
    {
        room[count] = planeToAdd;
        count++;

        if (count == 5)
        {
            count = 0;
            sendRoomToGameManager();
        }
    }
    public void SetRoomMS(bool isEnable)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().enabled = isEnable; 
        }
    }

    void sendRoomToGameManager()
    {
        GameManager.instance.addRoom(room, this);
    }
}
