using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingame : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        IngameUI ingameUI = UIManager.Instance.GetUI<IngameUI>(UIList.IngameUI);
        ingameUI.Show();

        Main.Instance.LoadScene(SceneTypes.IngameArt);
    }
}
