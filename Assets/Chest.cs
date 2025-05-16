using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public bool IsOpened = false;
    public string ChestID { get; private set; }
    public GameObject itemPrefab;
    public Sprite lootedSprite;

    void Start()
    {
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObject);
    }

    public bool CanInteract()
    {
        return IsOpened;
    }

    public void Interact()
    {
        if (CanInteract()) return;
        OpenChest();
    }

    private void OpenChest()
    {
        SetOpened(true);

        if (itemPrefab)
        {
            GameObject droppedItem = Instantiate(itemPrefab, transform.position + Vector3.down, Quaternion.identity);
            droppedItem.GetComponent<BounceFX>().StartBounce();    
        }
    }

    public void SetOpened(bool opened)
    {
        
        if (IsOpened = opened)
        {
            GetComponent<SpriteRenderer>().sprite = lootedSprite;
        }
    }
}
