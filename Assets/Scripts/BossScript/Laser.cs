using UnityEngine;

public class Laser : MonoBehaviour
{
    private IDamageable target;
    private float damage;

    public void SetDamage(IDamageable target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && target != null)
        {
            target.GetDamage(damage);
        }
    }
}