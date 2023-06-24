using UnityEngine;

[CreateAssetMenu(fileName = "SomberStone", menuName = "Items/Upgrade Materials/Somber Stone")]
public class SomberStone : UpgradeMaterial
{
    public override string Name
    {
        get => "Somber Stone";
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Upgrade Materials/somberstone" + this.Level.ToString());
    }

    public override int MaxLevel
    {
        get => 5;
    }    
}