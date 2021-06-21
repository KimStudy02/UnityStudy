using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float moveSpeed;
    public float range;
    public Vector3 startPos;
    public float lifeTime;
    public AirCraftType master;


    public void Initialize(AirCraftType owner)
    {
        master = owner;
    }

    private void Update()
    {
        transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
        if(Vector3.Distance(transform.position, startPos) > range)
        {
            gameObject.SetActive(false);
        }
        
    }

    public void Start()
    {
        startPos = transform.position;        
    }

    private void OnEnable()
    {
        Invoke("AutoDisable", lifeTime);
    }

    void AutoDisable()
    {
        gameObject.SetActive(false);
    }
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameObject impact = EffectManager.Instance.GetEffect(EffectType.BulletA_Impact);
            impact.transform.position = collision.contacts[0].point;
            impact.SetActive(true);
            gameObject.SetActive(false);

        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            if (collision.gameObject.CompareTag("Enemy") && master == AirCraftType.Player)
            {
                EnemyAirCraft enemy = collision.gameObject.GetComponent<EnemyAirCraft>();
                if (enemy != null)
                {
                    enemy.Damage(20.0f);

                    GameObject impact = EffectManager.Instance.GetEffect(EffectType.BulletA_Impact);
                    impact.transform.position = collision.contacts[0].point;
                    impact.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
            else if (collision.gameObject.CompareTag("Player") && master == AirCraftType.Enemy)
            {
                AirCraftController player = collision.gameObject.GetComponent<AirCraftController>();
                if (player != null)
                {
                    player.Damage(10.0f);

                    GameObject impact = EffectManager.Instance.GetEffect(EffectType.BulletB_Impact);
                    impact.transform.position = collision.contacts[0].point;
                    impact.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }        
    }
}
