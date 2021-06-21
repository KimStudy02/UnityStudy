using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectType
{
    None,
    AirCraft,
}

[System.Serializable]
public class ObjectBase
{
    public GameObject original;
    public Stack<GameObject> pool = new Stack<GameObject>();
    public int poolSize = 0;

}
public class ObjectManager : SingletonBase<ObjectManager>

{
    [System.Serializable]
    public class DictionaryObjectTypeAndBase : SerializableDictionary<ObjectType, ObjectBase>
    {

    }

    public DictionaryObjectTypeAndBase objectContainer;

    private void Awake()
    {
        foreach (var obj in objectContainer)
        {
            for (int i = 0; i < obj.Value.poolSize; i++)
            {
                GameObject go = Instantiate(obj.Value.original);
                go.SetActive(false);
                obj.Value.pool.Push(go);
            }

        }
    }

    public GameObject GetObject(ObjectType type)
    {
        GameObject obj = objectContainer[type].pool.Pop();
        if (obj.activeSelf == true)
        {
            objectContainer[type].pool.Push(obj);
            GameObject newObj = Instantiate(objectContainer[type].original);
            objectContainer[type].pool.Push(newObj);
            return newObj;
        }
        else
        {
            objectContainer[type].pool.Push(obj);
            return obj;
        }
    }
}

