using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FileManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI CurrentFolder;
    [SerializeField]
    private RectTransform FolderPrefab;
    [SerializeField]
    private RectTransform WormPrefab;
    [SerializeField]
    private RectTransform FolderOrganiser;
    [SerializeField]
    public RectTransform CorrectFolderPrefab;
    [SerializeField]
    private WormManager Worm;
    List<RectTransform> Folders = new List<RectTransform>();
    private Dir currentDir;

    public int UserDepth { get; private set; }

    private void Start()
    {
        //init root dir
        currentDir = new Dir();

        AddFolders();
    }

    public void EnterFolder(Dir newFolder)
    {
        StartCoroutine(EnterFolderDelayed(newFolder));
    }

    public void GoBackFolder()
    {
        if (currentDir.Parent != null)
        {
            EnterFolder(currentDir.Parent);
        }
    }

    private IEnumerator EnterFolderDelayed(Dir newFolder)
    {
        yield return null;

        if (currentDir.CorrectDir == newFolder)
        {
            UserDepth++;
        }
        else if (currentDir.Parent == newFolder)
        {
            UserDepth--;
        }

        CurrentFolder.text = newFolder.Name;
        foreach (RectTransform rect in Folders)
        {
            Destroy(rect.gameObject);
        }
        Folders.Clear();

        //if folder correct spawn next tier of folders, else leave empty

        if (newFolder.IsCorrect)
        {
            if (newFolder.Children.Count == 0)
            {
                newFolder.MakeChildren();
            }
        }

        currentDir = newFolder;

        if (UserDepth == Worm.WormDepth)
        {
            Instantiate(WormPrefab, FolderOrganiser);
        }
        else
        {
            AddFolders();
        }

        GameEvents.FolderChanged();
    }

    private void AddFolders()
    {
        //only runs if children is populated
        for (int i = 0; i < currentDir.Children.Count; i++)
        {
            Folders.Add(Instantiate(FolderPrefab, FolderOrganiser));
            Folders[i].gameObject.GetComponent<FileFolder>().SetDirectory(currentDir.Children[i]);
            if (currentDir.Children[i].IsCorrect)
            {
                Instantiate(CorrectFolderPrefab, Folders[i]);
            }
        }
    }
}
