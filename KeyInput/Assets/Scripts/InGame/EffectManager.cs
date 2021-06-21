using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    None,
    BulletA_Impact,
    BulletA_MuzzleFlare,
    BulletA_Projetile,
    AirCraft_Explosion,
    BulletB_Impact,
    BulletB_Projetile,
    BulletB_MuzzleFlare,
}

[System.Serializable]
public class EffectBase
{
    public GameObject original;
    public Stack<GameObject> pool = new Stack<GameObject>();
    public int poolSize = 0;

}
public class EffectManager : SingletonBase<EffectManager>

{
    [System.Serializable]
    public class DictionaryEffectTypeAndBase : SerializableDictionary<EffectType, EffectBase>
    {

    }

    public DictionaryEffectTypeAndBase effectContainer;

    private void Awake()
    {
        foreach(var effect in effectContainer)
        {
            for(int i = 0; i < effect.Value.poolSize; i++)
            {
                GameObject obj = Instantiate(effect.Value.original);
                obj.SetActive(false);
                effect.Value.pool.Push(obj);
            }
            
        }
    }

    public GameObject GetEffect(EffectType type)
    {          
        GameObject obj = effectContainer[type].pool.Pop();
        if(obj.activeSelf == true)
        {
            effectContainer[type].pool.Push(obj);
            GameObject newObj = Instantiate(effectContainer[type].original);
            effectContainer[type].pool.Push(newObj);
            return newObj;
        }
        else
        {
            effectContainer[type].pool.Push(obj);
            return obj;
        }
    }
}


   