using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthBarForegroundImage;
    public void UpdateHealthBar(Health health)
    {
        healthBarForegroundImage.fillAmount = health.RemainingHealthPercentage;
    }
}
