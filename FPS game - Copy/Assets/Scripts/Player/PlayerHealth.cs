using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    private float health;
    private float mana;
    private float healthLerpTimer;
    private float manaLerpTimer;
    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float maxMana = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public Image frontManaBar;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;
    private float durationTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mana = maxMana;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (overlay.color.a > 0)
        {
            if (health < 30)
            {
                return;
            }
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                //fade the image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime* fadeSpeed;
                overlay.color = new Color(overlay.color.r,overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillHF = frontHealthBar.fillAmount;
        float fillHB = backHealthBar.fillAmount;

        float fillMF = frontManaBar.fillAmount;
        float hFraction = health / maxHealth;
        float mFraction = mana / maxMana;
        if (fillHB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            healthLerpTimer += Time.deltaTime;
            float percentComplete = healthLerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillHB, hFraction, percentComplete);
        }
        else if (fillHF < hFraction)
        {
            backHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.green;
            healthLerpTimer += Time.deltaTime;
            float percentComplete = healthLerpTimer / chipSpeed;
            frontHealthBar.fillAmount = Mathf.Lerp(fillHF, backHealthBar.fillAmount, percentComplete);
        }

        if (fillMF != mFraction)
        {
            manaLerpTimer += Time.deltaTime;
            float percentComplete = manaLerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontManaBar.fillAmount = Mathf.Lerp(fillMF, mFraction, manaLerpTimer);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthLerpTimer = 0f;
        durationTimer = 0;
        if (damage > 0)
        {
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
        }
        else if (damage < 0)
        {
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        }

        

    }

    public void UseMana(float manaUsed)
    {
        mana -= manaUsed;
        manaLerpTimer = 0f;
    }

}
