using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanelInventoryContent : MonoBehaviour
{
    [SerializeField] private InventoryManager _playerInventory;
    private InventoryManager PlayerInventory
    {
        get 
        {
            if ( _playerInventory == null )
            {
                _playerInventory = GameObject.Find("Player/Character").GetComponent<InventoryManager>();
            }

            return _playerInventory;
        }
    }

    private int NumberOfPages
    {
        get
        {
            int value = 1;
            switch (_itemTypeName)
            {
                case "Equipment":
                    value += (int)(this.PlayerInventory.EquipmentItems(_itemTypeName).Count / 15);
                    break;
                case "Upgrade Material":
                    value += (int)(this.PlayerInventory.UpgradeMaterialItems().Count / 15);
                    break;
            }
            return value;
       
        }
    }
    private bool _isNotSpawnItemsPages;

    private int _currentPage;

    [SerializeField] private GameObject _inventoryPage;
    public GameObject InventoryPage
    {
        get 
        { 
            if (_inventoryPage == null ) 
            {
                _inventoryPage = Resources.Load("Prefabs/UI/Player Panel/Item Page") as GameObject;
            }

            return _inventoryPage; 
        }
    }
    [SerializeField] private string _itemTypeName;

    private void OnEnable()
    {
        _itemTypeName = "Upgrade Material";
        _isNotSpawnItemsPages = false;
    }

    private void Update()
    {
        if (!_isNotSpawnItemsPages)
        {
            this.transform.GetChild(0).GetChild(0).GetComponent<Button>().interactable = !(_currentPage == 0);
            this.transform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = !(_currentPage == this.NumberOfPages - 1);

            while (this.transform.childCount < this.NumberOfPages + 2)
            {
                GameObject page = Instantiate(this.InventoryPage);
                page.name = $"{this.InventoryPage.name} {this.transform.childCount - 1}";
                page.transform.SetParent(this.transform, false);
            }

            for (int i = 0; i < this.NumberOfPages; i++)
            {
                if (i != _currentPage)
                {
                    this.transform.GetChild(i + 2).gameObject.SetActive(false);
                }
                else
                {
                    this.transform.GetChild(i + 2).gameObject.SetActive(true);
                }
            }

            switch (_itemTypeName)
            {
                case "Equipment":
                    List<Item> items = this.PlayerInventory.EquipmentItems(_itemTypeName);
                    for (int i = 1; i <= this.NumberOfPages; i++)
                    {
                        List<ItemAndNumber> itemsInAPage = new List<ItemAndNumber>();
                        for (int j = ((i - 1) * 15); j < Mathf.Min(i * 15, items.Count); j++)
                        {
                            itemsInAPage.Add(new ItemAndNumber() { Item = items[j], NumberOfItem = 1 });
                        }

                        this.transform.GetChild(i + 1).GetComponent<ItemIconsUIManager>().Items = itemsInAPage;
                    }
                    break;
                case "Upgrade Material":
                    List<ItemAndNumber> itemsWithNumber = this.PlayerInventory.UpgradeMaterialItems();
                    for (int i = 1; i <= this.NumberOfPages; i++)
                    {
                        List<ItemAndNumber> itemsInAPage = new List<ItemAndNumber>();
                        for (int j = ((i - 1) * 15); j < Mathf.Min(i * 15, itemsWithNumber.Count); j++)
                        {
                            itemsInAPage.Add(itemsWithNumber[j]);
                        }

                        this.transform.GetChild(i + 1).GetComponent<ItemIconsUIManager>().Items = itemsInAPage;
                    }
                    break;
            }
        }
    }

    // Change Page Buttons
    public void CallOtherInventoryPage(int offsetValue)
    {
        _currentPage = (int)Mathf.Clamp(_currentPage + offsetValue, 0, this.NumberOfPages - 1);
    }
    // Sort Buttons
    public void SortItemsType(string itemTypeName)
    {
        _isNotSpawnItemsPages = true;
        _itemTypeName = itemTypeName;

        if (this.transform.childCount > 2)
        {
            int numOfPreviousItemsPage = this.transform.childCount - 2;
            for (int i = numOfPreviousItemsPage + 1; i > 1; i--)
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }
        }

        _isNotSpawnItemsPages = false;
    }
}