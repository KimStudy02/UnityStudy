using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OkCancelUI : UIBase
{
    public Text msgText;
    public Button okButton;
    public Button cancelButton;
    
    public void Init(string message, CallBack callbackOK = null, CallBack callbackCancel = null)
    {
        msgText.text = message;

        okButton.onClick = new Button.ButtonClickedEvent();
        okButton.onClick.AddListener(() => { callbackOK?.Invoke(); });
        okButton.onClick.AddListener(() => { Hide(); });

        cancelButton.onClick = new Button.ButtonClickedEvent();
        cancelButton.onClick.AddListener(() => { callbackCancel?.Invoke(); });
        cancelButton.onClick.AddListener(() => { Hide(); });
    }
}
