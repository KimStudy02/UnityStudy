using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float speed;

    public float lifeTime;
    public float curLifeTime;

    private void Update()
    {
        curLifeTime += Time.deltaTime;

        if (curLifeTime > lifeTime)
        {
            // Bullet InActive!
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Vector3 nextPos = transform.position + (transform.forward * speed * Time.deltaTime);
        transform.position = nextPos;
    }
}
