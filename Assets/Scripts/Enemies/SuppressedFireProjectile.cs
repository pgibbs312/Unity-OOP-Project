using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppressedFireProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float countDown;
    [SerializeField] Transform ship;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigidbody.AddForce(ship.forward * speed);
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<IDamageable>().GetDamage(damage);
            Destroy(gameObject);
        }
    }

}
