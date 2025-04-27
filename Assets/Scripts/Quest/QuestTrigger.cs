using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public string questObjectiveName;
    public QuestManager questManager;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger!");

            if (questManager != null && questManager.CheckCurrentObjective(questObjectiveName))
            {
                Debug.Log("Correct objective, completing quest!");
                triggered = true;
                questManager.CompleteCurrentQuest();
            }
            else
            {
                Debug.Log("Objective mismatch or QuestManager missing.");
            }
        }
    }
}
