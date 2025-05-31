using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLevelSystem : MonoBehaviour
{
    public Image expBar;
    public Sprite[] expBarImages;
    public TMP_Text levelText, expText, eraText;

    void Start()
    {
        if (PlayerStatsManager.instance != null)
        {
            UpdateUI();
        }
    }

    private void Update()
    {
        if (PlayerStatsManager.instance != null && PlayerStatsManager.instance.Experience > 0)
        {    
            UpdateUI();
        }
    }
    public void GainXP(int amount)
    {
        PlayerStatsManager.instance.Experience += amount;
        while (PlayerStatsManager.instance.Experience >= PlayerStatsManager.instance.MaxExperience)
        {
            PlayerStatsManager.instance.MaxExperience -= PlayerStatsManager.instance.MaxExperience;
            PlayerStatsManager.instance.Experience++;
            PlayerStatsManager.instance.MaxExperience += 50; // Increase XP needed for next level
        }
        levelText.text = PlayerStatsManager.instance.Level.ToString();
        expText.text = $"{PlayerStatsManager.instance.Experience.ToString()} / {PlayerStatsManager.instance.MaxExperience.ToString()}";
        UpdateUI();
    }

    void UpdateUI()
    {
        // Calculate the index based on the current health
        int index = Mathf.Clamp(PlayerStatsManager.instance.Experience * (expBarImages.Length - 1) / PlayerStatsManager.instance.MaxExperience, 0, expBarImages.Length - 1);

        // Assign the Sprite to the healthBar
        expBar.sprite = expBarImages[index];
        levelText.text = $"{PlayerStatsManager.instance.Level.ToString()}";
        expText.text = $"{PlayerStatsManager.instance.Experience.ToString()} / {PlayerStatsManager.instance.MaxExperience.ToString()}";
        eraText.text = SceneManager.GetActiveScene().name;
    }
}
