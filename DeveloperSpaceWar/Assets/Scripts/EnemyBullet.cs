using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int lifeTime;


    void OnTriggerEnter2D(Collider2D other) 
    {
        var health = other.gameObject.GetComponent<Health>();
        if(health == null)
            return;
        if(!other.gameObject.CompareTag("Player"))
            return;

        health.Hit(damage);
        Destroy(gameObject);    
    }

    public void SetImpulse(float force, Vector2 direction)
    {

        rb.AddForce(force * direction, ForceMode2D.Impulse);
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        yield break;
    }
}
