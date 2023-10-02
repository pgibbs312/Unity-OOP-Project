using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickup : Pickup, IDamageable
{
   public void GetDamage(float damage)
   {
       OnPicked();
   }

    public override void OnPicked()
    {
        base.OnPicked();
        var player = GameManager.GetInstance().GetPlayer();
        player.nukesAvailable += 1;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            OnPicked();
    }
}
