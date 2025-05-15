using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    private InvetoryController inventoryController;
    private HotbarController hotbarController;
    public bool loadPosition = true;

    // Start is called before the first frame update
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "save3.json");
        inventoryController = FindObjectOfType<InvetoryController>();
        hotbarController = FindObjectOfType<HotbarController>();

        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            mapBoundary = FindObjectOfType<CinemachineConfiner>().m_BoundingShape2D.gameObject.name,
            inventorySaveData = inventoryController.GetInventoryItems(),
            hotbarSaveData = hotbarController.GetHorbarItems(),
            Level = PlayerStatsManager.instance.Level,
            Experience = PlayerStatsManager.instance.Experience,
            MaxExperience = PlayerStatsManager.instance.MaxExperience
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            if (loadPosition)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
            }
            FindObjectOfType<CinemachineConfiner>().m_BoundingShape2D = GameObject.Find(saveData.mapBoundary).GetComponent<PolygonCollider2D>();
            inventoryController.SetInventoryItems(saveData.inventorySaveData);
            hotbarController.SetHotbarItems(saveData.hotbarSaveData);
            PlayerStatsManager.instance.Level = saveData.Level;
            PlayerStatsManager.instance.Experience = saveData.Experience;
            PlayerStatsManager.instance.MaxExperience = saveData.MaxExperience;
        }
        else
        {
            inventoryController.SetInventoryItems(null);
            hotbarController.SetHotbarItems(null);
            SaveGame();  
        }
    }

    void OnApplicationQuit()
    {
        // Place your save or cleanup logic here
        SaveGame();
    }
}
