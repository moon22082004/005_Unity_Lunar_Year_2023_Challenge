using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanelInventoryPage : MonoBehaviour
{
    private InventoryManager PlayerInventory => LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>();

    [SerializeField] private ItemType _itemDisplayType;
    private bool _isNotSpawnItemsPages;
    private int _currentPage;

    [SerializeField] private Button _previousPageButton;
    private Button PreviousPageButton
    {
        get 
        {
            if (_previousPageButton == null)
            {
                _previousPageButton = this.transform.GetChild(1).GetComponent<Button>();
            }

            return _previousPageButton;
        }
    }

    [SerializeField] private Button _nextPageButton;
    private Button NextPageButton
    {
        get
        {
            if (_nextPageButton == null)
            {
                _nextPageButton = this.transform.GetChild(1).GetComponent<Button>();
            }

            return _nextPageButton;
        }
    }

    [SerializeField] private GameObject _itemPage;
    public GameObject ItemPage
    {
        get
        {
            if (_itemPage == null)
            {
                _itemPage = Resources.Load("Prefabs/UI/Inspection Panel/Item Page") as GameObject;
            }

            return _itemPage;
        }
    }

    private int NumberOfPages
    {
        get
        {
            int value = 1;
            switch (_itemDisplayType)
            {
                case ItemType.EQUIPMENT:
                    value += (int)(this.PlayerInventory.EquipmentItems("Equipment").Count / 16);
                    break;
                case ItemType.UPGRADE_MATERIAL:
                    value += (int)(this.PlayerInventory.UpgradeMaterialItems().Count / 16);
                    break;
                case ItemType.KEY_ITEM:
                    break;
            }
            return value;
        }
    }

    private void OnEnable()
    {
        _itemDisplayType = ItemType.UPGRADE_MATERIAL;
        _isNotSpawnItemsPages = false;
        _currentPage = 0;
    }

    private void Update()
    {
        if (!_isNotSpawnItemsPages) 
        {
            this.PreviousPageButton.interactable = !(_currentPage == 0);
            this.NextPageButton.interactable = !(_currentPage == this.NumberOfPages);

            while (this.transform.GetChild(4).childCount < this.NumberOfPages) 
            {
                GameObject page = Instantiate(this.ItemPage);
                page.name = $"{this.ItemPage.name} {this.transform.childCount - 1}";
                page.transform.SetParent(this.transform.GetChild(4), false);
            }

            for (int i = 0; i < this.NumberOfPages; i++)
            {
                if (i != _currentPage)
                {
                    this.transform.GetChild(4).GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    this.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
                }
            }

            switch (_itemDisplayType)
            {
                case ItemType.EQUIPMENT:
                    List<Item> items = this.PlayerInventory.EquipmentItems("Equipment");
                    for (int i = 1; i <= this.NumberOfPages; i++)
                    {
                        List<ItemAndNumber> itemsInAPage = new List<ItemAndNumber>();
                        for (int j = ((i - 1) * 16); j < Mathf.Min(i * 16, items.Count); j++)
                        {
                            itemsInAPage.Add(new ItemAndNumber() { Item = items[j], NumberOfItem = 1 });
                        }

                        this.transform.GetChild(4).GetChild(i - 1).GetComponent<InspectionPanelInventoryPageItemPage>().Items = itemsInAPage;
                    }
                    break;
                case ItemType.UPGRADE_MATERIAL:
                    List<ItemAndNumber> itemsWithNumber = this.PlayerInventory.UpgradeMaterialItems();
                    for (int i = 1; i <= this.NumberOfPages; i++)
                    {
                        List<ItemAndNumber> itemsInAPage = new List<ItemAndNumber>();
                        for (int j = ((i - 1) * 16); j < Mathf.Min(i * 16, itemsWithNumber.Count); j++)
                        {
                            itemsInAPage.Add(itemsWithNumber[j]);
                        }

                        this.transform.GetChild(4).GetChild(i - 1).GetComponent<InspectionPanelInventoryPageItemPage>().Items = itemsInAPage;
                    }
                    break;
                case ItemType.KEY_ITEM:
                    break;
            }    
        }
    }
}
