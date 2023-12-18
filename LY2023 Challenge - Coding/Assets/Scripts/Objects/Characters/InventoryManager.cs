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
                exchangeItem = equipmentsManager.Armor;
                equipmentsManager.Armor = (Armor)initialItem;
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
                desireItemType = typeof(Armor);
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

    [SerializeField] private List<Skill> _skills;
    public List<Skill> Skills
    {
        get
        {
            if (_skills == null)
            {
                _skills = new List<Skill>();
            }

            _skills = _skills.OrderBy(skill => skill.Name).ToList();

            return _skills;
        }
    }

    public List<Skill> SkillsByType(string skillTypeName)
    {
        Type desireSkillType;

        switch (skillTypeName)
        {
            case "MainSkill":
                desireSkillType = typeof(MainSkill);
                break;
            case "SideSkill":
                desireSkillType = typeof(SideSkill);
                break;
            default:
                desireSkillType = typeof(SideSkill);
                break;
        }

        List<Skill> result = new List<Skill>();
        foreach (var skill in this.Skills)
        {
            Type skillType = skill.GetType();
            while ((skillType != typeof(Skill)) && (skillType != desireSkillType))
            {
                skillType = skillType.BaseType;
            }

            if (skillType == desireSkillType)
            {
                result.Add(skill);
            }
        }

        return result;
    }

    public void SwapSkillFromCharacter(string skillTypeName, int index, Skill initialSkill, SkillsManager playerSkills)
    {
        Skill exchangeSkill;
        switch (skillTypeName)
        {
            case "SideSkill":
                exchangeSkill = playerSkills.SideSkill;
                playerSkills.SideSkill = (SideSkill)initialSkill;
                break;
            case "MainSkill":
                exchangeSkill = playerSkills.MainSkills[index];
                playerSkills.MainSkills[index] = (MainSkill)initialSkill;
                break;
            default:
                exchangeSkill = playerSkills.SideSkill;
                playerSkills.SideSkill = (SideSkill)initialSkill;
                break;
        }
        this.Skills.Remove(initialSkill);
        this.Skills.Add(exchangeSkill);
    }
}