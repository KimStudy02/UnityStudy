using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Portal_Type
{
    ToResetPosition,
    ToLobby,

}


public class PortalBase : MonoBehaviour
{
    public Portal_Type portalType;


    public void OnIntoPortal(GameObject goCollider)
    {
        switch (portalType)
        {
            case Portal_Type.ToLobby:
                {
                    // Todo : Lobby 씬으로 전환한다.
                    if (Main.Instance != null)
                    {
                        OkCancelUI okCancelUi = UIManager.Instance.GetUI<OkCancelUI>(UIList.OKCancelPopup);
                        okCancelUi.Init("Go to Lobby?", () =>
                        {
                            Main.Instance.LoadScene(SceneTypes.Lobby);
                        });
                        okCancelUi.Show();
                    }
                }
                break;
            case Portal_Type.ToResetPosition:
                {
                    // Todo : 충돌한 타겟을 0,0,0 위치로 텔레포트 시킨다!
                    goCollider.transform.position = Vector3.zero;

                }
                break;

        }
    }
}
