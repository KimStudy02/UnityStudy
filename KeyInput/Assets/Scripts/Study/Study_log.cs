using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Study_log : MonoBehaviour
{
    public int logValue;
    public float xPos;
    public float yPos;



    public void Start()
    {
        Debug.Log("message");
        Debug.Log(logValue);

        Debug.LogWarning("W A R N I N G");

        Debug.LogError("Error");


        string logPos = $"Called Start - x:{xPos}y:{yPos}";
        Debug.Log(logPos);

        string logMsg = "Hello World";

        StringBuilder sb = new StringBuilder();
        sb.Append(logPos);
        sb.Append(logMsg);

        Debug.Log(logPos + logMsg);
        Debug.Log(sb.ToString());

        Debug.Log("Color <color=#FF0000>Red Log!</color> White??");
    }

    public void Update()
    {
        Debug.LogFormat("x : {0}, y : {1}", xPos, yPos);

        Debug.LogWarningFormat("WarnigFormat");

        Debug.LogErrorFormat("ErrorFormat");
    }



}
