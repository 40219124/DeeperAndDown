using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    private List<MiniBehaviour> Minis = new List<MiniBehaviour>();

    [SerializeField]
    private Transform GameRender;
    [SerializeField]
    private Transform GameHost;
    [SerializeField]
    private Transform CurrentGame;

    public bool IsSimulating = false;
    public bool IsRendering = false;

    [SerializeField]
    private List<Transform> Minigames = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        SetRendering(false);
        if(CurrentGame == null)
        {
            PrepRandomGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSimulating)
        {
            foreach (MiniBehaviour m in Minis)
            {
                m.MiniUpdate();
            }
        }
    }

    public void SetRendering(bool state)
    {
        IsRendering = state;
        UpdateRenderCanvas();
    }

    public void PrepRandomGame()
    {
        CurrentGame = Instantiate(Minigames[Random.Range(0, Minigames.Count)], GameHost);
        IsSimulating = false;
        SetRendering(false);
    }

    public void StartGame()
    {
        SetRendering(true);
        IsSimulating = true;
        UpdateRenderCanvas();
    }

    private void UpdateRenderCanvas()
    {
        GameRender.gameObject.SetActive(IsRendering);
    }

    public void AddMini(MiniBehaviour mini)
    {
        Minis.Add(mini);
    }

    public void MiniGameSuccess(bool success)
    {
        if (CurrentGame != null)
        {
            Destroy(CurrentGame.gameObject);
            Minis.Clear();
            CurrentGame = null;
            SetRendering(false);
            IsSimulating = false;
            UpdateRenderCanvas();
        }
        GameEvents.MinigameFinished(success);
        if (!success)
        {
            // ~~~ punish
        }
        PrepRandomGame();
    }
}
