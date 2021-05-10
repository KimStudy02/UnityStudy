using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 1;

    public Animator Animator;
    [Range(0, 100)]
    public float currentStamina = 100;

    public float staminaDecreaseSpeed = 5;

    public float currentHP = 100;

    private IngameUI ingameUI;

    public GameObject bloodEffect;
    public void Start()
    {
        transform.position = Vector3.zero;

        ingameUI = UIManager.Instance.GetUI<IngameUI>(UIList.IngameUI);
        if(ingameUI != null)
        {
            ingameUI.SetStamina(currentStamina);
            ingameUI.SetHp(currentHP);
            ingameUI.Show();
        }
    }


    public void Update()
    {

        bool isMove = false;


        //currentHP -= 1;

        if (currentHP <= 0)
        {
            Animator.SetBool("isDead", true);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + (transform.forward * Speed * Time.deltaTime);
            isMove = true;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (-transform.right * Speed * Time.deltaTime);
            isMove = true;
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (-transform.forward * Speed * Time.deltaTime);
            isMove = true;
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (transform.right * Speed * Time.deltaTime);
            isMove = true;
        }

        if (isMove)
        {
            currentStamina -= staminaDecreaseSpeed * Time.deltaTime;
            if(ingameUI != null)
            {
                ingameUI.SetStamina(currentStamina);
            }

           
        }
        bool isRun = false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
        }

        if (isRun)
        {
            Animator.SetBool("isRun", isMove);
        }
        else
        {
            Animator.SetBool("isWalk", isMove);
        }       

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animator.SetTrigger("WinTrigger");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            PortalBase portal = other.GetComponent<PortalBase>();
            portal.OnIntoPortal(this.gameObject);
            
        }
        if (other.CompareTag("Bullet"))
        {
            GameObject effect = Instantiate(bloodEffect);
            effect.transform.position = other.transform.position;      
            effect.transform.rotation = Quaternion.Inverse(other.transform.rotation);
            effect.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Todo: Damage ㅊㅓㄹㅣ
            Damaged(3);
            
            //GameObject effect = Instantiate(bloodEffect);
            //effect.transform.position = collision.GetContact(0).point;
            //effect.SetActive(true);

            //Bullet InActive!;
            //collision.gameObject.SetActive(false);
            // Blood Particle Effect Instantiate!!




            //Destroy(collision.gameObject);
        }

        
    }

    private void Damaged(float damage)
    {
        currentHP -= damage;
        if (ingameUI != null)
        {
            ingameUI.SetHp(currentHP);
        }
            
        
    }

    #region 충돌 검사 함수들

    //void OnCollisionEnter(Collision collision)
    //{
    //    // 여기는 충돌이 처음 검사 됐을 때 맨 처음! 한번만 호출 된다.

    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    // 여기는 A,B 두 충돌체가 서로 충돌 상태가 아닌 걸로 판단 될 때! 한번만 호출 된다.

    //}

    //void OnCollisionStay(Collision collision)
    //{
    //    // 계속 충돌중이면 여기에 들어온다. (주기적으로 Update 함수 처럼)

    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    // 두 충돌체의 콜라이더의 범위가 겹쳤을 때 한 번만 호출 된다.

    //}

    //void OnTriggerExit(Collider other)
    //{
    //    // A,B 두 충돌체의 콜라이더 범위가 다시 벗어났을 때 한번만 호출된다.

    //}

    //void OnTriggerStay(Collider other)
    //{
    //    // 계속 충돌중이면 여기에 들어온다. (주기적으로 Update 함수 처럼)

    //}
    #endregion
}
