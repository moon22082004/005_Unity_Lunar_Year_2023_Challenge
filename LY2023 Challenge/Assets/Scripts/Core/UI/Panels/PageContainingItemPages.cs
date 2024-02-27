using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace LY2023Challenge
{
    public abstract class PageContainingItemPages : MonoBehaviour
    {
        protected abstract InventoryManager SubjectInventory
        {
            get;
        }

        [SerializeField] private ItemType _itemDisplayType;
        protected ItemType ItemDisplayType
        {
            get => _itemDisplayType;
            set => _itemDisplayType = value;
        }

        private bool _isNotSpawnItemsPages;
        protected bool IsNotSpawnItemsPages
        {
            get => _isNotSpawnItemsPages;
            set => _isNotSpawnItemsPages = value;
        }

        private int _currentPage;
        protected int CurrentPage
        {
            get => _currentPage; 
            set => _currentPage = value;
        }

        [SerializeField] private Button _previousPageButton;
        protected Button PreviousPageButton
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
        protected Button NextPageButton
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

        [SerializeField] private Transform _itemPagesTransform;
        protected Transform ItemPagesTransform
        {
            get
            {
                if (_itemPagesTransform == null)
                {
                    _itemPagesTransform = this.transform.GetChild(4);
                }

                return _itemPagesTransform;
            }
        }

        public abstract GameObject ItemPage
        {
            get;
        }

        protected int NumberOfPages
        {
            get
            {
                int value = 1;
                switch (_itemDisplayType)
                {
                    case ItemType.EQUIPMENT:
                        value += (int)(this.SubjectInventory.EquipmentItems("Equipment").Count / this.NumberOfItemsInEachPage);
                        break;
                    case ItemType.UPGRADE_MATERIAL:
                        value += (int)(this.SubjectInventory.UpgradeMaterialItems().Count / this.NumberOfItemsInEachPage);
                        break;
                    case ItemType.KEY_ITEM:
                        break;
                }
                return value;
            }
        }

        protected int NumberOfItemsInEachPage => this.ItemPage.transform.childCount / 2;

        protected virtual void OnEnable()
        {
            this.ItemDisplayType = ItemType.UPGRADE_MATERIAL;
            this.IsNotSpawnItemsPages = false;
            this.CurrentPage = 0;

            this.UpdatePageContent();
        }

        protected virtual void UpdatePageContent()
        {
            if (!this.IsNotSpawnItemsPages)
            {
                this.PreviousPageButton.interactable = !(this.CurrentPage == 0);
                this.NextPageButton.interactable = !(this.CurrentPage == this.NumberOfPages);

                // Remove all of the existing Item Pages
                int oldNumberOfPages = this.ItemPagesTransform.childCount;
                for (int i = oldNumberOfPages - 1; i >= 0; i--)
                {
                    Destroy(this.ItemPagesTransform.GetChild(i).gameObject);
                }
                this.ItemPagesTransform.DetachChildren();

                // Instantiate the missing Item Pages
                while (this.ItemPagesTransform.childCount < this.NumberOfPages)
                {
                    GameObject page = Instantiate(this.ItemPage);
                    page.name = $"{this.ItemPage.name} {this.transform.childCount - 1}";
                    page.transform.SetParent(this.ItemPagesTransform, false);
                }

                for (int i = 0; i < this.NumberOfPages; i++)
                {
                    if (i != this.CurrentPage)
                    {
                        this.ItemPagesTransform.GetChild(i).gameObject.SetActive(false);
                    }
                    else
                    {
                        this.ItemPagesTransform.GetChild(i).gameObject.SetActive(true);
                    }
                }

                switch (_itemDisplayType)
                {
                    case ItemType.EQUIPMENT:
                        List<Item> items = this.SubjectInventory.EquipmentItems("Equipment");
                        for (int i = 1; i <= this.NumberOfPages; i++)
                        {
                            List<ItemAndNumber> itemsInAPage = new List<ItemAndNumber>();
                            for (int j = ((i - 1) * this.NumberOfItemsInEachPage); j < Mathf.Min(i * this.NumberOfItemsInEachPage, items.Count); j++)
                            {
                                itemsInAPage.Add(new ItemAndNumber() { Item = items[j], NumberOfItem = 1 });
                            }

                            this.ItemPagesTransform.GetChild(i - 1).GetComponent<InspectionPanelInventoryPageItemPage>().Items = itemsInAPage;
                        }
                        break;
                    case ItemType.UPGRADE_MATERIAL:
                        List<ItemAndNumber> itemsWithNumber = this.SubjectInventory.UpgradeMaterialItems();
                        for (int i = 1; i <= this.NumberOfPages; i++)
                        {
                            List<ItemAndNumber> itemsInAPage = new List<ItemAndNumber>();
                            for (int j = ((i - 1) * this.NumberOfItemsInEachPage); j < Mathf.Min(i * this.NumberOfItemsInEachPage, itemsWithNumber.Count); j++)
                            {
                                itemsInAPage.Add(itemsWithNumber[j]);
                            }

                            this.ItemPagesTransform.GetChild(i - 1).GetComponent<InspectionPanelInventoryPageItemPage>().Items = itemsInAPage;
                        }
                        break;
                    case ItemType.KEY_ITEM:
                        break;
                }
            }
        }

        public void DisplayOtherInventoryPage(int offsetValue)
        {
            this.CurrentPage = (int)Mathf.Clamp(_currentPage + offsetValue, 0, this.NumberOfPages - 1);

            this.UpdatePageContent();
        }

        public void SortItemsType(string itemDisplayTypeName)
        {
            itemDisplayTypeName = itemDisplayTypeName.ToUpper();

            ItemType itemDisplayType = ItemType.UPGRADE_MATERIAL;
            if (Enum.TryParse<ItemType>(itemDisplayTypeName, out ItemType itemType))
            {
                itemDisplayType = itemType;
            }
            else
            {
                // Handle the case when the string doesn't match any ItemType
                throw new ArgumentException("Invalid item type", nameof(itemDisplayTypeName));
            }

            this.IsNotSpawnItemsPages = true;
            this.ItemDisplayType = itemDisplayType;

            if (this.ItemPagesTransform.childCount > 0)
            {
                int numOfPreviousItemsPage = this.ItemPagesTransform.childCount;
                for (int i = numOfPreviousItemsPage - 1; i >= 0; i--)
                {
                    Destroy(this.ItemPagesTransform.GetChild(i).gameObject);
                }
            }

            this.IsNotSpawnItemsPages = false;

            this.UpdatePageContent();
        }
    }
}
