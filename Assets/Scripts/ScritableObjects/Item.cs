using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject
{
    public Image m_uiImage;
    public GameObject m_prefab;
    public int m_level;
    public float m_weight;
    public float m_value;
    public RequiredAttribute[] m_requiredAttributes;
}

[System.Serializable]
public class RequiredAttribute
{
    public Attribute attribute;
    public int minimum;
}

public enum Attribute
{
    Strength,
    Toughness,
    Dexterity,
    Intelligence
}