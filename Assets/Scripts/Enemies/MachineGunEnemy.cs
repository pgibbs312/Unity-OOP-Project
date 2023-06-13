using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{
    [SerializeField] float attackRange;
    [SerializeField] float attackTime;
    [SerializeField] float damage;
    [SerializeField] private GameObject projectile;
    private float timer = 0;
    // Start is called before the first frame update
    public void SetMachineGunEnemy(float _attackRange, float _attackTime)
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

    public override void Move(Vector2 direction)
    {
        // define direction of movement
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        // define rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
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
            Debug.Log("MachineGun Shot");
        }   
    }
}
