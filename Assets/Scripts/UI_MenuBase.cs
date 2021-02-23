using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_MenuBase : MonoBehaviour
{
    protected UI_ManagerBase ManagerBase;
    bool isActive;

    public virtual void ToggleMenu(bool _value)
    {
        if (isActive == _value)
            return;
        isActive = _value;
        gameObject.SetActive(isActive);
    }
    public void Setup(UI_ManagerBase _UIManagerBase)
    {
        ManagerBase = _UIManagerBase;
        isActive = true;
    }
    public bool IsMenuActive()
    {
        return isActive;
    }
    protected virtual void OnSetup()
    {

    }
}
