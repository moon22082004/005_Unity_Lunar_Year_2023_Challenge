using UnityEngine;

[CreateAssetMenu(fileName = "DefaultChestArmor", menuName = "Items/Equipments/Chest Armors/Default Chest Armor")]
public class DefaultChestArmor : ChestArmor
{
    public override string Name
    {
        get => "Default Chest Armor";
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/default");
    }

    public override float Weight
    {
        get => 0f;
    }

    public override float PhysicalDefense
    {
        get
        {
            float value = 0f;

            return value;
        }
    }

    public override float MagicDefense
    {
        get
        {
            float value = 0f;

            return value;
        }
    }
}