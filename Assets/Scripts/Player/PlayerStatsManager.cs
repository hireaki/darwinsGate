using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager instance;
    [Header("Player Health")]
    public int Health;
    public int MaxHealth;

    [Header("Player Exp")]
    public int Level;
    public int Experience;
    public int MaxExperience;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
