using UnityEngine;

[CreateAssetMenu(fileName = "ClothBracer", menuName = "Items/Equipments/Gauntlets/Cloth Bracer")]
public class ClothBracer : Gauntlets
{
    public override string Name
    {
        get => "Cloth Bracer";
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/clothbracer");
    }

    public override float Weight
    {
        get => 0.25f;
    }

    public override float PhysicalLifeSteal
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 0.01f;
            // Level 2-3
            value += 0.004f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 0.001f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }

    public override float MagicLifeSteal
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 0.001f;
            // Level 2-3
            value += 0.0004f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 0.00035f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }

    public override float PhysicalDefense
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 0.5f;
            // Level 2-3
            value += 0.2f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 0.05f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }

    public override float MagicDefense
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 0.1f;
            // Level 2-3
            value += 0.05f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 0.02f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }
}