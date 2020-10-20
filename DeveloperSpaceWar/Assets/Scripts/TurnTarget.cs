using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTarget : MonoBehaviour
{
    
    public float xRotation;
    public float yRotation;

    [SerializeField] private Enemy enemy;
    public bool isTarget {get;set;} 

    void Start() 
    {
        isTarget = false;    
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isTarget = false;
        }    
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            xRotation = (other.gameObject.transform.position - transform.position).x;
            yRotation = (other.gameObject.transform.position - transform.position).y;

            float direction = Mathf.Atan2(yRotation, xRotation) * Mathf.Rad2Deg;

            enemy.gameObject.transform.rotation = Quaternion.Euler(0f,0f,direction);

            if(other.gameObject.CompareTag("Player"))
            {
                isTarget = true;
            }
        }
        
    }
}
