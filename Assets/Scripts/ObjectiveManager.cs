using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public Animator objectiveAnimator;
    public TextMeshProUGUI objectiveText;
    public UnityEngine.UI.Image checkmarkImage;

    public Transform player;
    public Transform shallowWaterTrigger;

    private bool hasWalkedToWater = false;

    void Start()
    {
        checkmarkImage.enabled = false;
        ShowObjective("Walk to the shallow water.");
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, shallowWaterTrigger.position);
        if (!hasWalkedToWater && distance < 2f)
        {
            CompleteObjective();
        }
    }

    public void ShowObjective(string text)
    {
        objectiveText.text = text;
        objectiveAnimator.SetTrigger("Show");
    }

    void CompleteObjective()
    {
        hasWalkedToWater = true;
        checkmarkImage.enabled = true;

        Invoke(nameof(NextObjective), 2f);
    }

    void NextObjective()
    {
        checkmarkImage.enabled = false;
        ShowObjective("Grab the rock.");
    }
}
