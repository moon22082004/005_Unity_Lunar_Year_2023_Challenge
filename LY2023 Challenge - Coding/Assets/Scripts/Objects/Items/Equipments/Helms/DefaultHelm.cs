using UnityEngine;

[CreateAssetMenu(fileName = "DefaultHelm", menuName = "Items/Equipments/Helms/Default Helm")]
public class DefaultHelm : Helm
{
    public override string Name
    {
        get => "Default Helm";
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