using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public GameObject enemyPrefab;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;   // assign in scene
    public float spawnDelay = 0.5f;   // delay between enemies
    public float waveDelay = 2f;      // delay after wave is cleared

    private int currentWave = 0;
    private List<GameObject> activeEnemies = new List<GameObject>();

    public static event Action<int> onNextWave;
    public static event Action onCompleteWave;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < waves.Length)
        {
            Wave wave = waves[currentWave];

            // Spawn all enemies in this wave
            for (int i = 0; i < wave.enemyCount; i++)
            {
                // select a random spawn point for each enemy to appear in
                Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
                GameObject enemy = Instantiate(wave.enemyPrefab, spawnPoint.position, Quaternion.identity);
                activeEnemies.Add(enemy); // add the instanitated enemy to the list of active enemies
                yield return new WaitForSeconds(spawnDelay); // this is a pause before making the next enemy in a wave...
            }

            // Wait until all enemies in this wave are destroyed by using yield return null
            while (activeEnemies.Count > 0)
            {
                activeEnemies.RemoveAll(e => e == null); // remove destroyed enemies
                yield return null; // wait one frame
            }

            Debug.Log("Wave " + (currentWave + 1) + " cleared!");

            // Delay before next wave
            yield return new WaitForSeconds(waveDelay);

            currentWave++;
            onNextWave?.Invoke(currentWave);
        }

        onCompleteWave?.Invoke();
        Debug.Log("All waves completed!");
    }
}

