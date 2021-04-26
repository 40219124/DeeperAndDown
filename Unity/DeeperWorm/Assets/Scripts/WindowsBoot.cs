using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsBoot : MonoBehaviour
{
    [SerializeField]
    private AudioSource Audio;
    [SerializeField]
    private GameObject BootImage;

    // Update is called once per frame
    void Update()
    {
        if(Audio.time / Audio.clip.length > 0.7f)
        {
            BootImage.SetActive(false);
        }
    }
}
