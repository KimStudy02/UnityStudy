using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_Coroutine : MonoBehaviour
{
    // Coroutine (코루틴)
    public GameObject spawnObject;
    public void Start()
    {
        StartCoroutine(MyCoroutine());
    }
    
    IEnumerator MyCoroutine()
    {
        yield return null;
        
        //....

        //.....
        ///......
        ///..
        ///

        yield return new WaitForSeconds(1.0f);

        //....
        ////.....
        ////...
        ////...
        ///

        //while(true)
        for(int i = 0; i < 10; i++)
        {
            Vector3 randompos = new Vector3();
            randompos.x = Random.Range(-10, 10);
            randompos.y = 1;
            randompos.z = Random.Range(-10, 10);

            GameObject spawnObj = Instantiate(spawnObject);
            spawnObj.transform.position = randompos;

            Debug.Log("Spawn Cube !!");

            yield return new WaitForSeconds(1.0f);
        }


        yield return null;

        yield return new WaitForSeconds(1.0f);

        yield return new WaitForSecondsRealtime(1.0f);

        yield return new WaitForFixedUpdate();

        yield return new WaitWhile(() => { return true; });

        yield return new WaitForEndOfFrame();

        yield return new WaitUntil(() => { return true; });

    }
}
