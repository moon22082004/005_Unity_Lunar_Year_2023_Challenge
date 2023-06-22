using UnityEngine;

[CreateAssetMenu(fileName = "DefaultGauntlets", menuName = "Items/Equipments/Gauntlets/Default Gauntlets")]
public class DefaultGauntlets : Gauntlets
{
    public override string Name
    {
        get => "Default Gauntlets";
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/default");
    }

    public override float Weight
    {
        get => 0f;
    }

    public override float PhysicalLifeSteal
    {
        get
        {
            float value = 0f;

            return value;
        }
    }

    public override float MagicLifeSteal
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