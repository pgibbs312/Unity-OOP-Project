using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] float attackRange;
    [SerializeField] float attackTime;
    [SerializeField] float damage;
    [SerializeField] GameObject projectile;
    [SerializeField] float offset;
    [SerializeField] Transform player;
    Color color = new Color(255, 68, 0);
    private float timer = 0;
    
    public void SetShooterEnemy(float _attackRange, float _attackTime)
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
        Vector2 lineTarget = new Vector2(player.position.x, player.position.y);
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), lineTarget, color);
    }

    public override void Move(Vector2 direction)
    {
        // define direction of movement
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        // define rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, (angle - 60));
        if (Vector2.Distance(transform.position, target.position) > attackRange)
        {
           transform.Translate(Vector2.right * speed * Time.deltaTime);
        } 
    }
    public override void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        } else 
        {
            timer = 0;
            Instantiate(projectile, transform.position, Quaternion.identity);
        }   
    }
}
