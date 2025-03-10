using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private string[] speaker;
    [SerializeField][TextArea] private string[] dialogueWords;
    [SerializeField] private Sprite[] portrait;
    

    private bool isPlayerNear;
    private bool isDialogueActive;
    private int step;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && isPlayerNear)
        {
            if (!isDialogueActive)
            {
                StartDialogue();
            }
            else
            {
                NextDialogueLine();
            }
        }
    }

    private void StartDialogue()
    {
        isDialogueActive = true;
        dialogueCanvas.SetActive(true);
        playerMovement.enabled = false;
        step = 0;
        ShowDialogue();
    }

    private void NextDialogueLine()
    {
        step++;
        if (step >= speaker.Length)
        {
            EndDialogue();
        }
        else
        {
            ShowDialogue();
        }
    }

    private void ShowDialogue()
    {
        speakerText.text = speaker[step];
        dialogueText.text = dialogueWords[step];
        portraitImage.sprite = portrait[step];
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialogueCanvas.SetActive(false);
        playerMovement.enabled = true;

        SceneManager.LoadScene(2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
