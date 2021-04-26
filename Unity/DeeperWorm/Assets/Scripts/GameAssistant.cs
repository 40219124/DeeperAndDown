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
    }

    private void OnDisable()
    {
        GameEvents.OnGameStart -= GameStart;
    }

    private void GameStart()
    {
        Running = true;
    }
}
