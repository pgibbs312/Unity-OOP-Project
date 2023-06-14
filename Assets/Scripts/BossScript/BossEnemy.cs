using UnityEngine;

public class BossEnemy : Enemy
{
   
    public float bossHealth = 100;

    public float chargeDamage = 20;
    public float chargeInterval = 12f;
    public float chargeDuration = 3f;
    public float chargeSpeed = 10f;

    public float bulletDamage = 2f;
    public float bulletInterval = 3f;
    public int bulletsPerShot = 2;
    public float bulletSpeed = 10f;

    public float timeSinceLastCharge = 0f;
    public float timeSinceLastBullet = 0f;

    public float laserDamage = 10f;
    public float laserInterval = 5f;
    public float laserDuration = 3f;
    public float laserSpeed = 15f;
    public GameObject laserPrefab;
    public float timeSinceLastLaser = 0f;
   

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
    }
    private void PerformChargeAttack()
    {
        timeSinceLastCharge += Time.deltaTime;
        if (timeSinceLastCharge >= chargeInterval)
        {
            // Charge towards the player
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            rb.velocity = direction * chargeSpeed;

            Invoke(nameof(StopCharge), chargeDuration);
            timeSinceLastCharge = 0f;
        }
    }

    private void StopCharge()
    {
        rb.velocity = Vector2.zero;
    }

    protected override void Update()
    {
        if (GameManager.GetInstance().IsPlaying())
        {
            
            base.Update();

            PerformChargeAttack();
            //PerformBulletAttack();
            //PerformLaserAttack();
        }
       
    }

    private void PerformLaserAttack()
    {
        timeSinceLastLaser += Time.deltaTime;
        if (timeSinceLastLaser >= laserInterval)
        {
            // Shoot the laser
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            Laser laserScript = laser.GetComponent<Laser>();
            laserScript.SetDamage(target.GetComponent<IDamageable>(), laserDamage); // Pass target and laser damage
            laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * laserSpeed;

            // Destroy the laser after a certain duration
            Destroy(laser, laserDuration);

            timeSinceLastLaser = 0f;
        }
    }


    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("CONGRATS!");
    }
}
