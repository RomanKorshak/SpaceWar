using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraEffect : MonoBehaviour
{


    public void Shake()
    {
           
        CameraShaker.Instance.ShakeOnce(4f,4f,.1f,1f);
        
    }

}
