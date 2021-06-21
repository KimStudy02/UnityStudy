using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillType
{
    Bomber,
    Tornado,
}

public class AirCraftController : MonoBehaviour
{
    public static AirCraftController Player { get; private set; } = null;
    
    public float moveSpeed;
    [Range(0, 1)]public float rotSpeed;
    public Transform firePos;
    public float fireRate;
    public bool isPossibleFire;
    public float skillCoolTime;
    public bool isCoolTime_1;
    public bool isCoolTime_2;
    public float hp;
   
    private void Awake()
    {       
        Player = this;
    }

    public void Update()
    {
        Move();
        Rotate();
        Shoot();
        Skill();
                
    }

    void Move()
    {
        Vector3 moveVec = new Vector3();


        if (Input.GetKey(KeyCode.W))
        {
            moveVec += new Vector3(0, 0, 1);

        }

        if (Input.GetKey(KeyCode.S))
        {
            moveVec += new Vector3(0, 0, -1);

        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVec += new Vector3(-1, 0, 0);

        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVec += new Vector3(1, 0, 0);

        }

        transform.position += moveVec * moveSpeed * Time.deltaTime;
    }

    void Rotate()
    {
        Quaternion quat = transform.rotation;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            quat = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            quat = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            quat = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            quat = Quaternion.Euler(0, 270, 0);
        }
                
        transform.rotation = Quaternion.Lerp(transform.rotation, quat, rotSpeed);
    }

    void Shoot()
    {
        if(isPossibleFire)
        {
            if (Input.GetKey(KeyCode.Space))
            {

                GameObject bulletGo = EffectManager.Instance.GetEffect(EffectType.BulletA_Projetile);
                bulletGo.SetActive(true);
                bulletGo.transform.position = firePos.transform.position;
                bulletGo.transform.rotation = firePos.transform.rotation;
                BulletBase bullet = bulletGo.GetComponent<BulletBase>();
                bullet.Initialize(AirCraftType.Player);
                isPossibleFire = false;
                Invoke("ChangeFireState", fireRate);
                
            }

        }
        

    }

    void ChangeFireState()
    {
        isPossibleFire = true;
    }

    void Skill()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(isCoolTime_1 == false)
            {
                ShootingGameUI gameUi = UIManager.Instance.GetUI<ShootingGameUI>(UIList.ShootingGameUI);
                gameUi.UseSkill(SkillType.Bomber, skillCoolTime);
                isCoolTime_1 = true;
                Invoke(nameof(InvokeSkillCoolTime), skillCoolTime);
                UseSkill(SkillType.Bomber);
            }            
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (isCoolTime_2 == false)
            {
                ShootingGameUI gameUi = UIManager.Instance.GetUI<ShootingGameUI>(UIList.ShootingGameUI);
                gameUi.UseSkill(SkillType.Tornado, skillCoolTime);
                isCoolTime_2 = true;
                Invoke(nameof(InvokeSkillCoolTime_2), skillCoolTime);
                UseSkill(SkillType.Tornado);
            }

        }
    }

    void InvokeSkillCoolTime()
    {        
        isCoolTime_1 = false;        
    }

    void InvokeSkillCoolTime_2()
    {
        isCoolTime_2 = false;
    }

    void UseSkill(SkillType skill)
    {
        switch(skill)
        {
            case SkillType.Bomber:
                for(int i = 0; i < 20; i++)
                {
                    GameObject effect = EffectManager.Instance.GetEffect(EffectType.AirCraft_Explosion);
                    effect.transform.position = new Vector3(Random.Range(-40, 40), 0, Random.Range(-20, 20));
                    effect.SetActive(true);
                }
                break;
            case SkillType.Tornado:
                for(int i = 0; i < 10; i++)
                {                    
                    GameObject effect = EffectManager.Instance.GetEffect(EffectType.BulletA_MuzzleFlare);
                    effect.transform.position = new Vector3(Random.Range(-40, 40), 0, Random.Range(-20, 20));
                    effect.SetActive(true);                    
                }
                break;

        }
    }    

    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            GameObject effect = EffectManager.Instance.GetEffect(EffectType.AirCraft_Explosion);
            effect.transform.position = transform.position;
            effect.SetActive(true);            
        }
    }



}
