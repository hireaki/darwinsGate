using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestEntryUI : MonoBehaviour
{
    public TMP_Text questNameText;
    public TMP_Text objectiveText;
    public CanvasGroup canvasGroup; // Control transparency

    public void SetupQuest(string objective)
    {
        questNameText.text = "Quest";
        objectiveText.text = objective;
        canvasGroup.alpha = 1f; // fully visible
    }

    public void CompleteQuest()
    {
        objectiveText.fontStyle = FontStyles.Strikethrough;
        canvasGroup.alpha = 0.5f; // faded
    }

    public void SetInactive()
    {
        canvasGroup.alpha = 0.5f; // faded for old quests
    }
}
