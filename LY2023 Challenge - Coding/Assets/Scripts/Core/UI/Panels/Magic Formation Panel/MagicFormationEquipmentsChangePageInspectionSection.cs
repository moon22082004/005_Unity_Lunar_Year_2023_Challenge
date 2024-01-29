using UnityEngine;
using UnityEngine.UI;

public class MagicFormationEquipmentsChangePageInspectionSection : MonoBehaviour
{
    [SerializeField] private Button _helmSlotUIButton;
    public Button HelmSlotUIButton
    {
        get
        {
            if (_helmSlotUIButton == null)
            {
                _helmSlotUIButton = this.transform.GetChild(2).GetComponent<Button>();
            }

            return _helmSlotUIButton;
        }
    }

    [SerializeField] private Button _armorSlotUIButton;
    public Button ArmorSlotUIButton
    {
        get
        {
            if (_armorSlotUIButton == null)
            {
                _armorSlotUIButton = this.transform.GetChild(3).GetComponent<Button>();
            }

            return _armorSlotUIButton;
        }
    }

    [SerializeField] private Button _mainWeaponSlotUIButton;
    public Button MainWeaponSlotUIButton
    {
        get
        {
            if (_mainWeaponSlotUIButton == null)
            {
                _mainWeaponSlotUIButton = this.transform.GetChild(4).GetComponent<Button>();
            }

            return _mainWeaponSlotUIButton;
        }
    }

    [SerializeField] private Button _sideWeaponSlotUIButton;
    public Button SideWeaponSlotUIButton
    {
        get
        {
            if (_sideWeaponSlotUIButton == null)
            {
                _sideWeaponSlotUIButton = this.transform.GetChild(5).GetComponent<Button>();
            }

            return _sideWeaponSlotUIButton;
        }
    }

    private MagicFormationEquipmentsChangePageSwapSection _swapSection; 
    public MagicFormationEquipmentsChangePageSwapSection SwapSection
    {
        get 
        {
            if (_swapSection == null)
            {
                _swapSection = this.transform.parent.GetChild(1).GetComponent<MagicFormationEquipmentsChangePageSwapSection>();
            }

            return _swapSection;
        }
    }

    private void OnEnable()
    {
        this.HelmSlotUIButton.interactable = true;
        this.ArmorSlotUIButton.interactable = true;
        this.MainWeaponSlotUIButton.interactable = true;
        this.SideWeaponSlotUIButton.interactable = true;
    }

    public void PrepareToSwapHelm()
    {
        this.HelmSlotUIButton.interactable = false;

        this.SwapSection.CallSwapEquipmentsPage("Helm");

        this.ArmorSlotUIButton.interactable = true;
        this.MainWeaponSlotUIButton.interactable = true;
        this.SideWeaponSlotUIButton.interactable = true;
    }

    public void PrepareToSwapArmor()
    {
        this.ArmorSlotUIButton.interactable = false;

        this.SwapSection.CallSwapEquipmentsPage("Armor");

        this.HelmSlotUIButton.interactable = true;
        this.MainWeaponSlotUIButton.interactable = true;
        this.SideWeaponSlotUIButton.interactable = true;
    }

    public void PrepareToSwapMainWeapon()
    {
        this.MainWeaponSlotUIButton.interactable = false;

        this.SwapSection.CallSwapEquipmentsPage("Main Weapon");

        this.HelmSlotUIButton.interactable = true;
        this.ArmorSlotUIButton.interactable = true;
        this.SideWeaponSlotUIButton.interactable = true;
    }

    public void PrepareToSwapSideWeapon()
    {
        this.SideWeaponSlotUIButton.interactable = false;

        this.SwapSection.CallSwapEquipmentsPage("Side Weapon");

        this.ArmorSlotUIButton.interactable = true;
        this.HelmSlotUIButton.interactable = true;
        this.MainWeaponSlotUIButton.interactable = true;
    }
}
