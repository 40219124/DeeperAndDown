using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormManager : MonoBehaviour
{
    private FileManager FileBrowser;

    public int WormDepth { get; private set; }

    private readonly int MinDist = 10;
    private readonly float MinDistDelay = 2.0f;
    private readonly int MaxDist = 50;
    private readonly float MaxDistDelay = 10.0f;

    private float LastDepthIncrease = 0.0f;

    private void OnEnable()
    {
        GameEvents.OnGameStart += GameStart;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStart -= GameStart;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetBrowser());
        WormDepth = 10;
        LastDepthIncrease = Time.time;
    }

    private IEnumerator GetBrowser()
    {
        while (FileBrowser == null)
        {
            FileBrowser = FindObjectOfType<FileManager>();
            yield return null;
        }
    }

    private void GameStart()
    {
        LastDepthIncrease = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameAssistant.Running)
        {
            if (Time.time - LastDepthIncrease > TimeToWait())
            {
                if (WormDepth >= 200)
                {
                    LastDepthIncrease = Time.time;
                    GameEvents.GameEnd(false);
                    return;
                }
                WormDepth++;
                Debug.Log($"Player depth: {FileBrowser.UserDepth}. Worm depth: {WormDepth}.");
                LastDepthIncrease = Time.time;
                GameEvents.WormMoved();
            }
        }
    }

    private float TimeToWait()
    {
        if (WormDepth == FileBrowser.UserDepth)
        {
            return float.MaxValue;
        }
        int distToWorm = WormDepth - FileBrowser.UserDepth;
        float distRatio = (float)(distToWorm - MinDist) / (float)MaxDist;
        distRatio = Mathf.Clamp01(distRatio);

        float delay = MinDistDelay + ((MaxDistDelay - MinDistDelay) * distRatio);
        return delay;
    }
}
