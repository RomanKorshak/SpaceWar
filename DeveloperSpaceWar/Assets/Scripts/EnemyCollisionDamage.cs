using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDamage : MonoBehaviour
{
    // [SerializeField] private Rigidbody2D body;
    // private Vector3 movement;

    [SerializeField] private CollisionDamage damage;
  


    void Start() 
    {
        // float zRotation = Random.Range(0, 0.5f);


        // movement = new Vector3(transform.position.x, transform.position.y, zRotation);
    }


    void Update() 
    {

    }  

    void OnTriggerEnter2D(Collider2D other) 
    {
        var health = other.gameObject.GetComponent<Health>();

        if(health == null)
        {
            return;
        }

        health.Hit(damage.Damage);
        Destroy(gameObject);    
    }  

    void FixedUpdate() 
    {
        // if(body == null)
        // {
        //     body = GetComponent<Rigidbody2D>();
        // }    

        // body.velocity = movement;

    }


}
