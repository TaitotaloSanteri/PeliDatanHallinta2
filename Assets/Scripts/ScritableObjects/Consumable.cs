using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Consumable")]
public class Consumable : Item
{
    public ConsumableProperty[] properties;
}

[System.Serializable]
public class ConsumableProperty
{
    public float m_amount;
    public ConsumableEffect effect;
}

public enum ConsumableEffect
{
    Heal,
    Mana,
    Cure_Poison,
    Raise_Strength,
    Raise_Toughness,
    Raise_Dexterity,
    Raise_Intelligence
}
