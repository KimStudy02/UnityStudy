using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitUI : UIBase
{
    public void OnClickOkButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif        
    }
    public void OnClickCancelButton()
    {
        gameObject.SetActive(false);
    }
}
