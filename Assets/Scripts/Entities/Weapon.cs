using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    private string name;
    private float damage;
    private float bulletSpeed;

    
    public Weapon(string _name, float _damage, float _bulletSpeed)
    {
        name = _name;
        damage = _damage;
        bulletSpeed = _bulletSpeed;
    }

    public Weapon(string _name, float _damage)
    {
        name = _name;
        damage = _damage;
    }
    public Weapon()
    {
        Debug.Log("General weapon");
    }
    public void Shoot(Bullet _bullet, PlayableObject _player, string _targetTag, float _timeToDie = 5)
    {
        Bullet tempBullet = GameObject.Instantiate(_bullet, _player.transform.position, _player.transform.rotation);
        tempBullet.SetBullet(damage, _targetTag, bulletSpeed);

        GameObject.Destroy(tempBullet.gameObject, _timeToDie);
    }

    public float GetDamage()
    {
        return damage;
    }
}
