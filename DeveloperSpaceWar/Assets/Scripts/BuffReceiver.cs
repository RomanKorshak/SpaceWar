using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffReceiver : MonoBehaviour
{
    private List<Buff> buffs;

    public List<Buff> Buffs
    {
        get => buffs;
    }

    void Start() 
    {
        buffs = new List<Buff>();

        GameManager.Instance.receiverContainer.Add(gameObject,this);    
    }

    void Update() 
    {
        //
    }


    public void AddBuff(Buff buff)
    {
        
        if(!buffs.Contains(buff))
            buffs.Add(buff);
    }

    public void RemoveBuff(Buff buff)
    {
        if(buffs.Count > 0)
            buffs.Remove(buff);
    }
}
