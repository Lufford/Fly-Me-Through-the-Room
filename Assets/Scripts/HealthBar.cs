using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Health playerHealth;

    void Update()
    {
        healthSlider.value = playerHealth.gethealthCurrent();
    }
}
