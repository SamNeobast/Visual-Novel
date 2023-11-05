using UnityEngine;

public class HealthControler : MonoBehaviour
{
    [SerializeField] private float curentHealth;
    [SerializeField] private float maxHealth;

    public float RemainingHealtPercent
    {
        get { return curentHealth / maxHealth; }
    }

    public void TakeDamage(float damageAmount)
    {
        curentHealth -= damageAmount;
        Events.OnHealthChanged?.Invoke(RemainingHealtPercent);

        if (curentHealth <= 0)
        {
            curentHealth = 0;
            Events.OnDeadedPlayer?.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if(curentHealth == maxHealth) return;

        curentHealth += amountToAdd;
        Events.OnHealthChanged?.Invoke(RemainingHealtPercent);

        if (curentHealth > maxHealth)
        {
            curentHealth = maxHealth;
        }
    }
}
