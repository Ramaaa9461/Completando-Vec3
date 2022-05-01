using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetIndividualPlane : MonoBehaviour
{
    List<Planes> roomPlanes;

    MeshFilter mf;
    Mesh mesh;
    List<Vec3> vertx;

    enum PlaneOrientation { Down = 4, Up = 1, Forward = 5, Back = 7, Right = 6, Left = 0 }
    [SerializeField] PlaneOrientation planeOrientation = 0;
    //2, 3 tmb es arriba

    private void Awake()
    {
        vertx = new List<Vec3>();
        roomPlanes = new List<Planes>();

        mf = transform.GetComponent<MeshFilter>();
        mesh = mf.sharedMesh;
    }
    void Start()
    {
        MeshCalculator();
    }

    void MeshCalculator()
    {
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            vertx.Add(FromLocalToWolrd(mesh.vertices[i], transform));
        }

        for (int i = 0; i < vertx.Count; i += 3)
        {
            roomPlanes.Add(new Planes(vertx[i], vertx[i + 1], vertx[i + 2]));
        }

    }

    private Vec3 FromLocalToWolrd(Vec3 point, Transform transformRef) //Transforma las coordenadas locales a globales
    {
        Vector3 result = Vector3.zero;

        result = new Vector3(point.x * transformRef.localScale.x, point.y * transformRef.localScale.y, point.z * transformRef.localScale.z);

        result = transformRef.localRotation * result;

        return result + transformRef.position;

    }



    private void OnDrawGizmos()
    {
        if (vertx == null)
        {
            return;
        }

        Handles.color = Color.blue;
        Gizmos.color = Color.yellow;

        Handles.ArrowHandleCap(0, roomPlanes[(int)planeOrientation].normal, Quaternion.LookRotation(roomPlanes[(int)planeOrientation].normal), .3f, EventType.Repaint);

        for (int k = 0; k < vertx.Count; k++)
        {
            Gizmos.DrawSphere(vertx[k], 0.05f);
        }

        //Gizmos.DrawSphere(roomPlanes[1].normal, .2f);

    }
}

