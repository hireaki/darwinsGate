using UnityEngine;

public class ShallowWaterTrigger : MonoBehaviour
{
    public ObjectiveManager objectiveManager;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            objectiveManager.CompleteObjective();
            Destroy(gameObject); // remove trigger after
        }
    }
}
