using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] float attackRange;
    [SerializeField] float attackTime;
    [SerializeField] float damage;
    private float timer = 0;

    public void SetMeleeEnemy(float _attackRange, float _attackTime)
    {
        attackRange = _attackRange;
        attackTime = _attackTime;
    }
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
        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            Attack(attackTime);
        }
    }

    // public override void GetDamage(float damage)
    // {
    //     health.DeductHealth(damage);
    // }

    public override void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        } else 
        {
            timer = 0;
            target.GetComponent<IDamageable>().GetDamage(damage);
        }
    }
}
