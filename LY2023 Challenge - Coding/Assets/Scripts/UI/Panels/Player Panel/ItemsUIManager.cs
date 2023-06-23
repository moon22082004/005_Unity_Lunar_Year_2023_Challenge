using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsUIManager : MonoBehaviour
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
                
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    _buttons.Add(this.transform.GetChild(i).GetComponent<Button>());
                }   
            }

            return _buttons;
        }
    }

    private void Update()
    {
        for (int i = 0; i < Mathf.Min(15, this.Items.Count); i++) 
        {
            this.transform.GetChild(i).GetComponent<ItemUIManager>().Item = this.Items[i].Item;
            this.transform.GetChild(i).GetComponent<ItemUIManager>().Number = this.Items[i].NumberOfItem;
        }
    }
}