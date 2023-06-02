using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private float damage;
   [SerializeField] private float speed;

   private string targetTag;

   public void SetBullet(float _damage, string _targetTag, float _speed = 10)
   {
      damage = _damage;
      speed = _speed;
      targetTag = _targetTag;
   }
   private void Update()
   {
      Move();
   }
   
   void Move()
   {
      transform.Translate(Vector2.right * speed * Time.deltaTime);
   }
   void Damage(IDamageable damageable)
   {
      if (damageable != null)
      {
         damageable.GetDamage(damage);
         Debug.Log($"Damaged something for {damage}");
         GameManager.GetInstance().scoreManager.IncrementScore();
         Destroy(gameObject); // able to add another param to destory to put it on a timer #cool
      }
   }

   void OnTriggerEnter2D(Collider2D collision)
   {

      if (!collision.gameObject.CompareTag(targetTag))
      {
         return;
      }
      Debug.Log($"hitting object: {collision.gameObject.name}");
      IDamageable damageable = collision.GetComponent<IDamageable>();
      Damage(damageable);
   }
}
