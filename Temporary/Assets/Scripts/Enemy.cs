using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private BoxCollider2D bx;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            StartCoroutine(Break());
        }
    }


    private IEnumerator Break()
    {
        particle.Play();

        sp.enabled = false;
        bx.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
        yield break;
    }
    
}
