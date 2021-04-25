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
    List<RectTransform> Folders = new List<RectTransform>();
    private Dir currentDir;

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
        if (currentDir.CorrectDir is null)
        {
            Debug.Log("No correct directory available.");
        }
        else
        {
            Debug.Log($"Correct Directory is {currentDir.CorrectDir.Name}");
        }
    }

    private void AddFolders()
    {
        //only runs if children is populated
        for (int i = 0; i < currentDir.Children.Count; i++)
        {
            Folders.Add(Instantiate(FolderPrefab, FolderOrganiser));
            Folders[i].gameObject.GetComponent<FileFolder>().SetDirectory(currentDir.Children[i]);
        }
    }

    private int FoldersToMake()
    {
        return Random.Range(1, 15);
    }
}
