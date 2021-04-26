using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormClickable : MonoBehaviour, IOurClickable
{
    public void Clicked()
    {
        if (GameAssistant.Running)
        {
            GameEvents.GameEnd(true);
        }
    }
}
