using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private HealthModule playerHealth;
    [SerializeField] private TextMeshProUGUI healthTextValue;

    private void Awake()
    {
        playerHealth.OnHealthZero += ShowGameOver;
        playerHealth.OnHealthChanged += UpdateHealthValue;
    }



    private void UpdateHealthValue(int newHealthValue)
    {
        healthTextValue.text = newHealthValue.ToString() + "%";
    }

    private void ShowGameOver()
    {
        healthTextValue.text = "YOU ARE DEAD!";
        healthTextValue.color = Color.red;
    }
}
