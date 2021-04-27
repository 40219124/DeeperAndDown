using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void GameEnd(bool success)
    {
        Running = false;
        if (!success)
        {
            SceneManager.LoadScene("GameFail");
        }
    }

    private void GameStart()
    {
        Running = true;
    }
}
