using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private int damage;

    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.gameObject.GetComponent<Health>();

        if(health == null)
        {
            return;
        }

        if(GetComponent<Bullet>().parent == other.gameObject)
        {
            return;
        }

        health.Hit(damage);
        Destroy(gameObject);
    }
}
