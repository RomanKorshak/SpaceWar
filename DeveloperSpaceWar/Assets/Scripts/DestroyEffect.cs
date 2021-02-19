using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private CircleCollider2D cc;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clipDestroy;
   

    public IEnumerator DestroyEffectCoroutine(GameObject gameobject)
    {
        source.PlayOneShot(clipDestroy);
        particle.Play();
        
        sp.enabled = false;
        if(cc == null)
        {
            bc.enabled = false;
        }
        else if(bc != null)
        {
            cc.enabled = false;
        }
       

       


        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameobject);
        yield break;
    }


    
}
