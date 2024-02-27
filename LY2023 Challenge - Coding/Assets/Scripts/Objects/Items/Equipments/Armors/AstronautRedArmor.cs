using UnityEngine;

namespace LY2023Challenge
{
    [CreateAssetMenu(fileName = "AstronautRedArmor", menuName = "Items/Equipments/Armors/AstronautRedArmor")]
    public class AstronautRedArmor : Armor
    {
        public override string Name
        {
            get => "Astronaut Red Armor";
        }

        public override int BuyingPrice
        {
            get => 350;
        }
        public override int SellingPrice
        {
            get => 200;
        }

        public override int MaxLevel
        {
            get => 5;
        }

        public override float Weight
        {
            get => 5.8f;
        }

        public override float PhysicalDefense
        {
            get
            {
                float value = 0f;

                // Level 1
                value += 8f;
                // Level 2-3
                value += 3f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Level 4-5
                value += 2f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

                return value;
            }
        }

        public override float MagicDefense
        {
            get
            {
                float value = 0f;

                // Level 1
                value += 0.7f;
                // Level 2-3
                value += 0.25f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Level 4-5
                value += 0.175f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

                return value;
            }
        }

        public override float MoveSpeed
        {
            get
            {
                float value = 0f;

                // Level 1
                value += 0.3f;
                // Level 2-3
                value += 0.15f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Level 4-5
                value += 0.125f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

                return value;
            }
        }
    }
}