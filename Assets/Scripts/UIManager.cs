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
    private bool isBuying = true;

    [HideInInspector] public List<Inventory> merchantInventory = new List<Inventory>();
    [HideInInspector] public List<Inventory> playerInventory = new List<Inventory>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        merchantInventory.AddItems<Weapon>(o => o.m_damage > 10);
        merchantInventory.AddItems<Shield>(o => o.m_shieldType == ShieldType.Greatshield);
        merchantInventory.AddItems<Consumable>(o => o.name == "Small Healing Potion", 10);

        playerInventory.AddItems<Weapon>(o => o.m_weaponType == WeaponType.Sword);
        playerInventory.AddItems<Consumable>(o => o.name == "Small Healing Potion", 2);

        CreateItemButtons(merchantInventory);
    }
    public void ShowMerchantInventory()
    {
        isBuying = true;
        CreateItemButtons(merchantInventory);
    }
    public void ShowPlayerInventory()
    {
        isBuying = false;
        CreateItemButtons(playerInventory);
    }
    public void CreateItemButtons(List<Inventory> inventory)
    {
        if (itemButtons != null)
        {
            foreach (ItemButton btn in itemButtons)
            {
                Destroy(btn.gameObject);
            }
        }
        itemButtons = new List<ItemButton>();
        for (int i = 0; i < inventory.Count; i++)
        {
            ItemButton itemButton = Instantiate(itemButtonPrefab, transform);
            itemButtons.Add(itemButton);
            itemButton.UpdateItemButton(inventory[i]);

            itemButton.transform.localPosition = new Vector2(itemButtonStartPoint.localPosition.x,
                                                        itemButtonStartPoint.localPosition.y - spacing * i);
        }
    }

    public void CompleteTransaction(Inventory inv)
    {
        if (isBuying)
        {
            playerInventory.AddItemToInventory(inv);
            merchantInventory.RemoveItemFromInventory(inv);
            CreateItemButtons(merchantInventory);
        }
        else
        {
            merchantInventory.AddItemToInventory(inv);
            playerInventory.RemoveItemFromInventory(inv);
            CreateItemButtons(playerInventory);
        }
    }

}
