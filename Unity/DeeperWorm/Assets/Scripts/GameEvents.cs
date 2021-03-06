using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action OnFolderChanged;
    public static event Action OnWormMove;
    public static event Action OnGameStart;
    public static event Action<bool> OnGameEnd;
    public static event Action OnMinigameStart;
    public static event Action OnMinigameWin;
    public static event Action OnMinigameFail;

    public static void WormMoved()
    {
        OnWormMove?.Invoke();
    }

    public static void FolderChanged()
    {
        OnFolderChanged?.Invoke();
    }

    public static void StartMainGame()
    {
        OnGameStart?.Invoke();
    }

    public static void StartMinigame()
    {
        OnMinigameStart?.Invoke();
    }

    public static void MinigameFinished(bool success)
    {
        if (success)
        {
            OnMinigameWin?.Invoke();
        }
        else
        {
            OnMinigameFail?.Invoke();
        }
    }

    public static void GameEnd(bool won)
    {
        OnGameEnd?.Invoke(won);
    }
}
