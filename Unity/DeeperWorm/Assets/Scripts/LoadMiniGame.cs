using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMiniGame : MiniBehaviour, IOurClickable
{
    [SerializeField] Slider Bar;
    [SerializeField] float Speed;
    float Progress;
    bool Started;
    bool Completed;

    public void Clicked()
    {
        if (GameAssistant.Running)
        {
            Started = true;
        }
    }

    public override void MiniUpdate()
    {
        if (Completed)
        {
            return;
        }

        if (Started)
        {
            Progress += Speed * Time.deltaTime;
        }

        Bar.value = Progress;

        if (Progress >= 1)
        {
            Completed = true;
            GetComponentInParent<MinigameController>().MiniGameSuccess(true);
        }
    }
}
