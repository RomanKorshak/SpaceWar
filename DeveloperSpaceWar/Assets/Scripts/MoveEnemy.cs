using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private bool isVisiable;
    private Vector2 movement;

    void Start() 
    {
        isVisiable = false;    
    }

    void Update() 
    {
        movement = new Vector2(Vector2.left.x * speed, 0);
    }

    void OnBecameVisible() 
    {
        isVisiable = true;    
    }

    void OnBecameInvisible() 
    {
        isVisiable = false;    
    }

    void FixedUpdate() 
    {
        if(isVisiable)
        {
            if(rb == null)
                rb = GetComponent<Rigidbody2D>();
            rb.velocity = movement;
        }
       

    }

}
