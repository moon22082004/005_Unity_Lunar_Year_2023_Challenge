using UnityEngine;

[CreateAssetMenu(fileName = "SmithingStone", menuName = "Items/Upgrade Materials/Smithing Stone")]
public class SmithingStone : UpgradeMaterial
{
    public override string Name
    {
        get => "Smithing Stone";
    }

    public override int MaxLevel
    {
        get => 5;
    }
}