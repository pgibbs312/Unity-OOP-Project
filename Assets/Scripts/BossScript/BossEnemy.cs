using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxShield = 100;
    public float moveSpeed = 5f;
    public float chargeSpeed = 10f;
    public int shieldBreakThreshold = 0;
    public int shieldRecovery = 10;
    public float shieldRecoveryInterval = 5f;
    public float chargeInterval = 12f;
    public float chargeDuration = 3f;
    public float shootInterval = 3f;
    public int shootDamage = 2;
    public int chargeDamage = 20;
    public Transform player;
    public GameObject bulletPrefab;

    private int currentHealth;
    private int currentShield;
    private float shieldRecoveryTimer;
    private float chargeTimer;
    private float shootTimer;
    private bool isCharging;

    private void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
        shieldRecoveryTimer = shieldRecoveryInterval;
        chargeTimer = chargeInterval;
        shootTimer = shootInterval;
        isCharging = false;
    }

    private void Update()
    {
        shieldRecoveryTimer -= Time.deltaTime;
        chargeTimer -= Time.deltaTime;
        shootTimer -= Time.deltaTime;

        if (shieldRecoveryTimer <= 0f)
        {
            RecoverShield();
            shieldRecoveryTimer = shieldRecoveryInterval;
        }

        if (chargeTimer <= 0f)
        {
            PerformChargeAttack();
            chargeTimer = chargeInterval;
        }

        if (shootTimer <= 0f)
        {
            //Shoot();
            shootTimer = shootInterval;
        }

        if (isCharging)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * chargeSpeed * Time.deltaTime;
    }

    private void PerformChargeAttack()
    {
        isCharging = true;
        Invoke(nameof(StopChargeAttack), chargeDuration);
    }

    private void StopChargeAttack()
    {
        isCharging = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isCharging)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(chargeDamage);
            }
            isCharging = false;
        }
    }

    
    private void RecoverShield()
    {
        currentShield = Mathf.Min(currentShield + shieldRecovery, maxShield);
    }

    public void TakeDamage(int damage)
    {
        if (currentShield > shieldBreakThreshold)
        {
            currentShield -= damage;
            if (currentShield < 0)
            {
                currentShield = 0;
            }
        }
        else
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform actions when the boss dies
        // For example, destroy the boss GameObject and show a victory screen
        Destroy(gameObject);
    }
}
