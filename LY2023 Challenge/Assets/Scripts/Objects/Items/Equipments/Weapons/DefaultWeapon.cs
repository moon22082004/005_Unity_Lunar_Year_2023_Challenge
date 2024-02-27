using UnityEngine;

namespace LY2023Challenge
{
    [CreateAssetMenu(fileName = "DefaultWeapon", menuName = "Items/Equipments/Weapons/Default Weapon")]
    public class DefaultWeapon : Weapon
    {
        public override string Name
        {
            get => "DefaultWeapon";
        }

        public override int BuyingPrice
        {
            get => 0;
        }
        public override int SellingPrice
        {
            get => 0;
        }

        public override Sprite ItemIcon
        {
            get => Resources.Load<Sprite>("Item Icons/default");
        }

        public override WeaponType Type
        {
            get => WeaponType.None;
        }

        public override float Weight
        {
            get => 0f;
        }

        public override float PhysicalDamage
        {
            get => 0f;
        }
        public override float PhysicalPierce
        {
            get => 0f;
        }
        public override float PhysicalLifeSteal
        {
            get
            {
                float value = 0f;

                return value;
            }
        }

        public override float MagicDamage
        {
            get => 0f;
        }
        public override float MagicPierce
        {
            get => 0f;
        }
        public override float MagicLifeSteal
        {
            get
            {
                float value = 0f;

                return value;
            }
        }
    }
}