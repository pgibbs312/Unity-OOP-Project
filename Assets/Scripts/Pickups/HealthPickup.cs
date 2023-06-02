using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup, IDamageable
{
    [SerializeField] float healthMin;
    [SerializeField] float healthMax;
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
        Debug.Log($"Health added: {health}");
    }
}
