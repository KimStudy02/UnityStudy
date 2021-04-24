using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_For_3 : MonoBehaviour
{

    public GameObject capsule;
    public float spawnDelay;
    public float currentTime;
    public Color spawnColor;
    public int totalCapsule = 0;
    public int spawnCount = 10;

    // Capsule을 3초 마다 10개씩 생성한다. (ok)
    // 캡슐을 생성할 때 마다, 이 전에 생성한 캡슐의 색깔과는 달라야한다. (ok)
    // 총 캡슐의 갯수가 100개가 넘으면 스탑한다. (ok)

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > spawnDelay)
        {
            if (totalCapsule < 100)
            {
                SpawnCapsule();
                currentTime = 0;
            }
        }
    }

    public void SpawnCapsule()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Capsule을 복제/생성한다.
            GameObject newCapsule = Instantiate(capsule);

            float randX = Random.Range(-10, 10);
            float Y = 1;
            float randZ = Random.Range(-10, 10);

            Vector3 randomPos = new Vector3(randX, Y, randZ);
            newCapsule.transform.position = randomPos;
            
            float r = Random.Range(0, 255) / 255.0f;
            float g = Random.Range(0, 255) / 255.0f;
            float b = Random.Range(0, 255) / 255.0f;
            Color pickColor = new Color(r, g, b);

            while (pickColor == spawnColor)
            {
                r = Random.Range(0, 255) / 255.0f;
                g = Random.Range(0, 255) / 255.0f;
                b = Random.Range(0, 255) / 255.0f;
                pickColor = new Color(r, g, b);
            }

            spawnColor = pickColor;

            Renderer renderer = newCapsule.GetComponent<Renderer>();
            renderer.material.color = spawnColor;
        }

        totalCapsule += spawnCount;
    }
}
