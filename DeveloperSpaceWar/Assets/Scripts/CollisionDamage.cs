using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    
    


    void OnCollisionEnter2D(Collision2D other) 
    {
        Health health = other.gameObject.GetComponent<Health>();
        if(health == null)
            return;

        health.Hit(damage);
        Destroy(gameObject);
       
    }
}
