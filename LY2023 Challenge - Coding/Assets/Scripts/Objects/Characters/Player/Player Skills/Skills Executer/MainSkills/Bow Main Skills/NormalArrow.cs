using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Normal Arrow", menuName = "Skills/Active Skills/Main Skills/Normal Arrow")]
public class NormalArrow : BowSkill
{
    public override string Name
    {
        get => "Normal Arrow";
    }

    public override void Update()
    {
    }

    public override IEnumerator Execute(Vector3 mousePos, PlayerMainSkillsManager playerMainSkillsManager)
    {
        playerMainSkillsManager.ResetTimer();

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

        this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowBehaviour>().SetUpCommonArrow(this.ProjectilesPositions[index], mousePos, this.ProjectileLifeTime, this.ProjectileSpeed, ArrowType.NormalArrow, this.AttributesManager.PhysicalDamage, this.AttributesManager.PhysicalPierce);

        yield return new WaitForSeconds(0.05f);
        this.PlayerMovement.IsAttacked = false;
        this.AttributesManager.BonusMoveSpeed += 2f;
        this.PlayerMovement.WoodBow.SetActiveParentAnimation(false);
    }
}