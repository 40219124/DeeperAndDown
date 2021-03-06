using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFolderClickable : MonoBehaviour, IOurClickable
{
    [SerializeField]
    private FileManager FileBrowser;

    public void Clicked()
    {
        if (GameAssistant.Running)
        {
            FileBrowser.GoBackFolder();
        }
    }
}
