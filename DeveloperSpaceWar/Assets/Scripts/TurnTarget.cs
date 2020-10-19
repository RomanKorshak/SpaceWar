using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTarget : MonoBehaviour
{
    
    public float xRotation;
    public float yRotation;

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            xRotation = (other.gameObject.transform.position - transform.position).x;
            yRotation = (other.gameObject.transform.position - transform.position).y;

            float direction = Mathf.Atan2(yRotation, xRotation) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f,0f,direction);
        }
        
    }
}
