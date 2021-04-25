using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FileFolder : MonoBehaviour, IOurClickable
{
    public Dir Directory { get; private set; }
    public string FolderName = "Default";
    [SerializeField]
    private TextMeshProUGUI FolderNameText;
    [SerializeField]
    private float DoubleClickTime = 0.2f;
    private float LastClicked;


    public void SetDirectory(Dir dir)
    {
        Directory = dir;
        FolderName = dir.Name;
        UpdateText();
    }


    private void Awake()
    {
        LastClicked = -DoubleClickTime * 2.0f;
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
