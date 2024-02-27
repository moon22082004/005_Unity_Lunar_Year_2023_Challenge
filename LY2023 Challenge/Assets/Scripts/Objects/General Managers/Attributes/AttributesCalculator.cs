using UnityEngine;

namespace LY2023Challenge
{
    public static class AttributesCalculator
    {
        public static float BaseMaxHP(float vigorLevel)
        {
            float value = 0;
            // Vigor Level 1
            value += 500f;
            // Vigor Level 2-5
            value += 5f * Mathf.Max(0, Mathf.Min(4, vigorLevel - 1));
            // Vigor Level 6-10
            value += 7f * Mathf.Max(0, Mathf.Min(5, vigorLevel - 5));
            // Vigor Level 11-15
            value += 10f * Mathf.Max(0, Mathf.Min(5, vigorLevel - 10));
            // Vigor Level 16-20
            value += 15f * Mathf.Max(0, Mathf.Min(5, vigorLevel - 15));
            // Vigor Level 21-25
            value += 20f * Mathf.Max(0, Mathf.Min(5, vigorLevel - 20));
            // Vigor Level 26-30
            value += 28f * Mathf.Max(0, Mathf.Min(5, vigorLevel - 25));
            // Vigor Level 31-35
            value += 36f * Mathf.Max(0, Mathf.Min(5, vigorLevel - 30));
            // Vigor Level 36-40
            value += 45f * Mathf.Max(0, Mathf.Min(5, vigorLevel - 35));
            // Vigor Level 41-50
            value += 28f * Mathf.Max(0, Mathf.Min(10, vigorLevel - 40));
            // Vigor Level 51-60
            value += 20f * Mathf.Max(0, Mathf.Min(10, vigorLevel - 50));
            // Vigor Level 61-70
            value += 14f * Mathf.Max(0, Mathf.Min(10, vigorLevel - 60));
            // Vigor Level 71-80
            value += 10f * Mathf.Max(0, Mathf.Min(10, vigorLevel - 70));
            // Vigor Level 81-90
            value += 6f * Mathf.Max(0, Mathf.Min(10, vigorLevel - 80));
            // Vigor Level 91-99
            value += 3f * Mathf.Max(0, Mathf.Min(9, vigorLevel - 90));

            return value;
        }
        public static float BaseMaxFP(float mindLevel)
        {
            float value = 0;
            // Mind Level 1
            value += 150f;
            // Mind Level 2-12
            value += 3f * Mathf.Max(0, Mathf.Min(11, mindLevel - 1));
            // Mind Level 13-15
            value += 4f * Mathf.Max(0, Mathf.Min(3, mindLevel - 12));
            // Mind Level 16-30
            value += 5f * Mathf.Max(0, Mathf.Min(15, mindLevel - 15));
            // Mind Level 31-35
            value += 6f * Mathf.Max(0, Mathf.Min(5, mindLevel - 30));
            // Mind Level 36-45
            value += 7f * Mathf.Max(0, Mathf.Min(10, mindLevel - 35));
            // Mind Level 46-55
            value += 6f * Mathf.Max(0, Mathf.Min(10, mindLevel - 45));
            // Mind Level 56-60
            value += 4f * Mathf.Max(0, Mathf.Min(5, mindLevel - 55));
            // Mind Level 61-87
            value += 2f * Mathf.Max(0, Mathf.Min(27, mindLevel - 60));
            // Mind Level 88-89
            value += 3f * Mathf.Max(0, Mathf.Min(2, mindLevel - 87));
            // Mind Level 90-99
            value += 4f * Mathf.Max(0, Mathf.Min(10, mindLevel - 89));

            return value;
        }
        public static float BaseMaxEquipLoad(float enduranceLevel)
        {
            float value = 0f;

            // Endurance Level 1
            value += 20f;
            // Endurance Level 2-10
            value += 1f * Mathf.Max(0, Mathf.Min(9, enduranceLevel - 1));
            // Endurance Level 11-20
            value += 1.5f * Mathf.Max(0, Mathf.Min(10, enduranceLevel - 10));
            // Endurance Level 21-25
            value += 1.6f * Mathf.Max(0, Mathf.Min(5, enduranceLevel - 20));
            // Endurance Level 26-40
            value += 1.25f * Mathf.Max(0, Mathf.Min(15, enduranceLevel - 25));
            // Endurance Level 41-60
            value += 1.5f * Mathf.Max(0, Mathf.Min(20, enduranceLevel - 40));
            // Endurance Level 61-85
            value += 1f * Mathf.Max(0, Mathf.Min(25, enduranceLevel - 60));
            // Endurance Level 86-99
            value += 1.1f * Mathf.Max(0, Mathf.Min(14, enduranceLevel - 85));

            return value;
        }
        public static float BasePhysicalDefense(float enduranceLevel, float strengthLevel)
        {
            float value = 0;

            // Endurance Level 1
            value += 7.5f;
            // Endurance Level 2-10
            value += 1.5f * Mathf.Max(0, Mathf.Min(9, enduranceLevel - 1));
            // Endurance Level 11-20
            value += 2f * Mathf.Max(0, Mathf.Min(10, enduranceLevel - 10));
            // Endurance Level 21-30
            value += 2.5f * Mathf.Max(0, Mathf.Min(10, enduranceLevel - 20));
            // Endurance Level 31-50
            value += 1.75f * Mathf.Max(0, Mathf.Min(20, enduranceLevel - 30));
            // Endurance Level 51-75
            value += 1f * Mathf.Max(0, Mathf.Min(25, enduranceLevel - 50));
            // Endurance Level 76-99
            value += 0.75f * Mathf.Max(0, Mathf.Min(24, enduranceLevel - 75));

            // Strength Level 1-10
            value += 0.5f * Mathf.Max(0, Mathf.Min(10, strengthLevel));
            // Strength Level 11-25
            value += 1f * Mathf.Max(0, Mathf.Min(15, strengthLevel - 10));
            // Strength Level 26-35
            value += 1.5f * Mathf.Max(0, Mathf.Min(10, strengthLevel - 25));
            // Strength Level 36-40
            value += 2f * Mathf.Max(0, Mathf.Min(5, strengthLevel - 35));
            // Strength Level 41-60
            value += 1.25f * Mathf.Max(0, Mathf.Min(20, strengthLevel - 40));
            // Strength Level 61-99
            value += 1f * Mathf.Max(0, Mathf.Min(39, strengthLevel - 60));

            return value;
        }
        public static float BaseMagicDefense(float enduranceLevel, float intelligenceLevel)
        {
            float value = 0;
            // Endurance Level 1
            value += 5f;
            // Endurance Level 2-10
            value += 1f * Mathf.Max(0, Mathf.Min(9, enduranceLevel - 1));
            // Endurance Level 11-30
            value += 1.75f * Mathf.Max(0, Mathf.Min(20, enduranceLevel - 10));
            // Endurance Level 31-55
            value += 2f * Mathf.Max(0, Mathf.Min(25, enduranceLevel - 30));
            // Endurance Level 56-75
            value += 1.5f * Mathf.Max(0, Mathf.Min(20, enduranceLevel - 55));
            // Endurance Level 76-99
            value += 1.25f * Mathf.Max(0, Mathf.Min(24, enduranceLevel - 75));

            // Intelligence Level 1-10
            value += 0.5f * Mathf.Max(0, Mathf.Min(10, intelligenceLevel));
            // Intelligence Level 11-35
            value += 1f * Mathf.Max(0, Mathf.Min(25, intelligenceLevel - 10));
            // Intelligence Level 36-45
            value += 2.5f * Mathf.Max(0, Mathf.Min(10, intelligenceLevel - 35));
            // Intelligence Level 46-60
            value += 2f * Mathf.Max(0, Mathf.Min(15, intelligenceLevel - 45));
            // Intelligence Level 61-92
            value += 1.25f * Mathf.Max(0, Mathf.Min(32, intelligenceLevel - 60));
            // Intelligence Level 93-99
            value += 1f * Mathf.Max(0, Mathf.Min(7, intelligenceLevel - 92));

            return value;
        }

