using CustomMath;
using System.Collections.Generic;
using UnityEngine;

enum PlaneOrientation { Down = 0, Up = 1, Forward = 2, Back = 3, Right = 4, Left = 5 }

public class SetIndividualPlane : MonoBehaviour
{
    List<Planes> wallPlanes;

    MeshFilter mf;
    Mesh mesh;
    List<Vec3> vertx;

    [SerializeField][Range(0,1)] int normalOrientation = 0; //0 es normal negativa / 1 es normal positiva
    [SerializeField] PlaneOrientation planeOrientation = 0;

    Vec3 normal;
    Vec3 dir;
    private void Awake()
    {
        vertx = new List<Vec3>();
        wallPlanes = new List<Planes>();

        mf = transform.GetComponent<MeshFilter>();
        mesh = mf.sharedMesh;
    }
    void Start()
    {
        MeshCalculator();
    }

    void MeshCalculator()
    {
        switch (planeOrientation)
        {
            case PlaneOrientation.Down:

                dir = -transform.up;

                break;
            case PlaneOrientation.Up:
                
                dir = transform.up;
                
                break;
            case PlaneOrientation.Forward:

                dir = transform.forward;
                
                break;
            case PlaneOrientation.Back:

                dir = -transform.forward;

                break;
            case PlaneOrientation.Right:

                dir = transform.right;

                break;
            case PlaneOrientation.Left:

                dir = -transform.right;
                
                break;
        }
        if (normalOrientation == 0)
        {
            normal = dir;
        }
        else
        {
            normal = -dir;
        }

        wallPlanes.Add(new Planes(normal, dir));
       // GameManager.instance.addPlaneRoom(wallPlanes[(int)normalOrientation]);

    }

    private Vec3 FromLocalToWolrd(Vec3 point, Transform transformRef) //Transforma las coordenadas locales a globales
    {
        Vec3 result = Vector3.zero;

        result = new Vector3(point.x * transformRef.localScale.x, point.y * transformRef.localScale.y, point.z * transformRef.localScale.z);

        result = transformRef.rotation * result;

        return (Vector3)result + transformRef.position;

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(dir, 0.2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(normal, 0.2f);

        Gizmos.color = Color.red;
        for (int i = 0; i < wallPlanes.Count; i++)
        {
        Gizmos.DrawSphere(wallPlanes[i].normal, 0.2f);

        }
    }
#endif
}

