using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthControler : MonoBehaviour
{
    [SerializeField] GameObject healthPanel;

    [SerializeField] RectTransform healthBar;

    [SerializeField] TextMeshProUGUI healthText;

    private float healthBarStartWidth;

    private float currentHealth;

    [SerializeField] float maxHealth;

    [SerializeField] float respawnTime;

    private MeshRenderer meshRenderer;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        healthBarStartWidth = healthBar.sizeDelta.x;
        meshRenderer = GetComponent<MeshRenderer>();
        ResetHealth();
        UpdateHealthUI();
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            meshRenderer.enabled = false;
            healthPanel.SetActive(false);
            StartCoroutine(RespawnAfterTime());
        }

        UpdateHealthUI();
    }

    IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(respawnTime);
        ResetHealth();
    }

    private void ResetHealth()
    {
        isDead = false;
        currentHealth = maxHealth;
        meshRenderer.enabled = true;
        healthPanel.SetActive(true);
        UpdateHealthUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        float percentOutOf = (currentHealth / maxHealth) * 100;
        float newWidth = (percentOutOf / 100f) * healthBarStartWidth;

        healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
        healthText.text = currentHealth + "/" + maxHealth;
    }
}
