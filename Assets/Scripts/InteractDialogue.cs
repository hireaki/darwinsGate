using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractDialogue : MonoBehaviour
{
    // UI References
    [SerializeField]
    private GameObject dialogueCanvas;

    [SerializeField]
    private TMP_Text speakerText;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private Image portraitImage;

    //Dialogue Content
    [SerializeField]
    private string[] speaker;

    [SerializeField]
    [TextArea]
    private string[] dialogueWords;

    [SerializeField]
    private Sprite[] portrait;

    private bool dialogueActivated;
    private int step;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && dialogueActivated)
        {
            if (!dialogueCanvas.activeSelf)
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
        dialogueCanvas.SetActive(true);
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