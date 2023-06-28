using System;
using System.Collections.Generic;
using System.Linq;
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

            _items = _items.OrderBy(item => item.ShortDescription).ToList();

            return _items; 
        }
    }

    [SerializeField] private int _souls;
    public int Souls
    {
        get => _souls;
        set => _souls = value;
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

    public List<Item> EquipmentItems(string itemTypeName) 
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
            case "Equipment":
                desireItemType = typeof(Equipment);
                break;
            default:
                desireItemType = typeof(Equipment);
                break;
        }

        List<Item> result = new List<Item>();
        foreach(Item item in this.Items) 
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

    public List<ItemAndNumber> UpgradeMaterialItems()
    {
        List<ItemAndNumber> result = new List<ItemAndNumber>();

        // Find all equipment items
        List<Item> upgradeMaterialItems = new List<Item>();
        foreach (Item item in this.Items)
        {
            Type itemType = item.GetType();
            while ((itemType != typeof(Item)) && (itemType != typeof(UpgradeMaterial)))
            {
                itemType = itemType.BaseType;
            }

            if (itemType == typeof(UpgradeMaterial))
            {
                upgradeMaterialItems.Add(item);
            }
        }

        List<Item> distinctItems = upgradeMaterialItems.GroupBy(item => item.ShortDescription).Select(group => group.First()).ToList();

        foreach (Item item in distinctItems)
        {
            int number = 0;
            foreach (Item item2 in upgradeMaterialItems) 
            {
                if ((item.Name == item2.Name) && (item.Level == item2.Level))
                {
                    number++;
                }
            }

            result.Add(new ItemAndNumber() { Item = item, NumberOfItem = number});
        }

        return result;
    }
}