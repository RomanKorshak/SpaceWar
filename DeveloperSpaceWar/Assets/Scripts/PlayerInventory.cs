using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    #region Singleton
    public static PlayerInventory Instance;

    #endregion


    [SerializeField] private Text coinText;
    [SerializeField] private int countCoins;

    void Awake() 
    {
        Instance = this;    
    }

    void Start() 
    {
        coinText.text = countCoins.ToString();    
    }

    void Update() 
    {
        coinText.text = countCoins.ToString();    
    }


    public void AddCoin()
    {
        countCoins++;
    }
}
