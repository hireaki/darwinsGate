using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TablesItemInteractPopUp : MonoBehaviour
{
    public GameObject Interact;
    public float delay = 2f;
    public GameObject interactButton;
    public int interactionLevelNeeded;
    public string nextScene = null;

    private Coroutine showRoutine;
    [SerializeField] public string[] speaker;
    [SerializeField][TextArea] public string[] dialogueWords;
    [SerializeField] private Sprite[] portrait;

    GameObject player;

    void Start()
    {
        Interact.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionLevelNeeded <= Interaction_Manager.instance.interactionLevel)
        {
            Interact.SetActive(true);
            interactButton.SetActive(true);
            interactButton.GetComponent<InteractDialogue>().dialogueWords = dialogueWords;
            interactButton.GetComponent<InteractDialogue>().speaker = speaker;
            interactButton.GetComponent<InteractDialogue>().portrait = portrait;
            interactButton.GetComponent<InteractDialogue>().nextScene = nextScene;
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

