using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameClickable : MonoBehaviour, IOurClickable
{
    public void Clicked()
    {
        GameEvents.StartMainGame();
        Destroy(GetComponentInParent<Canvas>().gameObject);
    }
}
