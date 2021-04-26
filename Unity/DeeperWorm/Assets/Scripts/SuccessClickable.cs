using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessClickable : MonoBehaviour, IOurClickable
{
    public void Clicked()
    {
        GetComponentInParent<MinigameController>().MiniGameSuccess(true);
    }
}
