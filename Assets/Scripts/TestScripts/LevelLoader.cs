using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static int SCORE;
    
    // Start is called before the first frame update
    void Start()
    {
        // association relationship
        // Create a player
        Player player = new Player();

        // Create 2 enemies
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();

        // Create weapons
        Weapon  gun1 = new Weapon();
        Weapon gun2 = new Weapon("Assult Rifle", 50);
        Weapon machineGun = new Weapon();

        // Create Enemy Types
        EnemyType enemyType1 = new EnemyType();
        enemyType1 = EnemyType.Melee;
        
        EnemyType enemyType2 = new EnemyType();
        enemyType2 = EnemyType.Exploder;
        
        EnemyType enemyType3 = new EnemyType();
        enemyType3 = EnemyType.Shooter;

        EnemyType enemyType4 = new EnemyType();
        enemyType4 = EnemyType.MachineGun;

        // aggregation
        player.weapon = gun1;
        enemy1.weapon = machineGun;
        enemy2.weapon = gun2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
