using UnityEngine;

namespace LY2023Challenge
{
    [CreateAssetMenu(fileName = "Styrax", menuName = "Items/Upgrade Materials/Styrax")]
    public class Styrax : UpgradeMaterial
    {
        public override string Name
        {
            get => "Styrax";
        }

        public override int BuyingPrice
        {
            get
            {
                int value = 0;
                value += this.Level * 100;

                return value;
            }
        }
        public override int SellingPrice
        {
            get
            {
                int value = 0;
                value += this.Level * 50;

                return value;
            }
        }

        public override int MaxLevel
        {
            get => 5;
        }
    }
}