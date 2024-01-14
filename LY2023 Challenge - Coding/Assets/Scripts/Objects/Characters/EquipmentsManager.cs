using UnityEngine;

public class EquipmentsManager : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] private Weapon _mainWeapon;
    [SerializeField] private Weapon _sideWeapon;

    public Weapon MainWeapon
    {
        get => _mainWeapon;
        set => _mainWeapon = value;
    }
    public Weapon SideWeapon
    {
        get => _sideWeapon; 
        set => _sideWeapon = value;
    }
    public void SwapWeapon()
    {
        (_mainWeapon, _sideWeapon) = (_sideWeapon, _mainWeapon);
    }

    [Header("Armor")]
    [SerializeField] private Helm _helm;
    [SerializeField] private Armor _armor;

    public Helm Helm
    {
        get => _helm; 
        set => _helm = value;
    }
    public Armor Armor
    {
        get => _armor;
        set => _armor = value;
    }

    public float EquipLoad
    {
        get => (MainWeapon.Weight + SideWeapon.Weight + Helm.Weight + Armor.Weight);
    }

    public float EquipPhysicalDamage
    {
        get => (MainWeapon.PhysicalDamage);
    }
    public float EquipPhysicalPierce
    {
        get => (MainWeapon.PhysicalPierce);
    }
    public float EquipPhysicalLifeSteal
    {
        get => (MainWeapon.PhysicalLifeSteal);
    }

    public float EquipMagicDamage
    {
        get => (MainWeapon.MagicDamage);
    }
    public float EquipMagicPierce
    {
        get => (MainWeapon.MagicPierce);
    }
    public float EquipMagicLifeSteal
    {
        get => (MainWeapon.MagicLifeSteal);
    }

    public float EquipPhysicalDefense
    {
        get => (Helm.PhysicalDefense + Armor.PhysicalDefense);
    }

    public float EquipMagicDefense
    {
        get => (Helm.MagicDefense + Armor.MagicDefense);
    }

    public float EquipMoveSpeed
    {
        get => (Armor.MoveSpeed);
    }
}