using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    public float delayTime;


    private void OnEnable()
    {
        Invoke("DelayedDisable", delayTime);
    }

    void DelayedDisable()
    {
        gameObject.SetActive(false);
    }
}
