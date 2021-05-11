using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private ItemButton itemButtonPrefab;
    [SerializeField] private Transform itemButtonStartPoint;
    private List<ItemButton> itemButtons;
    private float spacing = 63.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        Debug.Log(GetComponent<Canvas>().scaleFactor);
    }
    public void CreateItemButtons(List<Inventory> inventory)
    {
        itemButtons = new List<ItemButton>();
        for (int i = 0; i < inventory.Count; i++)
        {
            ItemButton itemButton = Instantiate(itemButtonPrefab, transform);
            itemButtons.Add(itemButton);
            itemButton.UpdateItemButton(inventory[i]);

            itemButton.transform.position = new Vector2(itemButtonStartPoint.position.x,
                                                        itemButtonStartPoint.position.y - spacing * i);
        }
    }
}
