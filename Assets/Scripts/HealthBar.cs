using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)      // Tässä asetetaan MaximumHealth
    {
      slider.maxValue = health;
      slider.value = health;
    }

    public void SetHealth(int health)         // Tässä asetetaan CurrentHealth
    {
      slider.value = health;
    }
}