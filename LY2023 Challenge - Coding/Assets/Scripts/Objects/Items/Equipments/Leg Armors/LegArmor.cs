using UnityEngine;

public abstract class LegArmor : ArmorEquipment
{
    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Equipments/Leg Armors/" + this.Name);
    }

    public abstract float MoveSpeed
    {
        get;
    }
}