using UnityEngine;

public abstract class Helm : ArmorEquipment
{

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Equipments/Helms/" + this.Name);
    }
}
