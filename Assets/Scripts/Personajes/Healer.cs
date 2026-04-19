using System;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [field: SerializeField] public int NumPotions { get; private set; }

    public int MaxPotions { get; private set; }

    [field: SerializeField] public float HealAmount { get; private set; }

    private void Awake()
    {
        MaxPotions = NumPotions;
    }

    public int GetNumPotions()
    {
        return NumPotions;
    }
    
    public int GetMaxPotions()
    {
        return MaxPotions;
    }

    public float GetHealAmount()
    {
        return HealAmount;
    }

    public void UsePotion()
    {
        if (CanHeal()) NumPotions--;
    }

    public void CookPotion()
    {
        if (CanCook()) NumPotions++;
    }

    public bool CanCook()
    {
        return NumPotions < MaxPotions;
    }
    
    public bool CanHeal()
    {
        return NumPotions > 0;
    }
    
}
