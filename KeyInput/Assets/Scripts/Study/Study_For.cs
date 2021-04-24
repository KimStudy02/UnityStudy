using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_For : MonoBehaviour
{
    // For 문을 사용해서 -> Object를 10개 생성하고, 각 Object(Capsule)의 컬러를 다르게 해야한다
    public GameObject capsule;

    
    public void Start()
    {
        for (int i = 0; i < 10; i++)
        {

            // Capsule을 복제/생성한다.
            GameObject newCapsule = Instantiate(capsule);

            float randX = Random.Range(-10, 10); // (-100, 99)         
            float Y = 1;
            float randZ = Random.Range(-10, 10); // (-100, 99)
            Debug.Log($"x:{randX},z:{randZ}");

            Vector3 randomPos = new Vector3(randX, Y, randZ);
            newCapsule.transform.position = randomPos;

            float r = Random.Range(0, 255) / 255.0f;
            float g = Random.Range(0, 255) / 255.0f;
            float b = Random.Range(0, 255) / 255.0f;
            Color color = new Color(r, g, b);
            Debug.Log($"Pick Color - Red:{r}, Green:{g}, Blue:{b}");

            Renderer renderer = newCapsule.GetComponent<Renderer>();
            renderer.material.color = color;

        }

    }
}