        public static float BaseMoveSpeed(float equipMoveSpeed, float bonusMoveSpeed, float equipLoadRate)
        {
            float value = 5f;

            // MoveSpeed from equipments (Leg Armor)
            value += equipMoveSpeed;

            // Other Bonus MoveSpeed
            value = Mathf.Max(0.001f, value + bonusMoveSpeed);

            // Final MoveSpeed after equip load considering
            if (equipLoadRate > 0.5f)
            {
                value -= Mathf.Min(value / 5f, value * equipLoadRate / 5f);
            }

            return value;
        }
        public static float BaseAttackSpeed(float arcaneLevel)
        {
            float value = 0;

            // Arcane Level 1
            value += 1f;
            // Arcane Level 2-10
            value -= 0.01f * Mathf.Max(0, Mathf.Min(9, arcaneLevel - 1));
            // Arcane Level 11-25
            value -= 0.005f * Mathf.Max(0, Mathf.Min(15, arcaneLevel - 10));
            // Arcane Level 26-55
            value -= 0.0025f * Mathf.Max(0, Mathf.Min(30, arcaneLevel - 25));
            // Arcane Level 56-65
            value -= 0.0015f * Mathf.Max(0, Mathf.Min(10, arcaneLevel - 55));
            // Arcane Level 66-99
            value -= 0.001f * Mathf.Max(0, Mathf.Min(34, arcaneLevel - 65));

            return value;
        }
        public static float BasePhysicalDamage(float strengthLevel)
        {
            float value = 0;

            // Strength Level 1
            value += 10f;
            // Strength Level 2-15
            value += 4f * Mathf.Max(0, Mathf.Min(14, strengthLevel - 1));
            // Strength Level 16-29
            value += 5f * Mathf.Max(0, Mathf.Min(14, strengthLevel - 15));
            // Strength Level 30-43
            value += 6f * Mathf.Max(0, Mathf.Min(14, strengthLevel - 29));
            // Strength Level 44-57
            value += 5f * Mathf.Max(0, Mathf.Min(14, strengthLevel - 43));
            // Strength Level 58-71
            value += 4f * Mathf.Max(0, Mathf.Min(14, strengthLevel - 57));
            // Strength Level 72-85
            value += 3f * Mathf.Max(0, Mathf.Min(14, strengthLevel - 71));
            // Strength Level 86-99
            value += 2f * Mathf.Max(0, Mathf.Min(14, strengthLevel - 85));

            return value;
        }
        public static float BasePhysicalPierce(float dexterityLevel)
        {
            float value = 0;
            // Dexterity Level 1
            value += 2f;
            // Dexterity Level 2-10
            value += 1f * Mathf.Max(0, Mathf.Min(9, dexterityLevel - 1));
            // Dexterity Level 11-30
            value += 1.5f * Mathf.Max(0, Mathf.Min(20, dexterityLevel - 10));
            // Dexterity Level 31-40
            value += 2f * Mathf.Max(0, Mathf.Min(10, dexterityLevel - 30));
            // Dexterity Level 41-60
            value += 1.5f * Mathf.Max(0, Mathf.Min(20, dexterityLevel - 40));
            // Dexterity Level 61-99
            value += 1f * Mathf.Max(0, Mathf.Min(39, dexterityLevel - 60));

            return value;
        }
        public static float BasePhysicalLifeSteal(float arcaneLevel, float dexterityLevel)
        {
            float value = 0;

            // Arcane + Dexterity Level 2
            value += 0.005f;
            // Arcane + Dexterity Level 3-20
            value += 0.0025f * Mathf.Max(0, Mathf.Min(18, arcaneLevel + dexterityLevel - 2));
            // Arcane + Dexterity Level 21-40
            value += 0.0015f * Mathf.Max(0, Mathf.Min(20, arcaneLevel + dexterityLevel - 20));
            // Arcane + Dexterity Level 41-70
            value += 0.001f * Mathf.Max(0, Mathf.Min(30, arcaneLevel + dexterityLevel - 40));
            // Arcane + Dexterity Level 71-110
            value += 0.00125f * Mathf.Max(0, Mathf.Min(40, arcaneLevel + dexterityLevel - 70));
            // Arcane + Dexterity Level 111-120
            value += 0.001f * Mathf.Max(0, Mathf.Min(10, arcaneLevel + dexterityLevel - 110));
            // Arcane + Dexterity Level 121-160
            value += 0.00075f * Mathf.Max(0, Mathf.Min(40, arcaneLevel + dexterityLevel - 120));
            // Arcane + Dexterity Level 161-198
            value += 0.0005f * Mathf.Max(0, Mathf.Min(38, arcaneLevel + dexterityLevel - 160));

            return value;
        }
        public static float BaseMagicDamage(float intelligenceLevel)
        {
            float value = 0;

            // Strength Level 1
            value += 10;
            // Strength Level 2-15
            value += 4.5f * Mathf.Max(0, Mathf.Min(14, intelligenceLevel - 1));
            // Strength Level 16-29
            value += 5f * Mathf.Max(0, Mathf.Min(14, intelligenceLevel - 15));
            // Strength Level 30-43
            value += 6.5f * Mathf.Max(0, Mathf.Min(14, intelligenceLevel - 29));
            // Strength Level 44-57
            value += 5f * Mathf.Max(0, Mathf.Min(14, intelligenceLevel - 43));
            // Strength Level 58-71
            value += 4f * Mathf.Max(0, Mathf.Min(14, intelligenceLevel - 57));
            // Strength Level 72-85
            value += 2.5f * Mathf.Max(0, Mathf.Min(14, intelligenceLevel - 71));
            // Strength Level 86-99
            value += 2f * Mathf.Max(0, Mathf.Min(14, intelligenceLevel - 85));

            return value;
        }
        public static float BaseMagicPierce(float faithLevel)
        {
            float value = 0;

            // Faith Level 1
            value += 1f;
            // Faith Level 2-5
            value += 1f * Mathf.Max(0, Mathf.Min(4, faithLevel - 1));
            // Faith Level 6-25
            value += 1.75f * Mathf.Max(0, Mathf.Min(20, faithLevel - 5));
            // Faith Level 26-40
            value += 2f * Mathf.Max(0, Mathf.Min(15, faithLevel - 25));
            // Faith Level 41-60
            value += 1.25f * Mathf.Max(0, Mathf.Min(30, faithLevel - 40));
            // Faith Level 71-78
            value += 0.75f * Mathf.Max(0, Mathf.Min(8, faithLevel - 70));
            // Faith Level 79-99
            value += 0.5f * Mathf.Max(0, Mathf.Min(21, faithLevel - 78));

            return value;
        }
        public static float BaseMagicLifeSteal(float arcaneLevel, float faithLevel)
        {
            float value = 0;

            // Arcane + Dexterity Level 2
            value += 0.005f;
            // Arcane + Dexterity Level 3-30
            value += 0.0025f * Mathf.Max(0, Mathf.Min(28, arcaneLevel + faithLevel - 2));
            // Arcane + Dexterity Level 31-50
            value += 0.0015f * Mathf.Max(0, Mathf.Min(20, arcaneLevel + faithLevel - 30));
            // Arcane + Dexterity Level 51-70
            value += 0.001f * Mathf.Max(0, Mathf.Min(20, arcaneLevel + faithLevel - 50));
            // Arcane + Dexterity Level 71-120
            value += 0.00125f * Mathf.Max(0, Mathf.Min(50, arcaneLevel + faithLevel - 70));
            // Arcane + Dexterity Level 121-160
            value += 0.00075f * Mathf.Max(0, Mathf.Min(40, arcaneLevel + faithLevel - 120));
            // Arcane + Dexterity Level 161-198
            value += 0.00025f * Mathf.Max(0, Mathf.Min(38, arcaneLevel + faithLevel - 160));

            return value;
        }
    }
}