using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// * Challenge!
//  - 캐릭터가 어떤 특정 구역에 들어가면
//  - 특정 구역안에서, 랜덤한 위치(Y 값은 적당히 위로 줄 것)에서 총알이 소환 됨(Instantiate를 쓰자)
//  - 총알이 중력으로 땅에 떨어지고, (총알은 Collider랑 Rigidbody 있어야 됨)
//  - 총알이 땅에 부딪치면, 부딪친 위치에서 이펙트를 터트린다! (이펙트를 Instantiate 한다)

public class Study_CharacterController : MonoBehaviour
{
    public float speed;
    [Range(0.0f, 10.0f)] public float speedBuff = 1.0f;

    public Animator animator;
    
    
    private void FixedUpdate()
    {
        float horizontal = 0.0f;
        float vertical = 0.0f;

        bool isMove = false;

        if(Input.GetKey(KeyCode.W))
        {
            vertical += 1.0f;
            isMove = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            vertical -= 1.0f;
            isMove = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontal -= 1.0f;
            isMove = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontal += 1.0f;
            isMove = true;
        }
        
        animator.SetBool("IsWalk", isMove);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("IsRun", true);
            speedBuff = 2.0f;
        }
        else
        {
            animator.SetBool("IsRun", false);
            speedBuff = 1.0f;
        }


        animator.SetFloat("MoveAnimSpeed", speedBuff);
       
        
        float moveX = horizontal * (speed * speedBuff) * Time.deltaTime;
        float moveZ = vertical * (speed * speedBuff) * Time.deltaTime;
        Vector3 moveVec = new Vector3(moveX, 0, moveZ);

        transform.position += moveVec;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {            
            Debug.Log("<color=#FF0000>Collision - Enter! Wall!</color>");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Debug.Log("<color=#FF0000>Collision - Stay! Wall!</color>");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Debug.Log("<color=#FF0000>Collision - Exit! Wall!</color>");
        }
    }

    public GameObject bullet;
    public float spawnDelay;
    public float currentTime;



    public void SpawnBullet()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newBullet = Instantiate(bullet);

            float randX = Random.Range(-10, 10);
            float randY = Random.Range(10, 15);
            float randZ = Random.Range(15, 35);

            Vector3 randomPos = new Vector3(randX, randY, randZ);
            newBullet.transform.position = randomPos;

            newBullet.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {            
            Debug.Log("Trigger - Enter! Goal");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            currentTime += Time.deltaTime;

            if (currentTime > spawnDelay)
            {
                SpawnBullet();
                currentTime = 0;
            }

            Debug.Log("Trigger - Stay! Goal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("Trigger - Exit! Goal");
        }
    }
}
