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
}
