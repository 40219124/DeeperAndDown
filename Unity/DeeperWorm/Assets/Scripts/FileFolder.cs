using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FileFolder : MonoBehaviour, IOurClickable
{
    public string FolderName = "Default";
    [SerializeField]
    private TextMeshProUGUI FolderNameText;
    [SerializeField]
    private float DoubleClickTime = 0.2f;
    private float LastClicked;

    private readonly char[] Consanants = { 'k', 's', 't', 'h', 'm', 'n', 'y', 'r', 'w' };
    private readonly char[] Vowels = { 'a', 'i', 'u', 'e', 'o' };

    private void Awake()
    {
        LastClicked = -DoubleClickTime * 2.0f;
        PickName();
    }

    private void PickName()
    {
        FolderName = "";
        int nameLength = Random.Range(2, 11);
        while (FolderName.Length < nameLength)
        {
            if (FolderName.Length % 2 == 0)
            {
                FolderName += Consanants[Random.Range(0, Consanants.Length)];
            }
            else
            {
                FolderName += Vowels[Random.Range(0, Vowels.Length)];
            }
        }
        UpdateText();
    }

    private void UpdateText()
    {
        FolderNameText.text = FolderName;
    }

    public void Clicked()
    {
        if (DoubleClicked())
        {
            GetComponentInParent<FileManager>().EnterFolder(this);
        }

        LastClicked = Time.time;
    }

    private bool DoubleClicked()
    {
        return (Time.time - LastClicked) < DoubleClickTime;
    }
}
