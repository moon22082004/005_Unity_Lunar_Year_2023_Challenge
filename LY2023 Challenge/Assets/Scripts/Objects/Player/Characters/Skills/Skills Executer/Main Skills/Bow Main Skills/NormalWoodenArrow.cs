using System.Collections;
using UnityEngine;

namespace LY2023Challenge
{
    [CreateAssetMenu(fileName = "Normal Wooden Arrow", menuName = "Skills/Active Skills/Main Skills/Normal Wooden Arrow")]
    public class NormalWoodenArrow : BowSkill
    {
        public override string Name
        {
            get => "Normal Wooden Arrow";
        }

        public override float CooldownTimer => PlayerManager.Instance.Player.GetComponent<AttributesManager>().AttackSpeed;

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

                this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowController>().SetUpCommonArrow(this.ProjectilesPositions[index], mousePos, 0, this.ProjectileLifeTime, this.ProjectileSpeed, ArrowType.NormalArrow, this.AttributesManager.PhysicalDamage, this.AttributesManager.PhysicalPierce);

                yield return new WaitForSeconds(0.05f);
                this.PlayerController.IsAttacked = false;
                this.AttributesManager.BonusMoveSpeed += 2f;
            }
        }
    }
}