using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LY2023Challenge
{
    [CreateAssetMenu(fileName = "Breakthrough Arrow", menuName = "Skills/Active Skills/Main Skills/Breakthrough Arrow")]
    public class BreakthroughArrow : BowSkill
    {
        public override string Name
        {
            get => "Breakthrough Arrow";
        }

        public override float CooldownTimer
        {
            get
            {
                // Level 1
                float value = 10f;
                // Level 2-4
                value -= 1.5f * Mathf.Max(0, Mathf.Min(3, this.Level - 1));

                return value;
            }
        }

        protected override List<float> Values
        {
            get
            {
                List<float> values = new List<float>();

                // FIRST VALUE: ARROW DAMAGE RATE
                // Level 1
                float firstValue = 1f;
                // Level 2-3
                firstValue += 0.15f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Level 4-5
                firstValue += 0.1f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

                values.Add(firstValue);

                // SECOND VALUE: KNOCK BACK POWER
                float secondValue = 2.5f;
                // Level 2-5
                secondValue += 0.25f * Mathf.Max(0, Mathf.Min(4, this.Level - 1));

                values.Add(secondValue);

                return values;
            }
        }

        public override void Update()
        {
        }

        public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
        {
            if (this.Arrows.Count > 0)
            {
                Vector3 mousePos = PlayerManager.Instance.GetMousePos();

                skillsManager.ResetTimer(skillIndex);

                this.PlayerController.IsAttacked = true;
                this.AttributesManager.BonusMoveSpeed -= 2f;

                yield return new WaitForSeconds(0.25f);

                int index = 0;
                if ((this.PlayerController.Direction == "Down") && (mousePos.y < this.ProjectilesPositions[0].y))
                {
                    index = 0;
                }
                else if ((this.PlayerController.Direction == "Up") && (mousePos.y > this.ProjectilesPositions[1].y))
                {
                    index = 1;
                }
                else if (((this.PlayerController.Direction == "Left") && (mousePos.x < this.ProjectilesPositions[2].x)) ||
                         ((this.PlayerController.Direction == "Right") && (mousePos.x > this.ProjectilesPositions[2].x)))
                {
                    index = 2;
                }

                this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowController>().SetUpBreakthroughArrow(this.Values[1], this.ProjectilesPositions[index], mousePos, this.ProjectileLifeTime, this.ProjectileSpeed, this.AttributesManager.PhysicalDamage * this.Values[0], this.AttributesManager.PhysicalPierce);

                yield return new WaitForSeconds(0.05f);
                this.PlayerController.IsAttacked = false;
                this.AttributesManager.BonusMoveSpeed += 2f;
            }
        }
    }
}