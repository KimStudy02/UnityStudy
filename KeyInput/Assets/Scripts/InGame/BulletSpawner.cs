using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletOrigin;
    public Transform spawnPoint;

    public float fireRateDelay;
    public float currentRate;

    public void SpawnBullet()
    {
        GameObject newBullet = Instantiate(bulletOrigin);
        newBullet.transform.position = spawnPoint.transform.position;
        newBullet.transform.rotation = spawnPoint.transform.rotation;


    }

    private void Update()
    {
        currentRate += Time.deltaTime;

        if (currentRate > fireRateDelay)
        {
            SpawnBullet();
            currentRate = 0;
        }
    }

}
