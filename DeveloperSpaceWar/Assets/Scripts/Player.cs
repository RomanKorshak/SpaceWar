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
    [SerializeField] private Camera camera;
    private Vector3 target;
 

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
        target = camera.ScreenToWorldPoint(Input.mousePosition);

        float xRotation = target.x - startPosition.transform.position.x;
        float yRotation = target.y - startPosition.transform.position.y;

        // float angle = Mathf.Atan2(yRotation, xRotation) * Mathf.Rad2Deg;

        // startPosition.rotation = Quaternion.Euler(0f,0f, angle);

        direction = new Vector2(xRotation,yRotation);

        Bullet bullet = Instantiate(bulletPrefab, startPosition.transform.position,Quaternion.identity);
        bullet.gameObject.transform.position = startPosition.transform.position;
        bullet.SetImpulse(bulletForce,direction,gameObject);
    }



}
