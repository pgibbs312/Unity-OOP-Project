using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : PlayableObject
{
    // primitive data types
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] Bullet bulletprefab;
    private Rigidbody2D playerRB;
    public Action OnDeath;
    public HealthPickup healthPickup;

    public AudioSource shootingAudioSource;
    public AudioClip shootingSound; 



    public int maxHealth = 100;
    public float currentHealth;

    public HealthBarUI healthBar;
    
    // public Action<float> OnHealthUpdate;
    private void Awake()
    {
        health = new Health(100, 0.5f, 100);
        playerRB = GetComponent<Rigidbody2D>();

        weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);

        shootingAudioSource = GetComponent<AudioSource>();
        //OnHealthUpdate?.Invoke(health.GetHealth());

        cam = Camera.main;

        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        health.RegenHealth();
    }

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

    public override void Shoot()
    {
        Debug.Log("Shooting bullets towards direction");
        weapon.Shoot(bulletprefab, this, "Enemy");

        if (shootingAudioSource && shootingSound)
        {
            shootingAudioSource.PlayOneShot(shootingSound);
        }
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
        health.DeductHealth(damage);

        //OnHealthUpdate?.Invoke(health.GetHealth());

        if (health.GetHealth() <= 0)
        {
            Die();
        }

        //damage function using float
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
      
    }
}
