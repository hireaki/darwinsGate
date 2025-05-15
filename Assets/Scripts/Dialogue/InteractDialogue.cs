using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractDialogue : MonoBehaviour
{
    // UI References
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private Button nextButton;

    // Dialogue Content
    [SerializeField] public string[] speaker;
    [SerializeField][TextArea] public string[] dialogueWords;
    [SerializeField] public Sprite[] portrait;
    [SerializeField] public string nextScene;

    private bool dialogueActivated;
    private int step;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        player.GetComponent<PlayerMovement>().enabled = false;

        speakerText.text = speaker[step];
        dialogueText.text = dialogueWords[step];
        portraitImage.sprite = portrait[step];
    }

    public void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        Interaction_Manager.instance.interactionLevel++;
        if (nextScene != null)
        {
            SceneManager.LoadScene("Cave");
        }
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
