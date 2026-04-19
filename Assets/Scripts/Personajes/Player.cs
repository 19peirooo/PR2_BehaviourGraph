using System;
using Unity.Behavior;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public float Hp { get; private set; }

    public float MaxHealth { get; private set;}

    private void Awake()
    {
        MaxHealth = 100f;
        Hp = MaxHealth;
    }

    public float GetHp()
    {
        return Hp;
    }
    
    public float GetMaxHp()
    {
        return MaxHealth;
    }

    public void Heal(float amountHealed)
    {
        Hp = Hp + amountHealed >= MaxHealth ? MaxHealth : Hp + amountHealed;
    }

}
