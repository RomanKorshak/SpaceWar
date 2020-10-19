using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float speed;


    void Update() 
    {
        this.transform.position = new Vector3(transform.position.x + Time.deltaTime * speed,0f,transform.position.z); 
    }

    void FixedUpdate() 
    {

    }
}
