using UnityEngine;

namespace LY2023Challenge
{
    public abstract class Helm : ArmorEquipment
    {

        public override Sprite ItemIcon
        {
            get => Resources.Load<Sprite>("Item Icons/Equipments/Helms/" + this.Name);
        }
    }
}