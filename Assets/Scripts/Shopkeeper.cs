using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private List<Inventory> m_inventory = new List<Inventory>();
    private void Start()
    {
        m_inventory.AddItems<Weapon>(o => o.m_damage > 10);
        m_inventory.AddItems<Shield>(o => o.m_shieldType == ShieldType.Greatshield);
        m_inventory.AddItems<Consumable>(o => o.name == "Small Healing Potion", 10);
        UIManager.instance.CreateItemButtons(m_inventory);
    }
}
public class Inventory
{
    // Konstruktori
    public Inventory(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    public Item item;
    public int amount;
}
