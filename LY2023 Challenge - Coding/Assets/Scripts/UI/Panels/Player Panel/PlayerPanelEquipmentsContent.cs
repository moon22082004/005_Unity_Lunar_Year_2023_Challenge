using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanelEquipmentsContent : MonoBehaviour
{
    [SerializeField] private EquipmentsManager _playerEquipments;
    private EquipmentsManager PlayerEquipments
    {
        get
        {
            if (_playerEquipments == null)
            {
                _playerEquipments = GameObject.Find("Player/Character").GetComponent<EquipmentsManager>();
            }

            return _playerEquipments;
        }
    }

    [SerializeField] private int _currentPage;
    [SerializeField] private string _changeItemTypeName;

    [SerializeField] private Transform _mainEquipmentsPageTransform;
    private Transform MainEquipmentsPageTransform
    {
        get 
        {
            if (_mainEquipmentsPageTransform == null)
            {
                _mainEquipmentsPageTransform = this.transform.GetChild(0);
            }

            return _mainEquipmentsPageTransform;
        }
    }

    [SerializeField] private Transform _sideEquipmentsPageTransform;
    private Transform SideEquipmentsPageTransform
    {
        get
        {
            if (_sideEquipmentsPageTransform == null)
            {
                _sideEquipmentsPageTransform = this.transform.GetChild(1);
            }

            return _sideEquipmentsPageTransform;
        }
    }

    [SerializeField] private Transform _availableItemsPagesTransform;
    private Transform AvailableItemsPagesTransform
    {
        get
        {
            if (_availableItemsPagesTransform == null)
            {
                _availableItemsPagesTransform = this.transform.GetChild(2);
            }

            return _availableItemsPagesTransform;
        }
    }

    [SerializeField] private GameObject _itemPage;
    public GameObject ItemPage
    {
        get
        {
            if (_itemPage == null)
            {
                _itemPage = Resources.Load("Prefabs/UI/Player Panel/Item Page") as GameObject;
            }

            return _itemPage;
        }
    }

    [SerializeField] private List<Item> AvailableItems
    {
        get => LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>().EquipmentItems(_changeItemTypeName);
    }

    [SerializeField] private int NumberOfItemPages
    {
        get
        {
            return (1 + (int)(this.AvailableItems.Count / 15));
        }
    }

    [SerializeField] private int _currentItemPage;

    private void OnEnable()
    {
        _currentPage = 0;
        _currentItemPage = 0;
    }

    private void Update()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (_currentPage != i)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        if (_currentPage == this.transform.childCount - 1)
        {
            while (this.AvailableItemsPagesTransform.childCount < this.NumberOfItemPages + 1)
            {
                GameObject page = Instantiate(this.ItemPage);
                page.name = $"{this.ItemPage.name} {this.AvailableItemsPagesTransform.childCount}";
                page.transform.SetParent(this.AvailableItemsPagesTransform, false);
            }

            this.AvailableItemsPagesTransform.GetChild(0).GetChild(0).GetComponent<Button>().interactable = !(_currentItemPage == 0);
            this.AvailableItemsPagesTransform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = !(_currentItemPage == this.NumberOfItemPages - 1);

            for (int i = 0; i < this.NumberOfItemPages; i++)
            {
                if (i != _currentItemPage)
                {
                    this.AvailableItemsPagesTransform.GetChild(i + 1).gameObject.SetActive(false);
                }
                else
                {
                    this.AvailableItemsPagesTransform.GetChild(i + 1).gameObject.SetActive(true);
                }
            }

            for (int i = 1; i <= this.NumberOfItemPages; i++)
            {
                List<ItemAndNumber> items = new List<ItemAndNumber>();
                for (int j = ((i - 1) * 15); j < Mathf.Min(i * 15, this.AvailableItems.Count); j++)
                {
                    items.Add(new ItemAndNumber() { Item = this.AvailableItems[j], NumberOfItem = 1 });
                }

                this.AvailableItemsPagesTransform.GetChild(i).GetComponent<ItemsUIManager>().Items = items;
            }
        }
        else
        {
            if (this.AvailableItemsPagesTransform.childCount > 1) 
            {
                int numOfPreviousItemsPage = this.AvailableItemsPagesTransform.childCount - 1;
                for (int i = numOfPreviousItemsPage; i >= 1; i--)
                {
                    Destroy(this.AvailableItemsPagesTransform.GetChild(i).gameObject);
                }
            }
        }

        this.MainEquipmentsPageTransform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = this.PlayerEquipments.Helm.ItemIcon;
        this.MainEquipmentsPageTransform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = this.PlayerEquipments.ChestArmor.ItemIcon;
        this.MainEquipmentsPageTransform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = this.PlayerEquipments.Gauntlets.ItemIcon;
        this.MainEquipmentsPageTransform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = this.PlayerEquipments.LegArmor.ItemIcon;
        this.MainEquipmentsPageTransform.GetChild(4).GetChild(0).GetComponent<Image>().sprite = this.PlayerEquipments.MainWeapon.ItemIcon;
        this.MainEquipmentsPageTransform.GetChild(5).GetChild(0).GetComponent<Image>().sprite = this.PlayerEquipments.SideWeapon.ItemIcon;
    }

    // Buttons
    public void CallChangeEquipmentPage(string itemTypeName)
    {
        _changeItemTypeName = itemTypeName;
        _currentPage = 2;

        while (this.AvailableItemsPagesTransform.childCount < this.NumberOfItemPages + 1)
        {
            GameObject page = Instantiate(this.ItemPage);
            page.name = $"{this.ItemPage.name} {this.AvailableItemsPagesTransform.childCount}";
            page.transform.SetParent(this.AvailableItemsPagesTransform, false);
        }

        _currentItemPage = 0;

        for (int i = 1; i <= this.NumberOfItemPages; i++)
        {
            foreach (Button button in this.AvailableItemsPagesTransform.GetChild(i).GetComponent<ItemsUIManager>().Buttons)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => this.ChangeEquipment(itemTypeName, button.GetComponent<ItemUIManager>().Item));
            }
        }
    }
    public void ChangeEquipment(string itemTypeName, Item choosenItem)
    {
        if (choosenItem != null)
        {
            LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>().SwapItemsFromCharacter(itemTypeName, choosenItem, LunarMonoBehaviour.Instance.Player.GetComponent<EquipmentsManager>());
            _currentPage = 0;
        }
    }

    public void CallOtherItemPage(int offsetValue)
    {
        _currentItemPage = (int)Mathf.Clamp(_currentItemPage + offsetValue, 0, NumberOfItemPages - 1);
    }
}