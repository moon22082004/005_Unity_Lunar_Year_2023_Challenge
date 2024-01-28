using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicFormationEquipmentsChangePageSwapSection : MonoBehaviour
{
    private InventoryManager PlayerInventory => LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>();

    [SerializeField] private string _itemDisplayType;
    public string ItemDisplayType
    {
        get
        {
            return _itemDisplayType;
        }
        set
        {
            _itemDisplayType = value;
        }
    }

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
                _nextPageButton = this.transform.GetChild(2).GetComponent<Button>();
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

    [SerializeField] private GameObject _itemPages;
    private GameObject ItemPages
    {
        get
        {
            if (_itemPages == null)
            {
                _itemPages = this.transform.GetChild(3).gameObject;
            }

            return _itemPages;
        }
    }


    private int NumberOfPages
    {
        get
        {
            int value;
            if (_itemDisplayType == "")
            {
                value = 1 + (int)(this.PlayerInventory.EquipmentItems(_itemDisplayType).Count / 16);
            }
            else
            {
                value = 0;
            }

            return value;
        }
    }

    private void OnEnable()
    {
        _itemDisplayType = "";
        _currentPage = 0;
    }

    private void Update()
    {
        this.ItemPages.SetActive(_itemDisplayType != "");
        this.PreviousPageButton.gameObject.SetActive(_itemDisplayType != "");
        this.NextPageButton.gameObject.SetActive(_itemDisplayType != ""); 

        if (_itemDisplayType != "")
        {
            this.PreviousPageButton.interactable = !(_currentPage == 0);
            this.NextPageButton.interactable = !(_currentPage == this.NumberOfPages);

            while (this.transform.GetChild(3).childCount < this.NumberOfPages)
            {
                GameObject page = Instantiate(this.ItemPage);
                page.name = $"{this.ItemPage.name} {this.transform.childCount - 1}";
                page.transform.SetParent(this.transform.GetChild(4), false);
            }

            for (int i = 0; i < this.NumberOfPages; i++)
            {
                if (i != _currentPage)
                {
                    this.transform.GetChild(3).GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    this.transform.GetChild(3).GetChild(i).gameObject.SetActive(true);
                }
            }

            List<Item> items = this.PlayerInventory.EquipmentItems(_itemDisplayType);
            for (int i = 1; i <= this.NumberOfPages; i++)
            {
                List<ItemAndNumber> itemsInAPage = new List<ItemAndNumber>();
                for (int j = ((i - 1) * 16); j < Mathf.Min(i * 16, items.Count); j++)
                {
                    itemsInAPage.Add(new ItemAndNumber() { Item = items[j], NumberOfItem = 1 });
                }

                this.transform.GetChild(3).GetChild(i - 1).GetComponent<InspectionPanelInventoryPageItemPage>().Items = itemsInAPage;
            }
        }
    }
}
