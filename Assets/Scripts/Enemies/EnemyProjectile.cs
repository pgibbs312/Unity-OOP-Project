using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;   
    [SerializeField] private float damage;
    [SerializeField] private float countDown;
    private int timer = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        gameObject.transform.eulerAngles = new Vector3(
            gameObject.transform.eulerAngles.x, 
            gameObject.transform.eulerAngles.y + 180, 
            gameObject.transform.eulerAngles.z);
    }

    void Update()
    {
        //Vector2 target = new Vector2(player.position.x, player.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            countDown = 0;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            col.GetComponent<IDamageable>().GetDamage(damage);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
