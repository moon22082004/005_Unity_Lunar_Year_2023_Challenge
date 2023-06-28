using UnityEngine;

[CreateAssetMenu(fileName = "ClothTrousers", menuName = "Items/Equipments/Leg Armors/Cloth Trousers")]
public class ClothTrousers : LegArmor
{
    public override string Name
    {
        get => "Cloth Trousers";
    }

    public override int MaxLevel
    {
        get => 5;
    }   

    public override float Weight
    {
        get => 1.5f;
    }

    public override float MoveSpeed
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 0.25f;
            // Level 2-3
            value += 0.15f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 0.1f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }

    public override float PhysicalDefense
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 5f;
            // Level 2-3
            value += 1.5f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 0.75f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }

    public override float MagicDefense
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 0.35f;
            // Level 2-3
            value += 0.175f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 0.15f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }
}