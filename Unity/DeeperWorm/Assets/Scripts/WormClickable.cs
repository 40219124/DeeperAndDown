using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormClickable : MonoBehaviour, IOurClickable
{
    [SerializeField]
    private GameObject Letter;
    public void Clicked()
    {
        if (GameAssistant.Running)
        {
            GameEvents.GameEnd(true);
            Letter.SetActive(true);
        }
    }
}
