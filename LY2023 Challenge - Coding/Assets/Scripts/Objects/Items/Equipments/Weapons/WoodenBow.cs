using UnityEngine;

[CreateAssetMenu(fileName = "WoodenBow", menuName = "Items/Equipments/Weapons/Wooden Bow")]
public class WoodenBow : Weapon
{
    public override string Name
    {
        get => "Wooden Bow";
    }

    public override int MaxLevel
    {
        get => 12;
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Equipments/Weapons/woodenbow");
    }

    public override WeaponType Type 
    {
        get => WeaponType.Bow; 
    }

    public override float Weight
    {
        get => 5f;
    }

    public override float PhysicalDamage
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 20f;
            // Level 2-4
            value += 3f * Mathf.Max(0, Mathf.Min(3, this.Level - 1));
            // Level 5-7
            value += 4f * Mathf.Max(0, Mathf.Min(3, this.Level - 4));
            // Level 8-10
            value += 5f * Mathf.Max(0, Mathf.Min(3, this.Level - 7));
            // Level 11-12
            value += 6f * Mathf.Max(0, Mathf.Min(3, this.Level - 10));

            return value;
        }
    }
    public override float PhysicalPierce
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 3f;
            // Level 2-4
            value += 0.5f * Mathf.Max(0, Mathf.Min(3, this.Level - 1));
            // Level 5-7
            value += 0.75f * Mathf.Max(0, Mathf.Min(3, this.Level - 4));
            // Level 8-10
            value += 1f * Mathf.Max(0, Mathf.Min(3, this.Level - 7));
            // Level 11-12
            value += 1.5f * Mathf.Max(0, Mathf.Min(3, this.Level - 10));

            return value;
        }
    }
}