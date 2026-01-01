using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startHealth = 3;
    [SerializeField] int currentHealth = 3;

    public void TakeDamage(int damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}