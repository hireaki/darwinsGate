using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestPage questPage;
    public NotificationPanel notificationPanel; // Para sa notif

    private int currentQuestIndex = 0;
    private List<(string, string)> quests = new List<(string, string)>();

    void Start()
    {
        quests.Add(("Walk to Water", "Walk through the shallow water"));
        quests.Add(("Pick up a Rock", "Find and pick up a rock"));
        quests.Add(("Deliver the Rock", "Bring the rock to the NPC"));

        AddQuest(currentQuestIndex);
    }

    void AddQuest(int index)
    {
        if (index >= quests.Count)
            return;

        questPage.AddQuest(quests[index].Item1, quests[index].Item2);
        questPage.HighlightQuest(index);
        notificationPanel.ShowNotification($"New Quest: {quests[index].Item1}");
    }

    public void CompleteCurrentQuest()
    {
        questPage.CompleteQuest(currentQuestIndex);
        currentQuestIndex++;

        if (currentQuestIndex < quests.Count)
        {
            AddQuest(currentQuestIndex);
        }
    }
}
