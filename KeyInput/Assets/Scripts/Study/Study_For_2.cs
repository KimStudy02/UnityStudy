using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_For_2 : MonoBehaviour
{
    // Space 키를 누르면 Capsule을 10 개 소환한다. (랜덤한 위치에)
    public GameObject capsule;
    
    public void Update()
    {
        // Input.GetKey => 꾸욱 누르든 말든, 누르고 있으면 들어감
        // Input.GetKeyDown => 꾸욱 누르든 말든, 처음 한번만 눌러졌을 떄
        // Input.GetKeyUp => 꾸욱 누르든 말든, 처음 눌러졌다가 때어질 떄

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < 10; i++)
            {
                GameObject newCapsule = Instantiate(capsule);

                float randX = Random.Range(-10, 10);
                float Y = 1;
                float randZ = Random.Range(-10, 10);
                Debug.Log($"x:{randX},z:{randZ}");

                Vector3 randomPos = new Vector3(randX, Y, randZ);
                newCapsule.transform.position = randomPos;
            }
        }        
    }

}
