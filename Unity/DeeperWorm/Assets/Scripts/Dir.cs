using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dir
{

    public string Name { get; set; }
    public Dir CorrectDir { get; set; }
    public Dir Parent { get; set; }
    public List<Dir> Children = new List<Dir> { };
    public bool IsCorrect { get; set; }
    public bool IsRoot { get; set; }

    private int numChildren;
    private readonly char[] consanants = { 'k', 's', 't', 'h', 'm', 'n', 'y', 'r', 'w' };
    private readonly char[] vowels = { 'a', 'i', 'u', 'e', 'o' };

    public Dir()
    {
        //set root bool, set correct as it's the only option
        IsRoot = true;
        IsCorrect = true;
        Name = "root";

        //make children
        MakeChildren();


        Parent = null;

        Debug.Log("root node constructed");
    }

    public Dir(Dir parent)
    {
        Parent = parent;
        PickName();
        Debug.Log($"Child of {parent.Name} constructed.");
    }

    private void PickName()
    {
        Name = "";
        int nameLength = Random.Range(2, 11);
        while (Name.Length < nameLength)
        {
            if (Name.Length % 2 == 0)
            {
                Name += consanants[Random.Range(0, consanants.Length)];
            }
            else
            {
                Name += vowels[Random.Range(0, vowels.Length)];
            }
        }
    }

    public void MakeChildren()
    {
        Debug.Log($"Generating children for {Name}");
        if (IsCorrect)
        {
            numChildren = Random.Range(2, 11);

            for (int i = 0; i < numChildren; i++)
            {
                Dir d = new Dir(this);
                Children.Add(d);
            }

            int randCorrect = Random.Range(0, numChildren);
            Children[randCorrect].IsCorrect = true;
            CorrectDir = Children[randCorrect];
            Debug.Log($"Child number {randCorrect}, {CorrectDir.Name} is the correct directory.");
        }
        else
        {
            Debug.LogWarning("Trying to make incorrect directory have children.");
        }
    }


}