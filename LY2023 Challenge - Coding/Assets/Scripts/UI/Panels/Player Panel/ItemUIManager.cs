using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{

    [SerializeField] private Item _item;
    public Item Item
    {
        get => _item;
        set => _item = value;
    }

    private Image _image;
    private Image Image
    {
        get 
        { 
            if (_image == null)
            {
                _image = this.transform.GetChild(0).GetComponent<Image>();
            }

            return _image; 
        }
    }

    private Button _button;
    public Button Button
    {
        get
        {
            if (_button == null)
            {
                _button = this.transform.GetChild(0).GetComponent<Button>();
            }

            return _button;
        }
    }


    private void Update()
    {
        if (this.Item != null) 
        {
            this.Image.sprite = this.Item.ItemIcon;
        }
    }
}