using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] private GameObject transitionObject; // Object with Animator
    [SerializeField] private Animator transitionAnim;
    [SerializeField] private float transitionTime = 1f;

    private void Start()
    {
        if (transitionObject != null)
            transitionObject.SetActive(false); // Start as inactive
    }

    public void OnStartClick()
    {
        if (transitionObject != null)
        {
            transitionObject.SetActive(true); // Activate it
            StartCoroutine(PlayTransitionThenLoad());
        }
        else
        {
            // Fallback if transition is not assigned
            SceneManager.LoadScene("Intro Scene");
        }
    }

    IEnumerator PlayTransitionThenLoad()
    {
        transitionAnim.SetTrigger("End"); // Make sure this trigger exists in Animator
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Intro Scene");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
