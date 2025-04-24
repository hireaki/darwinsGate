using UnityEngine;

public class ShallowWaterTrigger2D : MonoBehaviour
{
    public ObjectiveManager objectiveManager;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            objectiveManager.ShowObjective("Walk to the shallow water.");
        }
    }
}
