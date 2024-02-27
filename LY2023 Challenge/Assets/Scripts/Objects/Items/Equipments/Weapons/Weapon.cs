using UnityEngine;

namespace LY2023Challenge
{
    public abstract class Weapon : Equipment
    {
        public abstract WeaponType Type
        {
            get;
        }


        public override Sprite ItemIcon
        {
            get => Resources.Load<Sprite>("Item Icons/Equipments/Weapons/" + this.Name);
        }

        #region Physical Damage
        public virtual float PhysicalDamage
        {
            get;
        }
        public virtual float PhysicalPierce
        {
            get;
        }
        public abstract float PhysicalLifeSteal
        {
            get;
        }
        #endregion

        #region Magic Damage
        public virtual float MagicDamage
        {
            get;
        }
        public virtual float MagicPierce
        {
            get;
        }
        public abstract float MagicLifeSteal
        {
            get;
        }
        #endregion
    }
}