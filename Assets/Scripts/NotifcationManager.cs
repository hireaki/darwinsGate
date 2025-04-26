using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public GameObject notificationPanel;
    public TextMeshProUGUI notificationText;

    public void ShowNotification(string message)
    {
        notificationPanel.SetActive(true);
        notificationText.text = message;
        Invoke("HideNotification", 2f);
    }

    private void HideNotification()
    {
        notificationPanel.SetActive(false);
    }
}
