using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private string[] speaker;
    [SerializeField][TextArea] private string[] dialogueWords;
    [SerializeField] private Sprite[] portrait;
    [SerializeField] private Button interactButton;

    private bool isDialogueActive;
    private int step;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        StartDialogue();

        if (interactButton != null)
            interactButton.onClick.AddListener(NextDialogueLine);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && isDialogueActive)
        {
            NextDialogueLine();
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
    }
}
