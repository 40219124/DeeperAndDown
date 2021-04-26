using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    [SerializeField]
    WormManager Worm;
    [SerializeField]
    FileManager FileBrowser;
    [SerializeField]
    MinigameController MinigameController;

    private readonly int MinDist = 10;
    private readonly float MinDistDelay = 5.0f;
    private readonly int MaxDist = 50;
    private readonly float MaxDistDelay = 10.0f;

    private float LastGameEnd = 0.0f;

    private void OnEnable()
    {
        GameEvents.OnFolderChanged += FolderChange;
        GameEvents.OnMinigameWin += MinigameWon;
    }

    private void OnDisable()
    {
        GameEvents.OnFolderChanged -= FolderChange;
        GameEvents.OnMinigameWin -= MinigameWon;
    }

    private void FolderChange()
    {
        if(Time.time - LastGameEnd > TimeToWait())
        {
            MinigameController.StartGame();
        }
    }

    private void MinigameWon()
    {
        LastGameEnd = Time.time;
    }

    private float TimeToWait()
    {
        if (Worm.WormDepth == FileBrowser.UserDepth)
        {
            return float.MaxValue;
        }
        int distToWorm = Worm.WormDepth - FileBrowser.UserDepth;
        float distRatio = (float)(distToWorm - MinDist) / (float)MaxDist;
        distRatio = Mathf.Clamp01(distRatio);

        float delay = MinDistDelay + ((MaxDistDelay - MinDistDelay) * distRatio);
        return delay;
    }
}
