using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private List<Item> m_itemsToSell = new List<Item>();
    private void Start()
    {
        m_itemsToSell.AddItems<Weapon>(o => o.m_damage > 10);
        m_itemsToSell.AddItems<Shield>(o => o.m_shieldType == ShieldType.Greatshield);
        m_itemsToSell.AddItems<Consumable>(o => o.name == "Small Healing Potion");
        //InventoryHelper.AddWeapons(m_itemsToSell);
        foreach (Item item in m_itemsToSell)
        {
            Debug.Log(item.name);
        }
    }
}
