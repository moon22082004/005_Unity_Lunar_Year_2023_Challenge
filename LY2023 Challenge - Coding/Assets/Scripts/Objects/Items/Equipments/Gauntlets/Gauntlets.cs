using UnityEngine;

public abstract class Gauntlets : ArmorEquipment
{
    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Equipments/Gauntlets/" + this.Name);
    }

    public abstract float PhysicalLifeSteal
    {
        get;
    }

    public abstract float MagicLifeSteal
    {
        get;
    }
}