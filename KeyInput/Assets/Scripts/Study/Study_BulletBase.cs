using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_BulletBase : MonoBehaviour
{
    public GameObject groundEffect;

    // OnCollision 에서는 Layer를 이용하여 처리를 하는 편이고
    // OnTrigger 에서는 Tag 를 이용하여 처리를 한다.
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Study - BulletBase Enter : " + collision.gameObject.layer);
        Debug.Log("Study - BulletBase - LayerMask : " + LayerMask.NameToLayer("Ground"));

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            gameObject.SetActive(false);

            // Effect를 소환한다!
            GameObject effectGo = Instantiate(groundEffect);
            effectGo.transform.position = collision.GetContact(0).point;
        }
    }
}
