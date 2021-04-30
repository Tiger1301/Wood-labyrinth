using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class UI_ManagerBase : MonoBehaviour
{
    /// <summary>
    /// lista dei menu
    /// </summary>
    protected List<UI_MenuBase> menues;
    /// <summary>
    /// menu attualmente selezionato
    /// </summary>
    protected UI_MenuBase CurrentMenu;

    /// <summary>
    /// Funzione che ritorna il menu attivo
    /// </summary>
    /// <returns> menu attualmente attivo </returns>
    UI_MenuBase GetCurrentMenu()
    {
        return CurrentMenu;
    }
    /// <summary>
    /// Funzione chiamata al setup della classe base
    /// </summary>
    protected virtual void OnSetup()
    {

    }
    /// <summary>
    /// Setup della classe
    /// </summary>
    public void Setup()
    {
        menues = GetComponentsInChildren<UI_MenuBase>().ToList();
        foreach(UI_MenuBase item in menues)
            item.Setup(this);

        OnSetup();
    }
}
