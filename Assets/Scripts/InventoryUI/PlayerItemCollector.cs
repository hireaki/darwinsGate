using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
   private InvetoryController inventoryController;

    private void Start()
    {
        inventoryController = FindObjectOfType<InvetoryController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                
                bool itemAdded = inventoryController.AddItem(collision.gameObject);

                if (itemAdded)
                {
                    item.Pickup();
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
