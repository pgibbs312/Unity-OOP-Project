using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppressedFireProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float countDown;
    [SerializeField] Transform ship;
    private Vector2 target;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        Debug.Log($"player position: {target}");
    }
    void Update()
    {
        transform.Translate(target * speed * Time.deltaTime);

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
