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
    private Rigidbody2D playerRB;
    public Action OnDeath;
    public HealthPickup healthPickup;
    public float currentHealth;
    Health playerHealth;
    
    // public Action<float> OnHealthUpdate;
    private void Awake()
    {
        health = new Health(100, 0.5f, 100);
        playerRB = GetComponent<Rigidbody2D>();

        weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);

        //OnHealthUpdate?.Invoke(health.GetHealth());

        cam = Camera.main;
    }

    private void Update()
    {
        health.RegenHealth();
        txtHealth.SetText(health.GetHealth().ToString());
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

    public override void Shoot()
    {
        weapon.Shoot(bulletprefab, this, "Enemy");
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
