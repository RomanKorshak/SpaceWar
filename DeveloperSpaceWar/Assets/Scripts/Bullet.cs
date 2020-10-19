using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRigidBody;
    [SerializeField] private int lifeTime;
    [SerializeField] private CollisionDamage collisionDamage;
    
    public GameObject parent { get; set; }


    public void SetImpulse(float force,Vector2 direction, GameObject parent)
    {
        bulletRigidBody.AddForce(force * direction, ForceMode2D.Impulse);
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        yield break;
    }
}
