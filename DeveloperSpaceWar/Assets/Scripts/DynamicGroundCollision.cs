using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGroundCollision : MonoBehaviour
{
    [SerializeField] int damage;
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        var health = other.gameObject.GetComponent<Health>();

        if(health == null)
        {
            return;
        }

        
        health.Hit(damage);
        Destroy(gameObject);
        
       
    }


    
}
