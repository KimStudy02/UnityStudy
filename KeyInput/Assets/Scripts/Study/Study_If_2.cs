using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 랜덤 변수를 사용해서 Capsule 의 Position.x > 50 크고 Position.z 가 -30보다 작으면 캡슐을 끈다.

public class Study_If_2 : MonoBehaviour
{


    // Update is called once per frame
    public Transform capsule;

    private void Start()
    {
        Debug.Log("Capsule");
    }


    void Update()
    {
        float randX = Random.Range(-100, 100); // (-100, 99)
        float randZ = Random.Range(-100, 100); // (-100, 99)
        Debug.Log($"x:{randX},z:{randZ}");

        Vector3 randomPos = new Vector3(randX, 0, randZ);
        capsule.transform.position = randomPos;

        if(randX > 95 && randZ > 95)
        {                       
            capsule.gameObject.SetActive(false); // Capsule InActive!
            Debug.Log($"<color=#00FF00>Success!!</color>");
        }        
    }
}