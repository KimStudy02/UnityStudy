using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirCraft : MonoBehaviour
{
    public enum AIphase
    {
        Intro,
        Free,
        Outro,
    }

    public enum AIpattern
    {
        Pattern_A,
        Pattern_B,
        Pattern_C,
        Pattern_MAX
    }
    public AIpattern pattern;   
    public float patternParam;
    public Vector3 startPos;
    public float hp;
    public AIphase phase;
    public float runningTime;
    public float introTime;
    public float freeTime;
    public float introSpeed;
    public float outroSpeed;
    public float freeSpeed;
    public int attackCurrent;
    public int attackCount;
    public float attackDelay;
    public Transform firePos;
    public Transform turret;
    public Renderer[] modelRenderers;
    public bool isShining;
    
    public void Init(AIpattern aiType, float param, float speed)
    {
        pattern = aiType;
        patternParam = param;
        freeSpeed = speed;
        hp = 100;
        phase = AIphase.Intro;
        attackCurrent = 0;
        isShining = false;
    }
    


    private void Start()
    {
        //StartCoroutine(CoPattern());
        startPos = transform.position;
        modelRenderers = GetComponentsInChildren<Renderer>();
    }

    private void OnEnable()
    {
        Invoke("ChangePhase", introTime);
    }


    private void Update()
    {        
        Vector3 moveVec = new Vector3();

        if (phase == AIphase.Intro)
        {
            moveVec.z = -1;
        }
        else if(phase == AIphase.Free)
        {            
            switch (pattern)
            {
                case AIpattern.Pattern_A:
                    if (Vector3.Distance(startPos, transform.position) < patternParam)
                    {
                        moveVec.z = -1;
                    }
                    break;
                case AIpattern.Pattern_B:
                    runningTime += freeSpeed * Time.deltaTime;
                    moveVec.x = Mathf.Cos(runningTime) * patternParam;
                    moveVec.z = Mathf.Sin(runningTime) * patternParam;
                    break;
                case AIpattern.Pattern_C:
                    moveVec.x = Mathf.PingPong(Time.time, patternParam * 2) - patternParam;
                    break;
            }            
        }
        else if(phase == AIphase.Outro)
        {
            moveVec.z = -1;
        }
        float speed = (phase == AIphase.Intro ? introSpeed : (phase == AIphase.Free ? freeSpeed : outroSpeed)); 
        transform.position += moveVec * speed * Time.deltaTime;
    }
    
    void ChangePhase()
    {
        switch(phase)
        {
            case AIphase.Intro:
                phase = AIphase.Free;
                Invoke("ChangePhase", freeTime);
                Attack();
                break;
            case AIphase.Free:
                phase = AIphase.Outro;
                break;
        }
        
    }

    public void Damage(float damage)
    {
        if(hp > 0)
        {
            hp -= damage;

            StartCoroutine(CoShineRenderer());
        }
        else
        {
            gameObject.SetActive(false);
            GameObject effect = EffectManager.Instance.GetEffect(EffectType.AirCraft_Explosion);
            effect.transform.position = transform.position;
            effect.SetActive(true);
            GameManager.Instance.AddScore(100);
        }   
    }

    IEnumerator CoShineRenderer()
    {
        isShining = true;
        int shineCount = 0;
        Color[] originalColors = new Color[modelRenderers.Length];

        while(shineCount < 10)
        {
            for(int i = 0; i < modelRenderers.Length; i++)
            {
                originalColors[i] = modelRenderers[i].material.color;
                modelRenderers[i].material.color = Color.white;
            }

            yield return new WaitForSeconds(0.1f);

            for(int i = 0; i < modelRenderers.Length; i++)
            {
                modelRenderers[i].material.color = originalColors[i];
            }

            yield return new WaitForSeconds(0.1f);
            shineCount++;

        }
        isShining = false;

    }

    public void Attack()
    {
        if(attackCurrent < attackCount)
        {
            turret.LookAt(AirCraftController.Player.transform);
            GameObject bulletGo = EffectManager.Instance.GetEffect(EffectType.BulletB_Projetile);
            bulletGo.SetActive(true);
            bulletGo.transform.position = firePos.transform.position;
            bulletGo.transform.rotation = firePos.transform.rotation;
            BulletBase bullet = bulletGo.GetComponent<BulletBase>();
            bullet.Initialize(AirCraftType.Enemy);
            attackCurrent++;
            Invoke("Attack", attackDelay);
        }
        else
        {
            CancelInvoke();
        }
    }
    
}
