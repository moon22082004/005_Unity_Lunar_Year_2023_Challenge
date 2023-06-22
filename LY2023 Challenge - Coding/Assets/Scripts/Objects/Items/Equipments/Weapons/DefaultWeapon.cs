using UnityEngine;

[CreateAssetMenu(fileName = "DefaultWeapon", menuName = "Items/Equipments/Weapons/Default Weapon")]
public class DefaultWeapon : Weapon
{
    public override string Name
    {
        get => "DefaultWeapon";
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/default");
    }

    public override WeaponType Type
    {
        get => WeaponType.None;
    }

    public override float Weight
    {
        get => 0f;
    }

    public override float PhysicalDamage
    {
        get => 0f;
    }
    public override float PhysicalPierce
    {
        get => 0f;
    }
}