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
    [SerializeField] private ChestArmor _chestArmor;
    [SerializeField] private Gauntlets _gauntlets;
    [SerializeField] private LegArmor _legArmor;

    public Helm Helm
    {
        get => _helm; 
        set => _helm = value;
    }
    public ChestArmor ChestArmor
    {
        get => _chestArmor;
        set => _chestArmor = value;
    }
    public Gauntlets Gauntlets
    {
        get => _gauntlets;
        set => _gauntlets = value;
    }
    public LegArmor LegArmor
    {
        get => _legArmor; 
        set => _legArmor = value;
    }

    public float EquipLoad
    {
        get => (MainWeapon.Weight + SideWeapon.Weight + Helm.Weight + ChestArmor.Weight + Gauntlets.Weight + LegArmor.Weight);
    }

    public float EquippedPhysicalDamage
    {
        get => (MainWeapon.PhysicalDamage);
    }
    public float EquippedPhysicalPierce
    {
        get => (MainWeapon.PhysicalPierce);
    }
    public float EquippedPhysicalLifeSteal
    {
        get => (Gauntlets.PhysicalLifeSteal);
    }

    public float EquippedMagicDamage
    {
        get => (MainWeapon.MagicDamage);
    }
    public float EquippedMagicPierce
    {
        get => (MainWeapon.MagicPierce);
    }
    public float EquippedMagicLifeSteal
    {
        get => (Gauntlets.MagicLifeSteal);
    }

    public float EquippedPhysicalDefense
    {
        get => (Helm.PhysicalDefense + ChestArmor.PhysicalDefense + Gauntlets.PhysicalDefense + LegArmor.PhysicalDefense);
    }

    public float EquippedMagicDefense
    {
        get => (Helm.MagicDefense + ChestArmor.MagicDefense + Gauntlets.MagicDefense + LegArmor.MagicDefense);
    }

    public float EquippedMoveSpeed
    {
        get => (LegArmor.MoveSpeed);
    }
}