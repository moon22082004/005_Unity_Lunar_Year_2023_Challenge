using UnityEngine;

public abstract class Weapon : Equipment
{
    public abstract WeaponType Type
    {
        get;
    }


    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Equipments/Weapons/" + this.Name);
    }

    #region Physical Damage
    public virtual float PhysicalDamage
    {
        get;
    }
    public virtual float PhysicalPierce
    {
        get;
    }
    #endregion

    #region Magic Damage
    public virtual float MagicDamage
    {
        get;
    }
    public virtual float MagicPierce
    {
        get;
    }
    #endregion
}