using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsClickable : MonoBehaviour, IOurClickable
{
    [SerializeField]
    private RectTransform SettingsMenu;

    public void Clicked()
    {
        SettingsMenu.gameObject.SetActive(!SettingsMenu.gameObject.activeInHierarchy);
    }
}
