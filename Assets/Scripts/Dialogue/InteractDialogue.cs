using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractDialogue : MonoBehaviour
{
    // UI References
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private Button nextButton; // ✅ Interact Button for mobile

    // Dialogue Content
    [SerializeField] public string[] speaker;
    [SerializeField][TextArea] public string[] dialogueWords;
    [SerializeField] private Sprite[] portrait;

    private bool dialogueActivated;
    private int step;

    private void Start()
    {
        // ✅ Link mobile button if assigned
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(() =>
            {
                if (dialogueActivated && dialogueCanvas.activeSelf)
                    NextDialogueLine();
            });
        }
    }

    void Update()
    {
        //if (Input.GetButtonDown("Interact") && dialogueActivated)
        //{
        //    if (!dialogueCanvas.activeSelf)
        //    {
        //        StartDialogue();
        //    }
        //    else
        //    {
        //        NextDialogueLine();
        //    }
        //}
    }

    public void StartDialogue()
    {
        dialogueActivated = true;
        dialogueCanvas.SetActive(true);
        step = 0;
        ShowDialogue();
    }

    private void NextDialogueLine()
    {
        Debug.Log("Next Dialogue Line");
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
        dialogueCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogueActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueActivated = false;
        dialogueCanvas.SetActive(false);
    }
}
