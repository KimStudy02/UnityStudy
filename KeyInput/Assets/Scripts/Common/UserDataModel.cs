using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerPrefsKey
{
    Score,
    PlayTime,
}

public class UserDataModel : SingletonBase<UserDataModel>
{
    public void SetData(PlayerPrefsKey key, string data)
    {
        PlayerPrefs.SetString(key.ToString(), data);
    }
    
    public string GetData(PlayerPrefsKey key)
    {
        string result;
        result = PlayerPrefs.GetString(key.ToString());
        return result;
    }
}
