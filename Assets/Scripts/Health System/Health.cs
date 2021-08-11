using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [Space]
    public IntVariableReference currentHealthReference;
    public UnityEvent OnDeath;

    private void Update()
    {
        if(currentHealthReference != null)
            currentHealthReference.SetInt((int)currentHealth);
    }

    public void DealDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0f)
        {
            OnDeath.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
