using UnityEngine;
using TMPro;

public class StatusUIManager : MonoBehaviour
{
    public TMP_Text waveText;
    public TMP_Text healthText;
    public TMP_Text killStreakText;
    
    private void Start()
    {
        waveText.text = $"Wave: 1";
        healthText.text = $"Health: 5";
        killStreakText.text = "";
    }

    private void OnEnable()
    {
        PlayerHealth.onPlayerDamage += UpdatePlayerHealth;
        PlayerHealth.onHealthPackApplied += UpdatePlayerHealth;
        LevelController.onNextWave += UpdateWave;

        KillStreakManager.onKillStreakChanged += UpdateKillStreak;
        KillStreakManager.onKillStreakEnded += ClearKillStreak;
    }

    private void OnDisable()
    {
        PlayerHealth.onPlayerDamage -= UpdatePlayerHealth;
        PlayerHealth.onHealthPackApplied -= UpdatePlayerHealth;
        LevelController.onNextWave -= UpdateWave;

        KillStreakManager.onKillStreakChanged -= UpdateKillStreak;
        KillStreakManager.onKillStreakEnded -= ClearKillStreak;
    }

    private void UpdatePlayerHealth(int currentHP)
    {
        healthText.text = $"Health: {currentHP}";
    }

    private void UpdateWave(int wave)
    {
        if (wave > 2)
            wave = 2;

        waveText.text = $"Wave: {wave+1}";
    }

    private void UpdateKillStreak(int streak)
    {
        Debug.Log("Kill streak UI updated: " + streak);

        if (streak > 1)
        {
            killStreakText.text = $"Kill Streak: {streak}!";
        }
        else
        {
            killStreakText.text = "";
        }
    }

    private void ClearKillStreak()
    {
        killStreakText.text = "";
    }
}
