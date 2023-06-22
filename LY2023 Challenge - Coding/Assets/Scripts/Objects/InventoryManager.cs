using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    public List<Item> Items
    {
        get 
        {
            if (_items == null)
            {
                _items = new List<Item>();
            }

            return _items; 
        }
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }
    public bool HasItem(string name)
    {
        foreach (Item item in _items)
        {
            if (item.Name == name)
            {
                return true;
            }
        }

        return false;
    }

    private int FetchItem(Item initialItem)
    {
        for (int i = 0; i < this.Items.Count; i++)
        {
            if (initialItem == this.Items[i])
            {
                return i;
            }
        }
        return 0;
    }
    public void SwapItemsFromCharacter(string itemTypeName, Item initialItem, EquipmentsManager equipmentsManager)
    {
        Item exchangeItem;
        switch (itemTypeName)
        {
            case "Helm":
                exchangeItem = equipmentsManager.Helm;
                equipmentsManager.Helm = (Helm)initialItem;
                break;
            case "ChestArmor":
                exchangeItem = equipmentsManager.ChestArmor;
                equipmentsManager.ChestArmor = (ChestArmor)initialItem;
                break;
            case "Gauntlets":
                exchangeItem = equipmentsManager.Gauntlets;
                equipmentsManager.Gauntlets = (Gauntlets)initialItem;
                break;
            case "LegArmor":
                exchangeItem = equipmentsManager.LegArmor;
                equipmentsManager.LegArmor = (LegArmor)initialItem;
                break;
            case "Main Weapon":
                exchangeItem = equipmentsManager.MainWeapon;
                equipmentsManager.MainWeapon = (Weapon)initialItem;
                break;
            case "Side Weapon":
                exchangeItem = equipmentsManager.SideWeapon;
                equipmentsManager.SideWeapon = (Weapon)initialItem;
                break;
            default:
                exchangeItem = equipmentsManager.Helm;
                equipmentsManager.Helm = (Helm)initialItem;
                break;
        }
        this.Items.Remove(initialItem);
        this.Items.Add(exchangeItem);
    }

    public List<Item> ItemsByType(string itemTypeName) 
    {
        Type desireItemType;

        switch (itemTypeName)
        {
            case "Helm":
                desireItemType = typeof(Helm);
                break;
            case "ChestArmor":
                desireItemType = typeof(ChestArmor);
                break;
            case "Gauntlets":
                desireItemType = typeof(Gauntlets);
                break;
            case "LegArmor":
                desireItemType = typeof(LegArmor);
                break;
            case "Main Weapon":
            case "Side Weapon":
                desireItemType = typeof(Weapon);
                break;
            case "Upgrade Material":
                desireItemType = typeof(UpgradeMaterial);
                break;
            default:
                desireItemType = typeof(Item);
                break;
        }

        List<Item> result = new List<Item>();
        foreach(Item item in _items) 
        {
            Type itemType = item.GetType();
            while ((itemType != typeof(Item)) && (itemType != desireItemType)) 
            {
                itemType = itemType.BaseType;
            }
            
            if (itemType == desireItemType)
            {
                result.Add(item);
            }
        }

        return result;
    }
}