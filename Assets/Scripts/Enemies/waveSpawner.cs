using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class waveSpawner : MonoBehaviour
{
    [SerializeField] private float countDown;
    [SerializeField] private Text waveText;
    
    public GameObject spawnPoint;
    public GameObject[] spawnPoints;
    public Wave[] waves;
    public int currentWaveIndex = 0;
    private int waveIndexText = 0;
    private bool readyToCountDown;
    private int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        readyToCountDown = true;
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        waveIndexText = currentWaveIndex + 1;
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("You survived every wave!");
            return;
        }
        waveText.text = waveIndexText.ToString();
        if (readyToCountDown == true)
        {
            countDown -= Time.deltaTime;
        }

        if (countDown <= 0)
        {
            readyToCountDown = false;
            countDown = waves[currentWaveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }
        if (waves[currentWaveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;
            currentWaveIndex++;
        }
    }
    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                randomNumber = Random.Range(0, spawnPoints.Length);
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoints[randomNumber].transform);
                enemy.transform.SetParent(spawnPoint.transform);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
        
    }
}

[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;
    
    [HideInInspector] public int enemiesLeft;
}
