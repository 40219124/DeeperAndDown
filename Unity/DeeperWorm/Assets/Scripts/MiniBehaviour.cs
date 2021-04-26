using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<MinigameController>().AddMini(this);
    }

    // Update is called once per frame
    public void MiniUpdate()
    {
        
    }
}
