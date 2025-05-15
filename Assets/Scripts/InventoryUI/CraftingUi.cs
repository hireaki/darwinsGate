using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class CraftingUi : MonoBehaviour
{
    public GameObject menuUi;
    public GameObject mainInventory;
    public GameObject craftingInventory;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleCrafting()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            menuUi.SetActive(false);
            CopyAllChildren();
        }
        else
        {
            gameObject.SetActive(false);
            menuUi.SetActive(true);
            ClearAllChildren();
        }
    }


    private void CopyAllChildren()
    {
        if (mainInventory == null) return;
        List<Transform> children = new List<Transform>();
        foreach (Transform child in mainInventory.transform)
        {
            children.Add(child);
        }
        foreach (Transform child in children)
        {
            CopyChildRecursive(child);
        }
    }

    private void CopyChildRecursive(Transform source)
    {
        // Instantiate a copy of the source under the given parent
        source.SetParent(craftingInventory.transform, false);
        foreach (Transform child in source.transform)
        {
            child.GetComponent<RectTransform>().localScale = new Vector3(0.37f, 0.37f, 0.37f);
        }
    }

    private void ClearAllChildren()
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in craftingInventory.transform)
        {
            children.Add(child);
        }
        foreach (Transform child in children)
        {
            child.SetParent(mainInventory.transform, false);
            foreach (Transform items in child.transform)
            {
                items.GetComponent<RectTransform>().localScale = new Vector3(0.68f, 0.68f, 0.68f);
            }
        }

    }

}
