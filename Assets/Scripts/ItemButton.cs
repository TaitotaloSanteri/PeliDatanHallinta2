using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Text[] texts;
    public Button button;
    [HideInInspector] public Item item;

    private void OnValidate()
    {
        texts = GetComponentsInChildren<Text>();
        button = GetComponent<Button>();
    }

    public void UpdateItemButton(Inventory inv)
    {
        texts[0].text = inv.item.name;
        texts[1].text = inv.item.m_value.ToString();
        texts[2].text = inv.amount.ToString();
    }
}
