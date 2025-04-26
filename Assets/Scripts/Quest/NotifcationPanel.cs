using System.Collections;
using UnityEngine;
using TMPro;

public class NotificationPanel : MonoBehaviour
{
    public TMP_Text notificationText;
    public GameObject panel;

    public void ShowNotification(string message)
    {
        StopAllCoroutines();
        StartCoroutine(NotificationRoutine(message));
    }

    private IEnumerator NotificationRoutine(string message)
    {
        panel.SetActive(true);
        notificationText.text = message;
        yield return new WaitForSeconds(2.5f);
        panel.SetActive(false);
    }
}
