using UnityEngine;
using TMPro;

public class StatusUIManager : MonoBehaviour
{
    public TMP_Text waveText;
    public TMP_Text healthText;
    
    private void Start()
    {
        waveText.text = $"Wave: 1";
        healthText.text = $"Health: 5";
    }

    private void OnEnable()
    {
        PlayerHealth.onPlayerDamage += UpdatePlayerHealth;
        LevelController.onNextWave += UpdateWave;
    }

    private void OnDisable()
    {
        PlayerHealth.onPlayerDamage -= UpdatePlayerHealth;
        LevelController.onNextWave -= UpdateWave;
    }

    private void UpdatePlayerHealth(int playerHealth)
    {
        healthText.text = $"Heatlh: {playerHealth}";
    }

    private void UpdateWave(int wave)
    {
        if (wave > 2)
            wave = 2;

        waveText.text = $"Wave: {wave+1}";
    }
}
