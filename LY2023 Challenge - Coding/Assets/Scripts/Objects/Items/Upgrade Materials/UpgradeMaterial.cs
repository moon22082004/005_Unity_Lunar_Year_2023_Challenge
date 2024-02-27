using UnityEngine;

namespace LY2023Challenge
{
    public abstract class UpgradeMaterial : Item
    {
        public override Sprite ItemIcon
        {
            get => Resources.Load<Sprite>("Item Icons/Upgrade Materials/" + this.ShortDescription);
        }
    }
}