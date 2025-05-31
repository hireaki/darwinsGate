using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestPage questPage;
    public NotificationPanel notificationPanel;
    public PlayerLevelSystem levelSystem;
     public List<QuestModel> quests;

    private int currentQuestIndex = 0;

    void Start()
    {
        //quests.Add(("Water?", "Walk through the shallow water"));
        //quests.Add(("What's this?", "Find and pick up a rock"));
        //quests.Add(("How to go up?", "Jump across the Platform"));

        AddQuest(currentQuestIndex);
    }

    void AddQuest(int index)
    {
        if (index >= quests.Count)
            return;

        questPage.AddQuest(quests[index].Title, quests[index].Description);
        questPage.HighlightQuest(index);
        notificationPanel.ShowNotification($"New Quest: {quests[index].Title}");
    }

    public void CompleteCurrentQuest()
    {
        questPage.CompleteQuest(currentQuestIndex);
        levelSystem.GainXP(1); // Give 1 XP per quest
        notificationPanel.ShowNotification($"Quest Compeleted: {quests[currentQuestIndex].Title}");

        currentQuestIndex++;

        if (currentQuestIndex < quests.Count)
        {
            AddQuest(currentQuestIndex);
        }
    }
    public bool CheckCurrentObjective(string objective)
    {
        if (currentQuestIndex >= quests.Count)
            return false;

        return quests[currentQuestIndex].Description == objective;
    }

    [System.Serializable]
    public class QuestModel
    {
        public string Title;
        public string Description;
    }
}
