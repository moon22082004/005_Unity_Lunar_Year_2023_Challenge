using UnityEngine;

public abstract class ChestArmor : ArmorEquipment
{
    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Equipments/Chest Armors/" + this.Name);
    }
}