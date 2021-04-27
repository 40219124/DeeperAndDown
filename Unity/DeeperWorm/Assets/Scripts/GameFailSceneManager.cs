using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameFailSceneManager : MonoBehaviour
{
    [SerializeField]
    VideoPlayer Video;

    bool Started = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForStart());
    }

    private IEnumerator WaitForStart()
    {
        while (!Video.isPlaying)
        {
            yield return null;
        }
        StartCoroutine(WaitForEnd());
    }

    private IEnumerator WaitForEnd()
    {
        while (Video.isPlaying)
        {
            yield return null;
        }
        StartCoroutine(WaitToContinue());
    }

    private IEnumerator WaitToContinue()
    {
        for(float waitTime = 0.0f; waitTime < 3.0f; waitTime += Time.deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                break;
            }
            yield return null;
        }
        SceneManager.LoadScene("Opening");
    }
}
