using UnityEngine;

namespace LY2023Challenge
{
    [CreateAssetMenu(fileName = "SomberStone", menuName = "Items/Upgrade Materials/Somber Stone")]
    public class SomberStone : UpgradeMaterial
    {
        public override string Name
        {
            get => "Somber Stone";
        }

        public override int BuyingPrice
        {
            get
            {
                int value = 0;
                // Vigor Level 1
                value += 200;
                // Vigor Level 2-3
                value += 500 * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Vigor Level 3-4
                value += 900 * Mathf.Max(0, Mathf.Min(2, this.Level - 2));
                // Vigor Level 5-7
                value += 1500 * Mathf.Max(0, Mathf.Min(3, this.Level - 4));
                // Vigor Level 7-10
                value += 4500 * Mathf.Max(0, Mathf.Min(4, this.Level - 7));

                return value;
            }
        }
        public override int SellingPrice
        {
            get
            {
                int value = 0;
                // Vigor Level 1
                value += 100;
                // Vigor Level 2-3
                value += 200 * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Vigor Level 3-4
                value += 400 * Mathf.Max(0, Mathf.Min(2, this.Level - 2));
                // Vigor Level 5-7
                value += 800 * Mathf.Max(0, Mathf.Min(3, this.Level - 4));
                // Vigor Level 7-10
                value += 2500 * Mathf.Max(0, Mathf.Min(4, this.Level - 7));

                return value;
            }
        }

        public override int MaxLevel
        {
            get => 10;
        }
    }
}