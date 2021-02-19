using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGroundComponent : MonoBehaviour
{
    [SerializeField] private Health health;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            var damage = other.gameObject.GetComponent<CollisionDamage>();
            if(damage != null)
            {
                Debug.Log(damage.Damage);
                health.Hit(damage.Damage);
                Destroy(other.gameObject);
            }
        }
    }
}
