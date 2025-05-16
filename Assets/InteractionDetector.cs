using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    public GameObject interactionIcon;
    public GameObject interadctButton;
    Chest chest;

    void Start()
    {
        //interactionIcon.SetActive(false);
    }

    public void Interact()
    {
        chest.Interact();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Chest>())
        {
            chest = collision.GetComponent<Chest>();
            if (chest.IsOpened)
            {
                return;
            }
            interactionIcon.SetActive(true);
            interadctButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Chest>())
        {
            interactionIcon.SetActive(false);
            interadctButton.SetActive(false);
        }
    }
}
