using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    [SerializeField] private bool isGroud;
    public bool isGround
    {
        get => isGroud;
    }

    [SerializeField] private string tag;
    

    void Update() 
    { 

    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(tag))
        {
            isGroud = true;
        }    
        else
        {
            isGroud = false;
        }
    }
}
