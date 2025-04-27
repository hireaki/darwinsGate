using System.Collections;
using UnityEngine;
using TMPro;

public class NotificationPanel : MonoBehaviour
{
    public TMP_Text notificationText;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ShowNotification(string message)
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);

        notificationText.text = message;
        StartCoroutine(HideNotification());
    }

    private IEnumerator HideNotification()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
