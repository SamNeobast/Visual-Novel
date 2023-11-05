using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthBarForeground;

    private void Start()
    {
        Events.OnHealthChanged += UpdateHealthBar;
    }

    private void UpdateHealthBar(float RemainingHealtPercent)
    {
        healthBarForeground.fillAmount = RemainingHealtPercent;
    }

    private void OnDestroy()
    {
        Events.OnHealthChanged -= UpdateHealthBar;
    }
}
