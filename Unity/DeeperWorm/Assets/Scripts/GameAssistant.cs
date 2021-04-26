using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssistant : MonoBehaviour
{
    public static Camera MainCamera;
    public static bool Running = false;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
    }

    private void OnEnable()
    {
        GameEvents.OnGameStart += GameStart;
        GameEvents.OnGameEnd += GameEnd;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStart -= GameStart;
        GameEvents.OnGameEnd -= GameEnd;
    }

    private void GameEnd(bool _)
    {
        Running = false;
    }

    private void GameStart()
    {
        Running = true;
    }
}
