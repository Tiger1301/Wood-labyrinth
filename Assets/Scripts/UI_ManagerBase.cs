using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_ManagerBase : MonoBehaviour
{
    protected List<UI_MenuBase> menues;
    protected UI_MenuBase CurrentMenu;

    UI_MenuBase GetCurrentMenu()
    {
        return CurrentMenu;
    }
    protected virtual void OnSetup()
    {

    }
    public void Setup()
    {
        foreach(UI_MenuBase item in menues)
            item.Setup(this);

        OnSetup();
    }
}
