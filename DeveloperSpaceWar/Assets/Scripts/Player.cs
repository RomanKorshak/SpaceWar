using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float bulletForce;
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform startPosition;
 

    private Vector2 direction = new Vector2(1,0);

    public Transform StartPosition
    {
        get => startPosition;
    }

    private Vector2 movement;


    void Update() 
    {
       if(Input.GetMouseButtonDown(0))
       {
           Shot();
       }
    }

    void FixedUpdate() 
    {
        if(playerBody == null)
        {
            playerBody = GetComponent<Rigidbody2D>();
        }

        float xRotation = Input.GetAxis("Horizontal");
        float yRotation = Input.GetAxis("Vertical");

        movement = new Vector2(xRotation, yRotation);

        playerBody.velocity = movement * speed;

    }

    void Shot()
    {
        Bullet bullet = Instantiate(bulletPrefab, startPosition);
        bullet.gameObject.transform.position = startPosition.transform.position;
        bullet.SetImpulse(bulletForce,direction,gameObject);
    }



}
