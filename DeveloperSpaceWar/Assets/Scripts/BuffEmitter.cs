using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEmitter : MonoBehaviour
{
    [SerializeField] private Buff buff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(GameManager.Instance.receiverContainer.ContainsKey(other.gameObject))
        {
            var receiver = GameManager.Instance.receiverContainer[other.gameObject];
            receiver.AddBuff(buff);
            Destroy(gameObject);
        }
    }

}

[System.Serializable]
public class Buff
{
    public float AdditiveBonus;
    public float MultipleBonus;
    public int Seconds;

    public TypeBuff type;
}

public enum TypeBuff
{
    ShieldBuff,
    SpeedBuff,
    DamageBuff
}
