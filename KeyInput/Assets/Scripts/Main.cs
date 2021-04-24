using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneTypes
{
    Lobby,
    Ingame,
    IngameArt,
}

public class Main : MonoBehaviour
{
    public static Main Instance;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        //Todo : 게임이 실행 되기전 - 각종 초기화나, Initialize 를 하는 과정은 여기에서 진행한다.



        UIManager.Instance.Initialize();

        //Game Scene 을 로드한다.
        LoadScene(SceneTypes.Lobby);
    }

    public void LoadScene(SceneTypes sceneType)
    {
        SceneManager.LoadScene(sceneType.ToString());

        //symless (심리스)
    }
}
