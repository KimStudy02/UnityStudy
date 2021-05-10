using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_BulletSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float downPower;
    public float spawnFrequency;
        
    void OnEnable()
    {
        StartCoroutine(CoSpawnBullet());
    }

    private void FixedUpdate()
    {
        // ....
        //. ...
        // ....
        //.....
        //....
    }
    
    IEnumerator CoSequenceWork()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            bool isDebuffOfHP = true;
            int playerHP = 100;
            if (isDebuffOfHP)
            {
                playerHP--;
            }

            // ...
            /// ....
            //....

        }
    }

    IEnumerator CoSpawnBullet()
    {
        while(true)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject newBullet = Instantiate(spawnObject);

                float randX = Random.Range(-10, 10);
                float randY = Random.Range(10, 15);
                float randZ = Random.Range(-10, 10);

                Vector3 randomPos = new Vector3(randX, randY, randZ);
                newBullet.transform.position = randomPos;

                Rigidbody body = newBullet.GetComponent<Rigidbody>();
                body.AddForce(Vector3.down * downPower);
            }

            yield return new WaitForSeconds(spawnFrequency);
        }        
    }
}

public class Parent
{
    public int publicValue;
    protected int protectedValue;
    private int paivateValue;
}

public class Child : Parent
{

    public void Method()
    {
        this.publicValue = 0;
        this.protectedValue = 0;
    }



}


