using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_Generic : MonoBehaviour
{
    private void Start()
    {
        Data.Show(10, 3);
        Data.Show(10.9f, 60.2f);
        Data.Show(3.0, 20.0);
        Data.Show(10.666666666666666666666666666666666666, 3.423f);
    }
}




public class Data
{
    //public static void Show<T>(T a, T b)
    //{
    //    Debug.LogFormat("{0}, {1}", a.ToString(), b.ToString());       
    //}

    public static void Show<T, K>(T a, K b)
    {
        Debug.LogFormat("{0}, {1}", a.ToString(), b.ToString());
    }


    //public static int Add(int a, int b)
    //{
    //    return a + b; 
    //}

    //public static float Add(float a, float b)
    //{
    //    return a + b;
    //}

    //public static float Add(float a, int b)
    //{
    //    return a + b;
    //}

    //public static float Add(int a, float b)
    //{
    //    return a + b;
    //}

}