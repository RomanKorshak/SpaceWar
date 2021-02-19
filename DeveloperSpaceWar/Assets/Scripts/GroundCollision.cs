using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{

    [SerializeField] int damage;
    [SerializeField] float Recail;
    private bool isDamage = true;
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        var health = other.gameObject.GetComponent<Health>();

        if(health == null)
        {
            return;
        }

        if(isDamage)
        {
            health.Hit(damage);
            isDamage = false;
            StartCoroutine(RecailCoroutine());
        }
       
    }


    private IEnumerator RecailCoroutine()
    {
        yield return new WaitForSeconds(Recail);
        isDamage = true;
        yield break;
    }
     
}
