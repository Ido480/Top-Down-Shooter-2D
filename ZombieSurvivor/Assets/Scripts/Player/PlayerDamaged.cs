using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration;
    private InvincibilityController invincibilityController;
    [SerializeField] private Color flashColor;
    [SerializeField] private int numberOfFlashes;

    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>();
    }
    public void StartInvincibility()
    {
        invincibilityController.StartInvincibilty(invincibilityDuration, flashColor, numberOfFlashes);
    }
}
