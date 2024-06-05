using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHelath : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float respawnTime;
    [SerializeField] GameObject healthPanel;
    [SerializeField] TextMeshProUGUI healtText;
    [SerializeField] RectTransform healthBar;

    private MeshRenderer meshRenderer;
    float currentHealth;
    private float healthBarStartWith;
    private bool isDead;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentHealth = maxHealth;
        healthBarStartWith = healthBar.sizeDelta.x;

        UpdateUI();
    }

    public void ApplyDamage(float damge)
    {
        if (isDead)
        {
            return;
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            meshRenderer.enabled = false;
            healthPanel.SetActive(false);

            StartCoroutine(RespawnAfterTime());
        }

        UpdateUI();
    }

    private IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(respawnTime);
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
        isDead = false;
        meshRenderer.enabled = true;
        healthPanel.SetActive(true);
        UpdateUI();
    }

    private void UpdateUI()
    {
        float percentOutOf = (currentHealth / maxHealth) * 100;
        float newWidth = (percentOutOf / 100) * healthBarStartWith;

        healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
        healtText.text = currentHealth + "/" + maxHealth;
    }
}
