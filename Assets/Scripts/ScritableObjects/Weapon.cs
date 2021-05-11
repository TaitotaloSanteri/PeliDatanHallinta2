using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon")]
public class Weapon : Item
{
    public float m_damage;
    public WeaponType m_weaponType;
    public float m_radius;
}
public enum WeaponType
{
    Sword,
    Axe,
    Hammer,
    Two_Handed_Sword,
    Two_Handed_Axe,
    Two_Handed_Hammer
}