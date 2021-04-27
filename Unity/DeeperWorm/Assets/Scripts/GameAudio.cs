using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource Click;
    [SerializeField]
    private AudioSource MiniOpen;
    [SerializeField]
    private AudioSource MiniWin;
    [SerializeField]
    private AudioSource MiniFail;

    private void OnEnable()
    {
        GameEvents.OnFolderChanged += FolderChange;
        GameEvents.OnMinigameStart += MinigameOpen;
        GameEvents.OnMinigameWin += MinigameWin;
        GameEvents.OnMinigameFail += MinigameFail;
    }

    private void OnDisable()
    {
        GameEvents.OnFolderChanged -= FolderChange;
        GameEvents.OnMinigameStart -= MinigameOpen;
        GameEvents.OnMinigameWin -= MinigameWin;
        GameEvents.OnMinigameFail -= MinigameFail;
    }

    private void FolderChange()
    {
        Click.Play();
    }

    private void MinigameOpen()
    {
        MiniOpen.Play();
    }

    private void MinigameWin()
    {
        MiniWin.Play();
    }

    private void MinigameFail()
    {
        MiniFail.Play();
    }
}
