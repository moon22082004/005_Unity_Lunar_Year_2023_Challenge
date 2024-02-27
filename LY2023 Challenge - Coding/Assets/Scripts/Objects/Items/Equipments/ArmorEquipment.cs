namespace LY2023Challenge
{
    public abstract class ArmorEquipment : Equipment
    {
        public abstract float PhysicalDefense
        {
            get;
        }
        public abstract float MagicDefense
        {
            get;
        }
    }
}