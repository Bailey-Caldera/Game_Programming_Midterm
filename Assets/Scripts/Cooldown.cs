using UnityEngine;

[System.Serializable]

public class Cooldown
{
    [SerializeField] private float cooldownTime;
    private float _nextFireTime;

    //
    public bool IsCoolingDown => Time.time < _nextFireTime;

    //TimeR establishes remaining time on cooldown using _nextFireTime - Time.time
    public float TimeR => Mathf.Max(0f, _nextFireTime - Time.time);

    //cooldown function that starts cooldown and sets next fire time to cooldown time
    public void StartCoolDown() => _nextFireTime = Time.time + cooldownTime;
}