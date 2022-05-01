using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPlanes : MonoBehaviour
{
    [SerializeField] List<GameObject> rooms;
    List<Planes> roomPlanes;

    List<MeshFilter> mf;
    List<Mesh> mesh;
    List<Vec3> vertx;

    private void Awake()
    {
        mf = new List<MeshFilter>();
        mesh = new List<Mesh>();
        vertx = new List<Vec3>();
        roomPlanes = new List<Planes>();
    }
    void Start()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            MeshCalculator(i);
            Debug.Log(i);
            mesh.Clear();
            vertx.Clear();
            mf.Clear();
        }
    }

    void MeshCalculator(int numberRoom)
    {
        for (int i = 0; i < rooms[numberRoom].transform.childCount; i++)
        {
            mf.Add(rooms[numberRoom].transform.GetChild(i).GetComponent<MeshFilter>());
        }

        for (int i = 0; i < mf.Count; i++)
        {
            mesh.Add(mf[i].sharedMesh);
        }
        for (int i = 0; i < mesh.Count; i++)
        {
            for (int k = 0; k < 8; k++)
            {
                vertx.Add(mesh[i].vertices[k]);
            }
        }
        int aux = 0;
        int vertxPerFace = 8;

        for (int i = 0; i < vertx.Count; i++)
        {
            Vec3 currentVertx = FromLocalToWolrd(vertx[i], rooms[numberRoom].transform.GetChild(aux).transform);
            vertx.RemoveAt(i);
            vertx.Insert(i, currentVertx);

            if (i == vertxPerFace)
            {
                aux++;
                vertxPerFace += 8;
            }
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

        Gizmos.color = Color.yellow;
        for (int i = 0; i < vertx.Count; i++)
        {
            Gizmos.DrawSphere(vertx[i], 0.2f);
        }


    }
}
