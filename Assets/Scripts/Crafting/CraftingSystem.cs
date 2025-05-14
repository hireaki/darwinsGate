using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public Slot[] craftingSlots;
    public Slot resultSlot; 
    public List<CraftingRecipe> recipes;

    public void Craft()
    {
        List<string> currentItemNames = new List<string>();
        currentItemNames.Clear();
        foreach (Slot slot in craftingSlots)
        {
            if (slot.currentItem != null)
            {
                Item item = slot.currentItem.GetComponent<Item>();
                currentItemNames.Add(item != null ? item.Name : "");
            }
            else
            {
                currentItemNames.Add("");
            }
        }

        foreach (CraftingRecipe recipe in recipes)
        {
            if (recipe.Matches(currentItemNames))
            {
                foreach (Slot slot in craftingSlots)
                {
                    if (slot.currentItem != null)
                    {
                        Destroy(slot.currentItem);
                        slot.currentItem = null;
                    }
                }
                GameObject resultItem = Instantiate(recipe.resultPrefab, resultSlot.transform);
                resultSlot.currentItem = resultItem;
                return;
            }
        }

        // No match found
        resultSlot.currentItem = null;
    }
}
