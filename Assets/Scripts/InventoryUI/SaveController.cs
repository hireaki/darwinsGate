using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    private InvetoryController inventoryController;
    private HotbarController hotbarController;
    public bool loadPosition = true;
    private Chest[] chests;

    // Start is called before the first frame update
    void Start()
    {
        InitializedComponents();
        LoadGame();
    }

    private void InitializedComponents()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "save12.json");
        inventoryController = FindObjectOfType<InvetoryController>();
        hotbarController = FindObjectOfType<HotbarController>();
        chests = FindObjectsOfType<Chest>();
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
            MaxExperience = PlayerStatsManager.instance.MaxExperience,
            chestSaveData = GetChestsState()
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    private List<ChestSaveData> GetChestsState()
    {
        List<ChestSaveData> chestsState = new List<ChestSaveData>();
        foreach (Chest chest in chests)
        {
            ChestSaveData chestSaveData = new ChestSaveData
            {
                ChestID = chest.ChestID,
                isOpened = chest.IsOpened
            };
            chestsState.Add(chestSaveData);
        }
        return chestsState;
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

            LoadChestState(saveData.chestSaveData);
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

    private void LoadChestState(List<ChestSaveData> chestStates)
    {
        foreach (Chest chest in chests)
        {
            ChestSaveData chestSaveData = chestStates.FirstOrDefault(c => c.ChestID == chest.ChestID);

            if (chestSaveData != null)
            {
                chest.SetOpened(chestSaveData.isOpened);
            }
        }
    }
}
