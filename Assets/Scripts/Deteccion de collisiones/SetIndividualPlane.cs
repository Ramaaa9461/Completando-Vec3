using CustomMath;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetIndividualPlane : MonoBehaviour
{
    Planes wallPlanes;

    [SerializeField] GameObject point;
    [SerializeField] [Range(0, 1)] int normalDirection;

    void Start()
    {
        MeshCalculator();
    }

    void MeshCalculator()
    {
        if (normalDirection == 0)
        {
            wallPlanes = new Planes(transform.forward, transform.position);
        }
        else
        {
            wallPlanes = new Planes(-transform.forward, transform.position);
        }

        GetComponentInParent<SetRoom>().AddPlaneToRoom(wallPlanes);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(wallPlanes.GetSide(point.transform.position), gameObject);
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Gizmos.DrawSphere(FromLocalToWolrd(wallPlanes.normal, transform) + (Vector3)wallPlanes.normal, 0.2f);

        //  Handles.ArrowHandleCap(0, transform.position, Quaternion.Euler(transform.position + (Vector3)wallPlanes.normal), .25f, EventType.Repaint);

        //if (!Application.isPlaying) return;

        //Quaternion rotation = Quaternion.LookRotation(transform.TransformDirection(wallPlanes.normal));

        //Matrix4x4 trs = Matrix4x4.TRS(transform.TransformPoint(wallPlanes.normal), rotation, Vector3.one);
        //Gizmos.matrix = trs;
        //Color32 color = Color.blue;
        //color.a = 125;
        //Gizmos.color = color;
        //Gizmos.DrawCube(Vector3.zero - new Vector3(transform.localScale.x, 0, transform.localScale.z), new Vector3(.0001f, 3, 5));
        //Gizmos.matrix = Matrix4x4.identity;
        //Gizmos.color = Color.white;

    }
#endif

    private Vector3 FromLocalToWolrd(Vector3 point, Transform transformRef) //Recibe un punto y tansform de un objeto
    {
        Vector3 result = Vector3.zero;

        result = new Vector3(point.x * transformRef.localScale.x, point.y * transformRef.localScale.y, point.z * transformRef.localScale.z); //Multiplica el punto por la escala

        result = transformRef.rotation * result; //Luego multiplica el resutado por la rotacion

        return result + transformRef.position; //El resutado le sumamos la posicion del objeto y retornamos las coordenadas en globales
    }

}

