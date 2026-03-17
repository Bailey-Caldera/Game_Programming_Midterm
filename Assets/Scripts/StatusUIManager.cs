using UnityEngine;
using TMPro;

public class StatusUIManager : MonoBehaviour
{
    public TMP_Text waveText;
    public TMP_Text healthText;
    public TMP_Text cooldownText;
    //allows script to see cooldown status
    public PlayerShooting playerShooting;
    public TMP_Text killStreakText;
    
    private void Start()
    {
        waveText.text = $"Wave: 1";
        healthText.text = $"Health: 5";
        cooldownText.text = "Cooldown: Fire";
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

    private void Update()
    {
        //if player not shooting using right-click function stops run
        if (playerShooting == null)
        {
            return;
        }

        //if cooldown relevant display time
        if (playerShooting.Cooldown.IsCoolingDown)
        {
            cooldownText.text = $"Cooldown: {playerShooting.Cooldown.TimeR:F1}s";
        }

        //if cooldown is done display 0
        else
        {
            cooldownText.text = "Cooldown: Fire";
        }
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
