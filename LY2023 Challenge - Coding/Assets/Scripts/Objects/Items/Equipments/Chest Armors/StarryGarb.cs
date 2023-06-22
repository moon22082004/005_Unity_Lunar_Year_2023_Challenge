using UnityEngine;

[CreateAssetMenu(fileName = "StarryGarb", menuName = "Items/Equipments/Chest Armors/Starry Garb")]
public class StarryGarb : ChestArmor
{
    public override string Name
    {
        get => "Starry Garb";
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Equipments/Chest Armors/starrygarb");
    }

    public override float Weight
    {
        get => 5.8f;
    }

    public override float PhysicalDefense
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 0.7f;
            // Level 2-3
            value += 0.25f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 0.175f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }

    public override float MagicDefense
    {
        get
        {
            float value = 0f;

            // Level 1
            value += 8f;
            // Level 2-3
            value += 3f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            value += 2f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            return value;
        }
    }
}