using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] Player playerPrefab;
    private GameObject tempEnemy;
    Player player;

    private Weapon meleeWeapon = new Weapon("Melee", 1, 0);

    private bool isEnemySpawning;
    [SerializeField] float enemySpawnRate;
    public ScoreManager scoreManager;
    public PickUpSpawner pickUpSpawner;

    public Action OnGameStart;
    public Action OnGameEnd;

    bool isPlaying;
    void Awake()
    {
        SetSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
        isEnemySpawning = true;
        FindPlayer();
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static GameManager GetInstance()
    {
        return instance;
    }

    // Check if any duplicate scripts exists
    void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
    }

    void FindPlayer()
    {
        try
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        } catch (NullReferenceException e)
        {
            Debug.Log("Player Doesnt Exist");
        }
    }

    void CreateEnemy()
    {
        tempEnemy = Instantiate(enemyPrefab);
        tempEnemy.transform.position = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)].position;
        tempEnemy.GetComponent<Enemy>().weapon = meleeWeapon;
        tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2, 0.25f);
    }

    IEnumerator EnemySpawner()
    {
        while (isEnemySpawning)
        {
            yield return new WaitForSeconds(1.0f / enemySpawnRate);
            CreateEnemy();
        }
    }

    public void NotifyDeath(Enemy enemy)
    {
        pickUpSpawner.SpawnPickup(enemy.transform.position);
    }

    public Player GetPlayer()
    {
        return player;
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void StartGame()
    {
        enemySpawnRate = 1;

        player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
        player.OnDeath += StopGame;
        isPlaying = true;

        OnGameStart?.Invoke();
        StartCoroutine(GameStarter());
    }

    IEnumerator GameStarter()
    {
        yield return new WaitForSeconds(2);
        isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    public void StopGame()
    {
        isEnemySpawning = false;
        //scoreManager.SetHighScore();

        StartCoroutine(GameStopper());
    }

    IEnumerator GameStopper()
    {
        isEnemySpawning = false;
        yield return new WaitForSeconds(2);
        isPlaying = false;

        foreach (Enemy item in FindObjectsOfType(typeof(Enemy)))
        {
            Destroy(item.gameObject);
        }

        foreach (Pickup item in FindObjectsOfType(typeof(Pickup)))
        {
            Destroy(item.gameObject);
        }

        OnGameEnd?.Invoke();
    }
}
