using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Vector3 healthBarOffset = new Vector3(0, 0, 0);

    public GameObject healthBarPrefab;
    private GameObject healthBarObject;
    private Slider healthBarSlider;
    public int experienceReward = 1;
    private PlayerExperience playerExperience;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBarObject = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
        healthBarObject.transform.SetParent(FindObjectOfType<Canvas>().transform);
        healthBarObject.transform.position = Camera.main.WorldToScreenPoint(transform.position + healthBarOffset);
        healthBarSlider = healthBarObject.GetComponentInChildren<Slider>();
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;
        playerExperience = FindObjectOfType<PlayerExperience>();

    }




    public void TakeDamage(int damage, GameObject attacker)
    {
        if (gameObject.CompareTag("Player") && attacker.CompareTag("Player"))
        {
            return;
        }

        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die(attacker);
        }
    }




    private void UpdateHealthBar()
    {
        if (healthBarSlider == null)
        {
            Debug.LogError("Health Bar Slider not found for " + gameObject.name);
            return;
        }

        healthBarSlider.value = currentHealth;
        healthBarObject.transform.position = Camera.main.WorldToScreenPoint(transform.position + healthBarOffset);
    }

    private void Update()
    {
        if (healthBarObject != null)
        {
            healthBarObject.transform.position = Camera.main.WorldToScreenPoint(transform.position + healthBarOffset);
        }
    }

    public void ResetCurrentHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }


    private void Die(GameObject attacker = null)
    {
        if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(gameObject);
        }
    }




    private void OnDestroy()
    {
        if (healthBarObject != null)
        {
            Destroy(healthBarObject);
        }
    }
}
