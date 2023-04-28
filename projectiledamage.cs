using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damage = 1;
    private float lastDamageTime;
    public float damageCooldown = 0.2f;

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
