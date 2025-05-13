using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    SaveController saveController;
    private void Start()
    {
        saveController = FindObjectOfType<SaveController>();
        if (saveController == null)
        {
            Debug.LogError("SaveController not found in the scene.");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        
        if (other.tag == "Player")
        {
            
            print("Switching Scene to " + sceneBuildIndex);
            saveController.SaveGame();
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}