using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectiveManager : MonoBehaviour
{
    public Text objectiveText;
    public Text notificationText;
    public GameObject inventoryUI;

    private int currentObjectiveIndex = 0;
    private bool questActive = false;

    private List<string> objectives = new List<string>()
    {
        "Walk to the shallow water",
        "Grab the rock",
        "Jump over the obstacle"
    };

    void Start()
    {
        objectiveText.text = "";
        notificationText.text = "";
    }

    public void StartQuest()
    {
        questActive = true;
        ShowObjective();
    }

    public void CompleteObjective()
    {
        if (!questActive) return;

        currentObjectiveIndex++;

        if (currentObjectiveIndex >= objectives.Count)
        {
            objectiveText.text = "All objectives complete!";
            notificationText.text = "Quest Completed!";
            questActive = false;
        }
        else
        {
            notificationText.text = "Objective Complete! New Objective!";
            ShowObjective();
        }
    }

    private void ShowObjective()
    {
        if (currentObjectiveIndex < objectives.Count)
        {
            objectiveText.text = objectives[currentObjectiveIndex];
        }
    }
}
