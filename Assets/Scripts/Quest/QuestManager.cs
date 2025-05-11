using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestPage questPage;
    public NotificationPanel notificationPanel;
    public PlayerLevelSystem levelSystem;

    private int currentQuestIndex = 0;
    private List<(string, string)> quests = new List<(string, string)>();

    void Start()
    {
        quests.Add(("Water?", "Walk through the shallow water"));
        quests.Add(("What's this?", "Find and pick up a rock"));
        quests.Add(("How to get across?", "Jump across the Obstacle"));

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
        levelSystem.GainXP(1); // Give 1 XP per quest
        notificationPanel.ShowNotification($"Quest Compeleted: {quests[currentQuestIndex].Item1}");

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

        return quests[currentQuestIndex].Item2 == objective;
    }

}
