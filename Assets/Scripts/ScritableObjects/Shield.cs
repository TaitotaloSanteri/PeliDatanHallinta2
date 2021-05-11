using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Shield")]
public class Shield : Item
{
    public float m_block;
    public ShieldType m_shieldType;
}
public enum ShieldType
{
    Normal,
    Greatshield
}
