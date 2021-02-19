using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Singleton<T> : MonoBehaviour
    where T: MonoBehaviour
{
    
    private static T _instance;

    public static T Instance 
    {
        get 
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if(_instance == null)
                {
                    Debug.LogError($"The scene haven't this instance {nameof(T)}");
                }
            }

            return _instance;
        }
    }
}
