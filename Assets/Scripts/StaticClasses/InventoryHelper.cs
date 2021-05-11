using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class InventoryHelper
{
    private static Weapon[] allWeapons = Resources.LoadAll<Weapon>("Items/Weapons");
    private static Shield[] allShields = Resources.LoadAll<Shield>("Items/Shields");
    private static Consumable[] allConsumables = Resources.LoadAll<Consumable>("Items/Consumables");
    private static Item[] allItems = Resources.LoadAll<Item>("Items");

    private static Dictionary<Type, Item[]> itemsDictionary = new Dictionary<Type, Item[]>
    {
        {typeof(Weapon), allWeapons},
        {typeof(Shield), allShields},
        {typeof(Consumable), allConsumables }
    };

    public static void AddItemsTwo<T>(this List<Item> items, Func<T, bool> condition = null)
     where T : Item
    {
        Item[] addFrom = allItems.Where(o => o is T).ToArray();
        T[] castedArray = (T[])addFrom;
        //T[] itemsToAdd = condition != null ? addFrom.Where(condition).ToArray()
        //                                   : addFrom;
        //items.AddRange(itemsToAdd);
    }


    public static void AddItems<T>(this List<Item> items, Func<T, bool> condition = null)
        where T: Item
    {
        T[] addFrom = (T[])itemsDictionary[typeof(T)];
        T[] itemsToAdd = condition != null ? addFrom.Where(condition).ToArray()
                                           : addFrom;
        items.AddRange(itemsToAdd);
    }

}
