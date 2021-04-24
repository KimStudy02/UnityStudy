using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_If : MonoBehaviour
{
    public Transform capsule;
    public float speed;

    private void Update()
    {
        Vector3 nextPos = new Vector3(capsule.transform.position.x, capsule.transform.position.y, capsule.transform.position.z);
        nextPos.z += speed * Time.deltaTime;

        if (capsule.transform.position.z > 100)
        {
            nextPos.z = 0;
        }

        capsule.transform.position = nextPos;
    }


}
