using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MathDebbuger;
using CustomMath;

public class Ejercicios : MonoBehaviour
{

    [SerializeField] [Range(1, 10)] int Exercise;
    [SerializeField] Vector3 vector1;
    [SerializeField] Vector3 vector2;
    Vec3 vec1;
    Vec3 vec2;
    Vec3 result;

    float interpolationRatio = 0.1f;
    void Start()
    {
        vec1 = new Vec3(vector1);
        vec2 = new Vec3(vector2);
        result = Vec3.Zero;

        Vector3Debugger.AddVector(vec1, Color.black, "v1");
        Vector3Debugger.AddVector(vec2, Color.white, "v2");
        Vector3Debugger.AddVector(result, Color.blue, "v_result");

        Vector3Debugger.TurnOnVector("v1");
        Vector3Debugger.TurnOnVector("v2");
        Vector3Debugger.TurnOnVector("v_result");


        Vector3Debugger.EnableEditorView();
    }

    void vec3Equalsvector3()
    {
        vec1.x = vector1.x;
        vec1.y = vector1.y;
        vec1.z = vector1.z;

        vec2.x = vector2.x;
        vec2.y = vector2.y;
        vec2.z = vector2.z;
    }

    void Update()
    {

        vec3Equalsvector3();

        switch (Exercise)
        {
            case 1:

                result = vec1 + vec2;

                break;
            case 2:

                result = vec2 - vec1;  

                break;
            case 3:

                result.x = vec1.x * vec2.x;
                result.y = vec1.y * vec2.y;
                result.z = vec1.z * vec2.z;

                break;
            case 4:

                result = Vec3.Cross(vec2, vec1); 

                break;
            case 5:

                result = Vec3.Lerp(vec1, vec2, interpolationRatio);


                interpolationRatio += 0.005f;
//float a = 10000f * Time.deltaTime; //aca A = 0, por eso no estoy usando el delta time

                if (interpolationRatio > 1)
                {
                    interpolationRatio = 0.1f;
                }

                break;
            case 6:

                result = Vec3.Max(vec1, vec2);

                break;
            case 7:

                result = Vec3.Project( vec1, vec2); // Tira bien la proyeccion, pero la hace inversa y mas corta

                break;
            case 8:

             
                break;
            case 9:



                break;
            case 10:

                break;


            default:
                break;
        }

        Vector3Debugger.UpdatePosition("v1", vector1);
        Vector3Debugger.UpdatePosition("v2", vector2);
        Vector3Debugger.UpdatePosition("v_result", result);

    }
}



//Ejercicio 1: SUMA vectores
//Ejercicio 2: RESTA vectores
//Ejercicio 3: Multiplica vectores
//Ejercicio 4: Producto Cruz
//Ejercicio 5: lerp ?
//Ejercicio 6: Toma el maximo de cada eje
//Ejercicio 7: Proyeccion
//