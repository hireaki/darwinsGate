using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public Animator objectiveAnimator;
    public TextMeshProUGUI objectiveText;
    public UnityEngine.UI.Image checkmarkImage;

    public Transform player;
    public Transform shallowWaterPoint;

    private bool hasWalked = false;
    private bool hasShownObjective = false;

    void Start()
    {
        checkmarkImage.enabled = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, shallowWaterPoint.position);

        if (!hasShownObjective && distance < 5f)
        {
            ShowObjective("Walk to the shallow water.");
            hasShownObjective = true;
        }

        if (!hasWalked && distance < 2f)
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
        hasWalked = true;
        checkmarkImage.enabled = true;
        Invoke(nameof(NextObjective), 2f);
    }

    void NextObjective()
    {
        checkmarkImage.enabled = false;
        ShowObjective("Grab the rock.");
    }
}
