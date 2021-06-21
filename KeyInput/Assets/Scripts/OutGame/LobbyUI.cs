using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUI : UIBase
{
    public void OnClickStartButton() 
    {
        // Start Button 을 눌렀을때 동작

        Main.Instance.LoadScene(SceneTypes.Ingame);

        // UI 본인을 Hide 한다
        Hide();
    }

    public void OnClickShootingStartButton()
    {

        Main.Instance.LoadScene(SceneTypes.ShootingGame);

        Hide();

    }




}
