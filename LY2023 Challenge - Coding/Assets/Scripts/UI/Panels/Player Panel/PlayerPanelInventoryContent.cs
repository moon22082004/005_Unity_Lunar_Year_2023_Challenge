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
            value += (int)(this.PlayerInventory.Items.Count / 15);

            return value;
        }
    }

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

    private void Update()
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
        
        for (int i = 1; i <= this.NumberOfPages; i++)
        {
            List<Item> items = new List<Item>();
            for (int j = ((i - 1) * 15); j < Mathf.Min(i * 15, this.PlayerInventory.Items.Count); j++)
            {
                items.Add(this.PlayerInventory.Items[j]);
            }

            this.transform.GetChild(i + 1).GetComponent<ItemsUIManager>().Items = items;
        }
    }

    // Buttons
    public void CallOtherInventoryPage(int offsetValue)
    {
        _currentPage = (int)Mathf.Clamp(_currentPage + offsetValue, 0, this.NumberOfPages - 1);
    }
}