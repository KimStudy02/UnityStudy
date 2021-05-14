using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    private void Awake()
    {
        LobbyUI lobbyUI = UIManager.Instance.GetUI<LobbyUI>(UIList.LobbyUI);
        lobbyUI.Show();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitUI exitUI = UIManager.Instance.GetUI<ExitUI>(UIList.ExitUI);
            exitUI.Show();
        }
        


    }
}
