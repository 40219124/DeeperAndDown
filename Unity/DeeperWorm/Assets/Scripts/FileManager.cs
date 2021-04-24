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

    private void Start()
    {
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
        AddFolders();
    }

    private void AddFolders()
    {
        for (int i = 0, j = FoldersToMake(); i < j; ++i)
        {
            Folders.Add(Instantiate(FolderPrefab, FolderOrganiser));
        }
    }

    private int FoldersToMake()
    {
        return Random.Range(1, 15);
    }
}
