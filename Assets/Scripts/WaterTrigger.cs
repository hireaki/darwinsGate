using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (other.CompareTag("Player"))
        {
            triggered = true;
            FindObjectOfType<QuestManager>().CompleteQuest();
        }
    }
}
