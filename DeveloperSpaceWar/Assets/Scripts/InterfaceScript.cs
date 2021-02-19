using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InterfaceScript : MonoBehaviour
{
    [SerializeField] private List<Image> spritesList;
    [SerializeField] private Sprite deadHealth;
    private int index;


    void Start() 
    {
        index = spritesList.Count - 1;    
    }

    void Update() 
    {
        if(Player.Instance == null)
        {
            foreach(var im in spritesList)
            {
                im.sprite = deadHealth;
            }
            return;
        }
        if(Player.Instance.GetComponent<Health>().HealthG <= index && index >= 0)
        {
            var image = spritesList[index];
            image.sprite = deadHealth;
            index--;
        }    
    }





}
