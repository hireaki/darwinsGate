using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftingRecipe
{
    public List<string> requiredItemNames; // must match slot order
    public GameObject resultPrefab; // item to create

    public bool Matches(List<string> input)
    {
        if (input.Count != requiredItemNames.Count) return false;

        for (int i = 0; i < input.Count; i++)
        {
            if (!requiredItemNames[i].Contains(input[i])) return false;
        }

        return true;
    }
}
