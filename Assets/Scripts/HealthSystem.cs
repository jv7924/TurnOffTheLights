using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public delegate void PlayerDeadAction();
    public event PlayerDeadAction OnPlayerDead;

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

    public void Damage(int amount)
    {
        currentHealth -= amount;
    }

    public void Heal(int amount)
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
            OnPlayerDead?.Invoke();
    }
}
