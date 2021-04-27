using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonClickable : MonoBehaviour, IOurClickable
{
    public void Clicked()
    {
        SceneManager.LoadScene("Opening");
    }
}
