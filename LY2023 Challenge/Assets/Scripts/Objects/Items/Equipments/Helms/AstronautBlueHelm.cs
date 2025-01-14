using UnityEngine;

namespace LY2023Challenge
{
    [CreateAssetMenu(fileName = "AstronautBlueHelm", menuName = "Items/Equipments/Helms/AstronautBlueHelm")]
    public class AstronautBlueHelm : Helm
    {
        public override string Name
        {
            get => "Astronaut Blue Helm";
        }

        public override int BuyingPrice
        {
            get => 200;
        }
        public override int SellingPrice
        {
            get => 100;
        }

        public override int MaxLevel
        {
            get => 5;
        }

        public override float Weight
        {
            get => 0.6f;
        }

        public override float PhysicalDefense
        {
            get
            {
                float value = 0f;

                // Level 1
                value += 0.25f;
                // Level 2-3
                value += 0.1f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Level 4-5
                value += 0.125f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

                return value;
            }
        }

        public override float MagicDefense
        {
            get
            {
                float value = 0f;

                // Level 1
                value += 3f;
                // Level 2-3
                value += 1f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Level 4-5
                value += 0.5f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

                return value;
            }
        }
    }
}