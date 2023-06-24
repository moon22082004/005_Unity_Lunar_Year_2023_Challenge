using UnityEngine;

[CreateAssetMenu(fileName = "Styrax", menuName = "Items/Upgrade Materials/Styrax")]
public class Styrax : UpgradeMaterial
{
    public override string Name
    {
        get => "Styrax";
    }

    public override Sprite ItemIcon
    {
        get => Resources.Load<Sprite>("Item Icons/Upgrade Materials/styrax" + this.Level.ToString());
    }

    public override int MaxLevel
    {
        get => 5;
    }
}