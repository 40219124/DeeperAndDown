using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingsClickable : MonoBehaviour, IOurClickable
{
    [SerializeField]
    SettingsClickable Controller;

    public void Clicked()
    {
        Controller.Clicked();
    }
}
