using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speedCoin;
    private Vector2 direction;


    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Vector3 target = other.gameObject.GetComponent<Transform>().position;
            float xRotation = target.x - transform.position.x;
            float yRotation = target.y - transform.position.y;

            direction = new Vector2(xRotation, yRotation);

            rb.AddForce(direction * speedCoin, ForceMode2D.Impulse);
        }    
    }
}
