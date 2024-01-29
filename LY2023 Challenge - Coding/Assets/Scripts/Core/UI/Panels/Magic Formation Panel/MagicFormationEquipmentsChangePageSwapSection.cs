using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicFormationEquipmentsChangePageSwapSection : MonoBehaviour
{
    private InventoryManager PlayerInventory => LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>();

    [SerializeField] private string _itemDisplayType;
    private string ItemDisplayType
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
            if (this.ItemDisplayType != "")
            {
                value = 1 + (int)(this.PlayerInventory.EquipmentItems(this.ItemDisplayType).Count / 16);
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
        this.ItemDisplayType = "";
        _currentPage = 0;
    }

    private void Update()
    {
        this.ItemPages.SetActive(this.ItemDisplayType != "");
        this.PreviousPageButton.gameObject.SetActive(this.ItemDisplayType != "");
        this.NextPageButton.gameObject.SetActive(this.ItemDisplayType != ""); 
    }

    public void CallSwapEquipmentsPage(string itemDisplayType)
    {
        this.ItemDisplayType = itemDisplayType;
        _currentPage = 0;

        this.PreviousPageButton.interactable = !(_currentPage == 0);
        this.NextPageButton.interactable = !(_currentPage == this.NumberOfPages);

        while (this.ItemPages.transform.childCount < this.NumberOfPages)
        {
            GameObject page = Instantiate(this.ItemPage);
            page.name = $"{this.ItemPage.name} {this.transform.childCount - 1}";
            page.transform.SetParent(this.ItemPages.transform, false);
        }

        for (int i = 0; i < this.NumberOfPages; i++)
        {
            if (i != _currentPage)
            {
                this.ItemPages.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                this.ItemPages.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        List<Item> items = this.PlayerInventory.EquipmentItems(this.ItemDisplayType);
        for (int i = 1; i <= this.NumberOfPages; i++)
        {
            List<ItemAndNumber> itemsInAPage = new List<ItemAndNumber>();
            for (int j = ((i - 1) * 16); j < Mathf.Min(i * 16, items.Count); j++)
            {
                itemsInAPage.Add(new ItemAndNumber() { Item = items[j], NumberOfItem = 1 });
            }

            this.ItemPages.transform.GetChild(i - 1).GetComponent<InspectionPanelInventoryPageItemPage>().Items = itemsInAPage;
        }

        for (int i = 0; i < this.NumberOfPages; i++)
        {
            foreach (Button button in this.ItemPages.transform.GetChild(i).GetComponent<InspectionPanelInventoryPageItemPage>().Buttons)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => this.ChangeEquipment(this.ItemDisplayType, button.GetComponent<InspectionPanelInventoryPageItemPageItemSlot>().Item));
            }
        }
    }

    public void ChangeEquipment(string itemTypeName, Item choosenItem)
    {
        if (choosenItem != null)
        {
            this.PlayerInventory.SwapItemsFromCharacter(itemTypeName, choosenItem, LunarMonoBehaviour.Instance.Player.GetComponent<EquipmentsManager>());
            _itemDisplayType = "";

            this.transform.parent.GetChild(0).GetComponent<InspectionPanelEquipmentsPanel>().UpdateEquipmentsDisplay();
        }
    }
}
