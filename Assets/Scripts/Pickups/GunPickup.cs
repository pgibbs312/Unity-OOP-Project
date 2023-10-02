using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : Pickup, IDamageable
{
    [SerializeField] float buffedTime;
    public void GetDamage(float damage)
    {
        OnPicked();
    }
   
    public override void OnPicked()
    {
        base.OnPicked();
        var player = GameManager.GetInstance().GetPlayer();
        player.gunBuffedTimer = buffedTime;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("On trigger health");
            OnPicked();
        }
    }
}
