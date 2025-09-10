using System.Collections;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private Health health;
    private SpriteFlash spriteFlash;

    private void Awake()
    {
        health = GetComponent<Health>();
        spriteFlash = GetComponent<SpriteFlash>();
    }

    public void StartInvincibilty(float invincibiltyDuration, Color flashColor, int numberOfFlashes)
    {
        StartCoroutine(InvinicilityCoroutine(invincibiltyDuration, flashColor, numberOfFlashes));
    }
    private IEnumerator InvinicilityCoroutine(float invincibiltyDuration, Color flashColor, int numberOfFlashes)
    {
        health.IsInvincible = true;
        yield return spriteFlash.FlashCoroutine(invincibiltyDuration, flashColor, numberOfFlashes);
        health.IsInvincible = false;
    }
}
