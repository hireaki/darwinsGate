using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerItemCollector : MonoBehaviour
{
    private InvetoryController inventoryController;
    public QuestManager questManager;
    bool completed = false;
    private void Start()
    {
        inventoryController = FindObjectOfType<InvetoryController>();
        questManager = FindObjectOfType<QuestManager>();
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
                    if (!completed && SceneManager.GetActiveScene().Equals("Afarensis"))
                    {
                        completed = true;
                        questManager.CompleteCurrentQuest();
                    }
                }
            }
        }
    }
}
