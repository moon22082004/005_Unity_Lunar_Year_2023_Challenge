using UnityEngine;

public abstract class Armor : ArmorEquipment
{
    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Equipments/Armors/" + this.Name);
    }

    public abstract float MoveSpeed
    {
        get;
    }
}