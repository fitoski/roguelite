using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float invulnerabilityDuration = 0.5f;

    private bool isInvulnerable = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage, GameObject attacker)
    {
        if (isInvulnerable) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(attacker);
        }
        else
        {
            StartCoroutine(Invulnerability());
        }
    }

    public void ResetCurrentHealth(GameObject attacker)
    {
        currentHealth = maxHealth;
    }

    private void Die(GameObject attacker)
    {
        if (gameObject.CompareTag("Enemy") && attacker.CompareTag("Player"))
        {
            PlayerExperience playerExperience = attacker.GetComponent<PlayerExperience>();
            if (playerExperience != null)
            {
                playerExperience.GainExperience(1);
            }
        }

        Destroy(gameObject);
    }

    private IEnumerator Invulnerability()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
    }
}
