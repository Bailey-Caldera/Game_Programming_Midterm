using System;
using UnityEngine;

public class KillStreakManager : MonoBehaviour
{
    [SerializeField] public float streakTimeWindow = 2.5f;

    private int currentStreak = 0;
    private float lastKillTime = -999f;

    public static event Action<int> onKillStreakChanged;
    public static event Action onKillStreakEnded;

    void OnEnable()
    {
        Enemy.onEnemyDeath += RegisterKill;
    }

    void OnDisable()
    {
        Enemy.onEnemyDeath -= RegisterKill;
    }

    void RegisterKill()
    {
        if (Time.time - lastKillTime <= streakTimeWindow)
        {
            currentStreak++;
        }
        else
        {
            currentStreak = 1;
        }

        lastKillTime = Time.time;

        Debug.Log("Kill Streak: " + currentStreak);
        onKillStreakChanged?.Invoke(currentStreak);
    }

    void Update()
    {
        if (currentStreak > 0 && Time.time - lastKillTime > streakTimeWindow)
        {
            currentStreak = 0;
            onKillStreakEnded?.Invoke();
            onKillStreakChanged?.Invoke(currentStreak);
        }
    }
}
