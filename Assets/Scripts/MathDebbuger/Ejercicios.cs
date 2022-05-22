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

                if (interpolationRatio < 1)
                {
                    interpolationRatio += Time.deltaTime;
                }
                else
                {
                    interpolationRatio = 0;
                }

                break;
            case 6:

                result = Vec3.Max(vec1, vec2);

                break;
            case 7:

                result = Vec3.Project(vec1, vec2); 

                break;
            case 8:

                Vec3 normalizedVec = new Vec3(vec1 + vec2).normalized;
                float distanceVec = Vec3.Distance(vec1,vec2);

                result = normalizedVec * distanceVec;
             
                break;
            case 9:

                result = Vec3.Reflect(vec1, vec2.normalized);


                break;
            case 10:

                result = Vec3.LerpUnclamped(vec2, vec1, interpolationRatio);

                if (interpolationRatio < 10)
                {
                    interpolationRatio += Time.deltaTime;
                }
                else
                {
                    interpolationRatio = 0;
                }

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
//Ejercicio 4: -Producto Cruz
//Ejercicio 5: Lerp 
//Ejercicio 6: Toma el maximo de cada eje
//Ejercicio 7: Proyeccion
//Ejercicio 8: Suma de Vectores Normalizados * su distancia
//Ejercicio 9: Reflexion
//Ejercicio 10: Unclamped Lerp
