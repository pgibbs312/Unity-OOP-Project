using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : PlayableObject
{
    //private float speed;
    private EnemyType enemyType;
    public GameObject explosion;
    protected Transform target;
    protected Rigidbody2D rb;
    public AudioClip explosionSound;




    [SerializeField] protected float speed; // private are local to the script, protected are local to the script, but can become avaible to any other scripts that are inherited from the class


    public EnemyType GetEnemyType()
    {
        return enemyType;
    }
    protected virtual void Start()
    {
        try 
        {
            target = GameObject.FindWithTag("Player").transform; // Find the transfrom of the player
        } catch(NullReferenceException e)
        {
            Debug.Log($"There is no player in the scene {e}");
            //Destroy(gameObject);
        }


        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position);
        } else {
            Move(speed);
        }
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        Debug.Log("Enemy moving towards the direction");
    }
    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    public override void Move(Vector2 direction)
    {
        // define direction of movement
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        // define rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    
    public override void Shoot()
    {
        Debug.Log("Shooting bullets towards direction");
    }
    public override void Die()
    {
        Debug.Log("Enemy Died");

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            AudioSource explosionAudio = explosion.AddComponent<AudioSource>();

            if (explosionSound != null)
            {
                explosionAudio.clip = explosionSound;
                explosionAudio.Play();
            }
            else
            {
                Debug.Log("Explosion sound effect not assigned.");
            }
        }
        else
        {
            Debug.Log("Explosion GameObject not assigned.");
        }

        GameManager.GetInstance().NotifyDeath(this);
        Destroy(gameObject);


    }
    public override void Attack(float interval)
    {
     
    }
    public override void GetDamage(float damage)
    {
        Debug.Log($"Enemy took {damage} amount of dmg");
        health.DeductHealth(damage);
        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }
    public void SetEnemyType(EnemyType enemyType)
    {
        this.enemyType = enemyType;
    }
}
