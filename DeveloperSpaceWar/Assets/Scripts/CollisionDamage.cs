using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private int damage;


    void OnCollisionExit2D(Collision2D other) 
    {
        Debug.Log(other.gameObject.name);    
    }
}
