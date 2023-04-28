using UnityEngine;

public class StoneCollision : MonoBehaviour
{
    public int damage = 1;
    private Health health;
    private float lastDamageTime;
    public float damageCooldown = 0.2f;

    private void Start()
    {
        health = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (Time.time > lastDamageTime + damageCooldown)
            {
                Health enemyHealth = other.GetComponent<Health>();
                enemyHealth.TakeDamage(damage, gameObject);
                lastDamageTime = Time.time;
                Destroy(gameObject); 
            }
        }
    }

}
