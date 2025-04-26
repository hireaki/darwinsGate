using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestPage : MonoBehaviour
{
    public Transform content;
    public GameObject questEntryPrefab;
    private List<GameObject> questEntries = new List<GameObject>();

    public void AddQuest(string questTitle, string objectiveText)
    {
        GameObject newQuest = Instantiate(questEntryPrefab, content);
        newQuest.SetActive(true);

        TMP_Text title = newQuest.transform.Find("QuestNameText").GetComponent<TMP_Text>();
        TMP_Text objective = newQuest.transform.Find("ObjectiveList/ObjectiveText").GetComponent<TMP_Text>();
        CanvasGroup cg = newQuest.GetComponent<CanvasGroup>();

        title.text = questTitle;
        objective.text = objectiveText;
        cg.alpha = 0.5f; // Dim first

        questEntries.Add(newQuest);
    }

    public void CompleteQuest(int questIndex)
    {
        if (questIndex < 0 || questIndex >= questEntries.Count)
            return;

        GameObject quest = questEntries[questIndex];
        TMP_Text objective = quest.transform.Find("ObjectiveList/ObjectiveText").GetComponent<TMP_Text>();
        CanvasGroup cg = quest.GetComponent<CanvasGroup>();

        objective.fontStyle = FontStyles.Strikethrough;
        cg.alpha = 0.3f; // More faded
    }

    public void HighlightQuest(int questIndex)
    {
        if (questIndex < 0 || questIndex >= questEntries.Count)
            return;

        GameObject quest = questEntries[questIndex];
        CanvasGroup cg = quest.GetComponent<CanvasGroup>();
        cg.alpha = 1f; // Full highlight
    }
}
