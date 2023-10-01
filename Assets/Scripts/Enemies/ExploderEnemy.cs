using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderEnemy : Enemy
{
    [SerializeField] float damage;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamageable>().GetDamage(damage);
            Die();
        }
    }
}
