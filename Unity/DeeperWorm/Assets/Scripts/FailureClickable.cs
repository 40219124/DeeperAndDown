using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureClickable : MonoBehaviour, IOurClickable
{
    public void Clicked()
    {
        if (GameAssistant.Running)
        {
            GetComponentInParent<MinigameController>().MiniGameSuccess(false);
        }
    }
}
