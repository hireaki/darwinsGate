using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroDialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public Image characterImage;
    public TMP_Text speakerText;
    public Button interactButton;

    [Header("Dialogue Content")]
    [TextArea(2, 5)] public string[] lines;
    public string[] speakerNames;
    public Sprite[] speakerSprites;

    [Header("Scene Settings")]
    public string nextSceneName = "MainGame";

    private int currentLine = 0;

    void Start()
    {
        ShowLine(); // Auto-show first line when scene starts
        interactButton.onClick.AddListener(OnInteractButtonPressed); // Hook up mobile button
    }

    public void OnInteractButtonPressed()
    {
        currentLine++;
        if (currentLine < lines.Length)
        {
            ShowLine();
        }
        else
        {
            SceneManager.LoadScene(nextSceneName); // Go to next scene after last dialogue
        }
    }

    void ShowLine()
    {
        dialogueText.text = lines[currentLine];

        if (currentLine < speakerNames.Length)
            speakerText.text = speakerNames[currentLine];

        if (currentLine < speakerSprites.Length)
            characterImage.sprite = speakerSprites[currentLine];
    }
}
