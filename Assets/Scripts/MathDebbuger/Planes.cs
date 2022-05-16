using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomMath
{
    public struct Planes : IFormattable
    {
        #region Variables

        private Vec3 m_Normal;

        private float m_Distance;

        public Vec3 normal //La normal del plano
        {
            get
            {
                return m_Normal;
            }
            set
            {
                m_Normal = value;
            }
        }
      
        public float distance //Es la distancia desde el plano al origen, se mide a lo largo de la normal del plano
        {
            get
            {
                return m_Distance;
            }
            set
            {
                m_Distance = value;
            }
        }
 
        public Planes flipped => new Planes(-m_Normal, 0f - m_Distance); //Retorna un nuevo plano mirando hacia la direccion opuesta

        #endregion

        #region Constructors

        public Planes(Vec3 inNormal, Vec3 inPoint)
        {
            m_Normal = Vector3.Normalize(inNormal);

            m_Distance = 0f - Vec3.Dot(m_Normal, inPoint);
        }
        public Planes(Vec3 inNormal, float d)
        {
            m_Normal = Vector3.Normalize(inNormal);
            m_Distance = d;
        }
        public Planes(Vec3 a, Vec3 b, Vec3 c)
        {
            m_Normal = Vector3.Normalize(Vec3.Cross(b - a, c - a));
            m_Distance = 0f - Vec3.Dot(m_Normal, a);
        }

        #endregion

        #region Operators



        #endregion

        #region Functions

        public void SetNormalAndPosition(Vec3 inNormal, Vec3 inPoint) //Asigna a un plano los valores que le llega por parametro
        {
            m_Normal = Vector3.Normalize(inNormal);
            m_Distance = 0f - Vec3.Dot(inNormal, inPoint);
        }


        public void Set3Points(Vec3 a, Vec3 b, Vec3 c) //Posiciona un plano a partir de 3 puntos orientados con sentido a las abujas del reloj
        {
            m_Normal = Vector3.Normalize(Vec3.Cross(b - a, c - a));
            m_Distance = 0f - Vec3.Dot(m_Normal, a);
        }

        public void Flip() //Gira 180° el plano
        {
            m_Normal = -m_Normal;
            m_Distance = 0f - m_Distance;
        }

        public void Translate(Vec3 translation) //Mueve el plano tomando como refencia un vector
        {
            m_Distance += Vec3.Dot(m_Normal, translation);
        }

        public static Planes Translate(Planes planes, Vec3 translation) //Crea un nuevo plano en base al que llega por parametro y los mueve segun el vector que llega
        {
            return new Planes(planes.m_Normal, planes.m_Distance += Vec3.Dot(planes.m_Normal, translation));
        }

        public Vec3 ClosestPointOnPlane(Vec3 point) //Devuelve el punto mas cercano del plano en referencia al punto que llega por parametro
        {
            float num = Vec3.Dot(m_Normal, point) + m_Distance;
            return point - m_Normal * num;
        }

        public float GetDistanceToPoint(Vec3 point) //Devuelve la distancia del plano al punto
        {
             return (Vec3.Dot(m_Normal, point) + m_Distance) / point.magnitude;
        }

        public bool GetSide(Vec3 point) //Devuelve true si el punto esta a una distancia positiva del plano 
        {
            return GetDistanceToPoint(point) >= 0f;
        }

        public bool SameSide(Vector3 inPt0, Vector3 inPt1) // Chequea si 2 puntos estan del mismo lado del plano
        {
            float distanceToPoint = GetDistanceToPoint(inPt0);
            float distanceToPoint2 = GetDistanceToPoint(inPt1);
            return (distanceToPoint > 0f && distanceToPoint2 > 0f) || (distanceToPoint <= 0f && distanceToPoint2 <= 0f);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Empty;
        }

        #endregion


    }

}