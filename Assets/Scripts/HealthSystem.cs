using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        IsDead();
    }

    private void Damage(int amount)
    {
        currentHealth -= amount;
    }

    private void Heal(int amount)
    {
        bool canHeal = false;

        if (currentHealth >= maxHealth)
        {
            canHeal = false;
        }
        else if (currentHealth < maxHealth)
        {
            canHeal = true;
        }

        if (canHeal)
        {
            currentHealth += amount;
            currentHealth = (currentHealth > maxHealth) ? maxHealth : currentHealth;
        }
    }

    private void IsDead()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
