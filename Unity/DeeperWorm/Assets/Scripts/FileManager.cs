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
    private RectTransform FolderOrganiser;
    [SerializeField]
    public RectTransform CorrectFolderPrefab;
    List<RectTransform> Folders = new List<RectTransform>();
    private Dir currentDir;

    public int UserDepth { get; private set; }

    private void Start()
    {
        //init root dir
        currentDir = new Dir();

        AddFolders();
    }

    public void EnterFolder(FileFolder newFolder)
    {
        StartCoroutine(EnterFolderDelayed(newFolder));
    }

    private IEnumerator EnterFolderDelayed(FileFolder newFolder)
    {
        yield return null;

        if(currentDir.CorrectDir == newFolder.Directory)
        {
            UserDepth++;
        }
        else if(currentDir.Parent == newFolder.Directory)
        {
            UserDepth--;
        }

        CurrentFolder.text = newFolder.FolderName;
        foreach (RectTransform rect in Folders)
        {
            Destroy(rect.gameObject);
        }
        Folders.Clear();

        //if folder correct spawn next tier of folders, else leave empty

        if (newFolder.Directory.IsCorrect)
        {
            if (newFolder.Directory.Children.Count == 0)
            {
                newFolder.Directory.MakeChildren();
            }
        }

        currentDir = newFolder.Directory;
        AddFolders();
        /*if (currentDir.CorrectDir is null)
        {
            Debug.Log("No correct directory available.");
        }
        else
        {
            Debug.Log($"Correct Directory is {currentDir.CorrectDir.Name}");
        }*/

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
