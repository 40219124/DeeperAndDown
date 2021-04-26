using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressFeedback : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    [SerializeField]
    private FileManager Files;
    [SerializeField]
    private WormManager Worm;

    private void OnEnable()
    {
        GameEvents.OnGameStart += UpdateText;
        GameEvents.OnFolderChanged += UpdateText;
        GameEvents.OnWormMove += UpdateText;
    }
    private void OnDisable()
    {
        GameEvents.OnGameStart -= UpdateText;
        GameEvents.OnFolderChanged -= UpdateText;
        GameEvents.OnWormMove -= UpdateText;
    }

    private void UpdateText()
    {
        Text.text = ($"Folders Entered:\n {Files.UserDepth}\nWorm Depth:\n {Worm.WormDepth}");
    }
}
