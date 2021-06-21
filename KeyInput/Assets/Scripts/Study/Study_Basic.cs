using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataObject
{
    public int value;
    public string dataName;
}

public class Study_Basic : MonoBehaviour
{
    public List<DataObject> data = new List<DataObject>();
    public List<int> numberData = new List<int>();

    private void Start()
    {
        //for(int i = 0; i < 10; i++ )
        //{
        //    LogPrint(i, "Hi");
        //}
        int i = 0;

        while(i < 10)
        {
            LogPrint(i, "hi");
            i++;
        }


    }

    void LogPrint(int value, string msg)
    {
        Debug.Log("Hello" + value);
        Debug.Log(msg);
    }
}
