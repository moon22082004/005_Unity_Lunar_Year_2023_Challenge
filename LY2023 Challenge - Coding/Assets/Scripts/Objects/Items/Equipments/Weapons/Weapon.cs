public abstract class Weapon : Equipment
{
    public abstract WeaponType Type
    {
        get;
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