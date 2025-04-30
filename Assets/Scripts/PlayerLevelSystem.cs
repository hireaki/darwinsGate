using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelSystem : MonoBehaviour
{
    public Slider xpBarSlider;
    public TextMeshProUGUI xpText;

    public int currentLevel = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 100;

    void Start()
    {
        UpdateUI();
    }

    public void GainXP(int amount)
    {
        currentXP += amount;
        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            currentLevel++;
            xpToNextLevel += 50; // Increase XP needed for next level
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        xpBarSlider.maxValue = xpToNextLevel;
        xpBarSlider.value = currentXP;
        xpText.text = $"Level {currentLevel} - {currentXP}/{xpToNextLevel} XP";
    }
}
