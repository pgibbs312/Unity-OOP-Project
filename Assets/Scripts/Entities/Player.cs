using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : PlayableObject
{
    // primitive data types
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] TMP_Text txtHealth;
    [SerializeField] Bullet bulletprefab;
    public int nukesAvailable = 0;
    private Rigidbody2D playerRB;
    public Action OnDeath;
    public HealthPickup healthPickup;
    public float currentHealth;
    public float gunBuffedTimer = 0;
    List<Enemy> enemies = new List<Enemy>();
    [SerializeField] AudioSource fireSFX;
    public AudioSource deathSFX;

    
    // public Action<float> OnHealthUpdate;
    private void Awake()
    {
        health = new Health(100, 0.5f, 50);
        playerRB = GetComponent<Rigidbody2D>();

        weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);

        //OnHealthUpdate?.Invoke(health.GetHealth());

        cam = Camera.main;
    }

    private void Update()
    {
        health.RegenHealth();
        
        if (Input.GetMouseButton(1))
        {
            if (nukesAvailable > 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies.Remove(enemies[i]);
                }
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Enemy _enemy = enemy.GetComponent<Enemy>();
                    enemies.Add(_enemy);
                }
                Debug.Log(enemies.Count);
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Die();
                    enemies.RemoveAt(i);
                }
            }
        }
        BuffedGunAttack();
    }
    // public void GetHealth()
    // {
    //     currentHealth = health.GetHealth();
    //     return currentHealth;
    // }

    // method below is an example of run time polymorphism
    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRB.velocity = direction * speed * Time.deltaTime;
        var playerScreenPos = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;
        
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    } 
    void BuffedGunAttack()
    {
        if (gunBuffedTimer > 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
            gunBuffedTimer -= Time.deltaTime;
        }
    }  

    public override void Shoot()
    {
        weapon.Shoot(bulletprefab, this, "Enemy");
        fireSFX.Play();
    }
    public override void Die()
    {
        Debug.Log("You died");
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public override void Attack(float interval)
    {

    }

    public override void GetDamage(float damage)
    {
        Debug.Log($"Player took {damage} amount of dmg");
        health.DeductHealth(damage);

        //OnHealthUpdate?.Invoke(health.GetHealth());

        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }

    
}
