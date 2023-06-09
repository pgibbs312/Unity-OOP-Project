using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage;
    public float duration;

    private float timer;

    public void Initialize(int damage, float duration)
    {
        this.damage = damage;
        this.duration = duration;
        timer = duration;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
