using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    private Vector3 movement;
  


    void Start() 
    {
        float zRotation = Random.Range(0, 0.5f);


        movement = new Vector3(transform.position.x, transform.position.y, zRotation);
    }


    void Update() 
    {

    }    

    void FixedUpdate() 
    {
        if(body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }    

        body.velocity = movement;

    }


}
