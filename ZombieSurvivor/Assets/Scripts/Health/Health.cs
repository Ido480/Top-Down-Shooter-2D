using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }
    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;

    private Coroutine healthIncreaseCoroutine;

    private void Start()
    {
        if (CompareTag("Enemy"))
        {
            StartHealthIncrease();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0)
        {
            return;
        }
        if (IsInvincible)
        {
            return;
        }

        currentHealth -= damageAmount;

        OnHealthChanged.Invoke();
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (currentHealth == maxHealth)
        {
            return;
        }
        currentHealth += amountToAdd;

        OnHealthChanged.Invoke();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void StartHealthIncrease()
    {
        if (healthIncreaseCoroutine != null)
        {
            StopCoroutine(healthIncreaseCoroutine);
        }
        healthIncreaseCoroutine = StartCoroutine(HealthIncreaseOverTime());
    }

    private IEnumerator HealthIncreaseOverTime()
    {
        while (true) 
        {
            AddHealth(10f);

            yield return new WaitForSeconds(10f);
        }
    }
    public void SetMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }

}
