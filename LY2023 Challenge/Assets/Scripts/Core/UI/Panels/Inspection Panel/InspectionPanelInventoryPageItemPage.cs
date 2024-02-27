using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LY2023Challenge
{
    public class InspectionPanelInventoryPageItemPage : MonoBehaviour
    {
        [SerializeField] private List<ItemAndNumber> _items;
        public List<ItemAndNumber> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<ItemAndNumber>();
                }

                return _items;
            }
            set => _items = value;
        }

        [SerializeField] private List<Button> _buttons;
        public List<Button> Buttons
        {
            get
            {
                if (_buttons.Count == 0)
                {
                    _buttons = new List<Button>();

                    for (int i = 0; i < (this.transform.childCount / 2); i++)
                    {
                        _buttons.Add(this.transform.GetChild(i).GetComponent<Button>());
                    }
                }

                return _buttons;
            }
        }

        private void Update()
        {
            for (int i = 0; i < Mathf.Min(this.transform.childCount / 2, this.Items.Count); i++)
            {
                this.transform.GetChild(i).GetComponent<InspectionPanelInventoryPageItemPageItemSlot>().Item = this.Items[i].Item;
                this.transform.GetChild(i).GetComponent<InspectionPanelInventoryPageItemPageItemSlot>().Number = this.Items[i].NumberOfItem;
            }
        }
    }
}