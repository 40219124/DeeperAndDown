using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureClickable : MonoBehaviour, IOurClickable
{
    public void Clicked()
    {
        GetComponentInParent<MinigameController>().MiniGameSuccess(false);
    }
}
