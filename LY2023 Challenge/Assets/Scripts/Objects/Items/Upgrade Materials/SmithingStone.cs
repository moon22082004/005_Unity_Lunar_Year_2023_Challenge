using UnityEngine;

namespace LY2023Challenge
{
    [CreateAssetMenu(fileName = "SmithingStone", menuName = "Items/Upgrade Materials/Smithing Stone")]
    public class SmithingStone : UpgradeMaterial
    {
        public override string Name
        {
            get => "Smithing Stone";
        }

        public override int BuyingPrice
        {
            get
            {
                int value = 0;
                // Vigor Level 1
                value += 200;
                // Vigor Level 2-3
                value += 300 * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Vigor Level 3-4
                value += 600 * Mathf.Max(0, Mathf.Min(2, this.Level - 2));
                // Vigor Level 5-7
                value += 1000 * Mathf.Max(0, Mathf.Min(3, this.Level - 4));
                // Vigor Level 7-10
                value += 2500 * Mathf.Max(0, Mathf.Min(4, this.Level - 7));

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
                value += 100 * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Vigor Level 3-4
                value += 300 * Mathf.Max(0, Mathf.Min(2, this.Level - 2));
                // Vigor Level 5-7
                value += 700 * Mathf.Max(0, Mathf.Min(3, this.Level - 4));
                // Vigor Level 7-10
                value += 1500 * Mathf.Max(0, Mathf.Min(4, this.Level - 7));

                return value;
            }
        }

        public override int MaxLevel
        {
            get => 10;
        }
    }
}