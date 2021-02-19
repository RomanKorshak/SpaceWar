using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private isGrounded DetectionGround;
    private Vector2 movement;


    void Update() 
    {
        float xRotation = Input.GetAxis("Horizontal") * speed;
        // float yRotation = Input.GetAxis("Vertical") * speed;
        movement = new Vector2(xRotation, 0f);

        CheckPosition(xRotation);

        animator.SetFloat("xRotation",Mathf.Abs(xRotation));

    }

    void FixedUpdate() 
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if(DetectionGround.isGround)
        {
            rb.velocity = movement;
        }
        
    }

    private void CheckPosition(float xRotation)
    {
        if(xRotation < 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }




}
