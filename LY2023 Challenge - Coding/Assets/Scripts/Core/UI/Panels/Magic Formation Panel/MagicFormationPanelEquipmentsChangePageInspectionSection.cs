using UnityEngine;
using UnityEngine.UI;

public class MagicFormationPanelEquipmentsChangePageInspectionSection : MonoBehaviour
{
    private MagicFormationPanelEquipmentsChangePageSwapSection _swapSectionManager;
    private MagicFormationPanelEquipmentsChangePageSwapSection SwapSectionManager
    {
        get
        {
            if (_swapSectionManager == null)
            {
                _swapSectionManager = this.transform.parent.GetChild(1).GetComponent<MagicFormationPanelEquipmentsChangePageSwapSection>();
            }

            return _swapSectionManager;
        }
    }

    [SerializeField] private Button _helmSlotUIButton;
    private Button HelmSlotUIButton
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
    private Button ArmorSlotUIButton
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
    private Button MainWeaponSlotUIButton
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
    private Button SideWeaponSlotUIButton
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

    private void OnEnable()
    {
        this.RefreshEquipmentsSwapButtons();
    }

    public void RefreshEquipmentsSwapButtons()
    {
        this.HelmSlotUIButton.interactable = true;
        this.ArmorSlotUIButton.interactable = true;
        this.MainWeaponSlotUIButton.interactable = true;
        this.SideWeaponSlotUIButton.interactable = true;
    }

    public void PrepareToSwapHelm()
    {
        this.HelmSlotUIButton.interactable = false;

        this.SwapSectionManager.CallSwapEquipmentsPage("Helm");

        this.ArmorSlotUIButton.interactable = true;
        this.MainWeaponSlotUIButton.interactable = true;
        this.SideWeaponSlotUIButton.interactable = true;
    }

    public void PrepareToSwapArmor()
    {
        this.ArmorSlotUIButton.interactable = false;

        this.SwapSectionManager.CallSwapEquipmentsPage("Armor");

        this.HelmSlotUIButton.interactable = true;
        this.MainWeaponSlotUIButton.interactable = true;
        this.SideWeaponSlotUIButton.interactable = true;
    }

    public void PrepareToSwapMainWeapon()
    {
        this.MainWeaponSlotUIButton.interactable = false;

        this.SwapSectionManager.CallSwapEquipmentsPage("Main Weapon");

        this.HelmSlotUIButton.interactable = true;
        this.ArmorSlotUIButton.interactable = true;
        this.SideWeaponSlotUIButton.interactable = true;
    }

    public void PrepareToSwapSideWeapon()
    {
        this.SideWeaponSlotUIButton.interactable = false;

        this.SwapSectionManager.CallSwapEquipmentsPage("Side Weapon");

        this.ArmorSlotUIButton.interactable = true;
        this.HelmSlotUIButton.interactable = true;
        this.MainWeaponSlotUIButton.interactable = true;
    }
}
