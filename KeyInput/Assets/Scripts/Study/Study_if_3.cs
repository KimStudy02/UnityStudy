using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_if_3 : MonoBehaviour
{
    public Transform capsule;


    // 총, 100 번 동안 소환한다
    //  => 100 번 동안 소환하는 중에 만약 현재 소환 된 갯수를 n 으로 나눈 나머지 값이 0 이면 소환을 중단한다. (n:랜덤한 수)
    void Start()
    {
        int nRandom = Random.Range(10, 100); // <= n (n: 10 ~ 99)
        Debug.Log($"N : {nRandom}");

        for (int i = 0; i < 100; i++)
        {
            Instantiate(capsule);
            if (i % nRandom == 0)
            {               
                Debug.Log("Break!");
                break;
            }
        }
    }
}
