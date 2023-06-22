using UnityEngine;

[CreateAssetMenu(fileName = "DefaultLegArmor", menuName = "Items/Equipments/Leg Armors/Default Leg Armor")]
public class DefaultLegArmor : LegArmor
{
    public override string Name
    {
        get => "Default Leg Armor";
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/default");
    }

    public override float Weight
    {
        get => 0f;
    }

    public override float MoveSpeed
    {
        get
        {
            float value = 0f;

            return value;
        }
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