using UnityEngine;

[CreateAssetMenu(fileName = "StarryShoes", menuName = "Items/Equipments/Leg Armors/Starry Shoes")]
public class StarryShoes : LegArmor
{
    public override string Name
    {
        get => "Starry Shoes";
    }

    public override int MaxLevel
    {
        get => 5;
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Equipments/Leg Armors/starryshoes");
    }

    public override float Weight
    {
        get => 1.75f;
    }

    public override float MoveSpeed
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 0.3f;
            // Level 2-3
            value += 0.15f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 0.125f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }

    public override float PhysicalDefense
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

    public override float MagicDefense
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
}