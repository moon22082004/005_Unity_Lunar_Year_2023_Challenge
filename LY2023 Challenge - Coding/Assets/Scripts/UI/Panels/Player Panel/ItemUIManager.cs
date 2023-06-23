using TMPro;
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

    [SerializeField] private int _number;
    public int Number
    {
        get
        {
            if (_number <= 0)
            {
                _number = 1;
            }

            return _number;
        }
        set => _number = value;
    }

    [SerializeField] private Image _image;
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

    [SerializeField] private TextMeshProUGUI _text;
    private TextMeshProUGUI Text
    {
        get
        {
            if (_text == null)
            {
                _text = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            }

            return _text;
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
            this.Text.enabled = true;
            this.Text.text = this.Number.ToString();
        }
        else
        {
            this.Text.enabled = false;
        }
    }
}