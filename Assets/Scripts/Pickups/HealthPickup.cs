using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup, IDamageable
{
    [SerializeField] float healthMin;
    [SerializeField] float healthMax;
    public GameObject healthEffect;
    public void GetDamage(float damage)
    {
        OnPicked();
    }
    public override void OnPicked()
    {
        base.OnPicked();
        float health = Random.Range(healthMin, healthMax);
        var player = GameManager.GetInstance().GetPlayer();
        player.health.AddHealth(health);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("On trigger health");
            Instantiate(healthEffect, col.transform.position, Quaternion.identity);
            OnPicked();
        }
    }
}
