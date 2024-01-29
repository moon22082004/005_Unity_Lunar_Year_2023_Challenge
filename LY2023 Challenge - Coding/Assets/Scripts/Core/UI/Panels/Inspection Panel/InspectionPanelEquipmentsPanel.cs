using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanelEquipmentsPanel : MonoBehaviour
{
    private EquipmentsManager PlayerEquipments => LunarMonoBehaviour.Instance.Player.GetComponent<EquipmentsManager>();

    [SerializeField] private Image _helmSlotUIImage;
    public Image HelmSlotUIImage
    {
        get 
        {
            if (_helmSlotUIImage == null)
            {
                _helmSlotUIImage = this.transform.GetChild(2).GetChild(0).GetComponent<Image>();
            }

            return _helmSlotUIImage;
        }
    }

    [SerializeField] private Image _armorSlotUIImage;
    public Image ArmorSlotUIImage
    {
        get
        {
            if (_armorSlotUIImage == null)
            {
                _armorSlotUIImage = this.transform.GetChild(3).GetChild(0).GetComponent<Image>();
            }

            return _armorSlotUIImage;
        }
    }

    [SerializeField] private Image _mainWeaponSlotUIImage;
    public Image MainWeaponSlotUIImage
    {
        get
        {
            if (_mainWeaponSlotUIImage == null)
            {
                _mainWeaponSlotUIImage = this.transform.GetChild(4).GetChild(0).GetComponent<Image>();
            }

            return _mainWeaponSlotUIImage;
        }
    }

    [SerializeField] private Image _sideWeaponSlotUIImage;
    public Image SideWeaponSlotUIImage
    {
        get
        {
            if (_sideWeaponSlotUIImage == null)
            {
                _sideWeaponSlotUIImage = this.transform.GetChild(5).GetChild(0).GetComponent<Image>();
            }

            return _sideWeaponSlotUIImage;
        }
    }

    [SerializeField] private List<Image> _previewUIImages;
    public List<Image> PreviewUIImages
    {
        get
        {
            if (_previewUIImages.Count < 2)
            {
                _previewUIImages = new List<Image>();

                _previewUIImages.Add(this.transform.GetChild(1).GetChild(0).GetComponent<Image>());
                _previewUIImages.Add(this.transform.GetChild(1).GetChild(1).GetComponent<Image>());
            }

            return _previewUIImages;
        }
    }

    private void OnEnable()
    {
        this.UpdateEquipmentsDisplay();
    }

    public void UpdateEquipmentsDisplay()
    {
        this.HelmSlotUIImage.sprite = this.PlayerEquipments.Helm.ItemIcon;
        this.ArmorSlotUIImage.sprite = this.PlayerEquipments.Armor.ItemIcon;
        this.MainWeaponSlotUIImage.sprite = this.PlayerEquipments.MainWeapon.ItemIcon;
        this.SideWeaponSlotUIImage.sprite = this.PlayerEquipments.SideWeapon.ItemIcon;

        this.PreviewUIImages[0].sprite = this.HelmSlotUIImage.sprite;
        this.PreviewUIImages[1].sprite = Resources.Load<Sprite>("Sprites/UI/Armors with Weapons/" + this.PlayerEquipments.Armor.Name + " with " + this.PlayerEquipments.MainWeapon.Name);
    }
}
