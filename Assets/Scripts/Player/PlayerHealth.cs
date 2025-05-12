using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public Animator hitParticleAnimation;
    public GameObject hitParticleObject;
    public int health;
    public int maxHealth = 10;
    public Image healthBar;
    public Sprite[] healthBarImages;

    void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        // Calculate the index based on the current health
        int index = Mathf.Clamp(health * (healthBarImages.Length - 1) / maxHealth, 0, healthBarImages.Length - 1);

        // Assign the Sprite to the healthBar
        healthBar.sprite = healthBarImages[index];
    }

    public void Damage(float damageAmount)
    {
        hitParticleObject.SetActive(true);
        hitParticleAnimation.Play("HitParticle");

        health -= (int)damageAmount;
    }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        
    }

    public void DoneHitBox()
    {
        hitParticleObject.SetActive(false);
    }
}
