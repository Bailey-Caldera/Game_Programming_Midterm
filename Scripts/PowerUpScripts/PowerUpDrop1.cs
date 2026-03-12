using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpDrop
{
    public GameObject PowerUp;
    [Range(0, 100)] public float dropChance;
    
}
