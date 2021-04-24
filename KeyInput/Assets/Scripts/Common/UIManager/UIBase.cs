using UnityEngine;

public delegate void CallBack();

public abstract class UIBase : MonoBehaviour
{
    public virtual void Show(CallBack callback = null)
    {
        gameObject.SetActive(true);
        callback?.Invoke();
    }

    public virtual void Hide(CallBack callback = null)
    {
        gameObject.SetActive(false);
        callback?.Invoke();
    }
}
