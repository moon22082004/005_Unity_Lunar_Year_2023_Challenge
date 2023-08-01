using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Five Arrows", menuName = "Skills/Active Skills/Main Skills/Five Arrows")]
public class FiveArrows : BowSkill
{
    public override string Name
    {
        get => "Five Arrows";
    }

    public override float CooldownTimer
    {
        get
        {
            // Level 1
            float value = 10f;
            // Level 2-4
            value -= 1f * Mathf.Max(0, Mathf.Min(3, this.Level - 1));

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
        if (this.Arrows.Count > 4)
        {
            Vector3 mousePos = LunarMonoBehaviour.Instance.GetMousePos();

            skillsManager.ResetTimer(skillIndex);

            this.PlayerMovement.IsAttacked = true;
            this.AttributesManager.BonusMoveSpeed -= 2f;
            this.PlayerMovement.WoodBow.SetActiveParentAnimation(true);

            yield return new WaitForSeconds(0.25f);

            int index = 0;
            if ((this.PlayerMovement.Direction == "Down") && (mousePos.y < this.ProjectilesPositions[0].y))
            {
                index = 0;
            }
            else if ((this.PlayerMovement.Direction == "Up") && (mousePos.y > this.ProjectilesPositions[1].y))
            {
                index = 1;
            }
            else if (((this.PlayerMovement.Direction == "Left") && (mousePos.x < this.ProjectilesPositions[2].x)) ||
                     ((this.PlayerMovement.Direction == "Right") && (mousePos.x > this.ProjectilesPositions[2].x)))
            {
                index = 2;
            }

            this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowBehaviour>().SetUpCommonArrow(this.ProjectilesPositions[index], mousePos, 20, this.ProjectileLifeTime, this.ProjectileSpeed, ArrowType.NormalArrow, this.AttributesManager.PhysicalDamage * 0.6f, this.AttributesManager.PhysicalPierce);
            this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowBehaviour>().SetUpCommonArrow(this.ProjectilesPositions[index], mousePos, 10, this.ProjectileLifeTime, this.ProjectileSpeed, ArrowType.NormalArrow, this.AttributesManager.PhysicalDamage * 0.6f, this.AttributesManager.PhysicalPierce);
            this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowBehaviour>().SetUpCommonArrow(this.ProjectilesPositions[index], mousePos, 0, this.ProjectileLifeTime, this.ProjectileSpeed, ArrowType.NormalArrow, this.AttributesManager.PhysicalDamage * 0.6f, this.AttributesManager.PhysicalPierce);
            this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowBehaviour>().SetUpCommonArrow(this.ProjectilesPositions[index], mousePos, -10, this.ProjectileLifeTime, this.ProjectileSpeed, ArrowType.NormalArrow, this.AttributesManager.PhysicalDamage * 0.6f, this.AttributesManager.PhysicalPierce);
            this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowBehaviour>().SetUpCommonArrow(this.ProjectilesPositions[index], mousePos, -20, this.ProjectileLifeTime, this.ProjectileSpeed, ArrowType.NormalArrow, this.AttributesManager.PhysicalDamage * 0.6f, this.AttributesManager.PhysicalPierce);

            yield return new WaitForSeconds(0.05f);
            this.PlayerMovement.IsAttacked = false;
            this.AttributesManager.BonusMoveSpeed += 2f;
            this.PlayerMovement.WoodBow.SetActiveParentAnimation(false);
        }
    }
}