using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessClickable : MonoBehaviour, IOurClickable
{
    [SerializeField] bool RestartGame;
    public void Clicked()
    {
        if (GameAssistant.Running)
        {
            GetComponentInParent<MinigameController>().MiniGameSuccess(true);

            if (RestartGame)
            {
                SceneManager.LoadScene("Opening");
            }
        }
    }
}
