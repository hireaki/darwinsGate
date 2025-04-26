using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI questObjectiveText;
    public GameObject notificationPanel;
    public TextMeshProUGUI notificationText;

    private int currentQuest = 0;

    private void Start()
    {
        notificationPanel.SetActive(false);
        UpdateQuest("Walk to the shallow water.");
    }

    public void UpdateQuest(string message)
    {
        questObjectiveText.text = message;
    }

    public void ShowNotification(string message)
    {
        notificationPanel.SetActive(true);
        notificationText.text = message;
        CancelInvoke(nameof(HideNotification));
        Invoke(nameof(HideNotification), 3f);
    }

    private void HideNotification()
    {
        notificationPanel.SetActive(false);
    }

    public void CompleteQuest()
    {
        if (currentQuest == 0)
        {
            ShowNotification("Quest 1 Complete! New Quest: Grab a rock.");
            UpdateQuest("Grab a rock.");
            currentQuest++;
        }
        else if (currentQuest == 1)
        {
            ShowNotification("Quest 2 Complete! New Quest: Jump over obstacle.");
            UpdateQuest("Jump over obstacle.");
            currentQuest++;
        }
        else
        {
            ShowNotification("All quests complete!");
            UpdateQuest("Congratulations!");
        }
    }
}
