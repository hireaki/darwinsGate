using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TablesItemInteractPopUp : MonoBehaviour
{
    public GameObject Interact;
    public float delay = 2f;
    public GameObject interactButton;

    private Coroutine showRoutine;
    [SerializeField][TextArea] private string[] dialogueWords;

    void Start()
    {
        Interact.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interact.SetActive(true);
            interactButton.SetActive(true);
            interactButton.GetComponent<InteractDialogue>().dialogueWords = dialogueWords;
            interactButton.GetComponent<InteractDialogue>().speaker[0] = gameObject.name;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interact.SetActive(false);
            interactButton.SetActive(false);

        }
    }
}

