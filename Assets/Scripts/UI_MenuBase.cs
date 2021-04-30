using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_MenuBase : MonoBehaviour
{
    /// <summary>
    /// È un riferimento al proprio manager
    /// </summary>
    protected UI_ManagerBase ManagerBase;
    /// <summary>
    /// Stato di attivo o disattivo del menù
    /// </summary>
    bool isActive;

    /// <summary>
    /// Funzione che attiva o disattiva il gameobject del menù
    /// </summary>
    /// <param name="_value"></param>
    public virtual void ToggleMenu(bool _value)
    {
        if (isActive == _value)
            return;
        isActive = _value;
        gameObject.SetActive(isActive);
    }
    /// <summary>
    /// Setup del menù
    /// </summary>
    /// <param name="_UIManagerBase"></param>
    public void Setup(UI_ManagerBase _UIManagerBase)
    {
        ManagerBase = _UIManagerBase;
        isActive = true;
    }
    /// <summary>
    /// Funzione che ritorna il valore true o false del menù attivo
    /// </summary>
    /// <returns></returns>
    public bool IsMenuActive()
    {
        return isActive;
    }
    /// <summary>
    /// Funzione chiamata al Setup della classe base
    /// </summary>
    /// <returns></returns>
    protected virtual void OnSetup()
    {

    }
}
