using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Shackles Arrow", menuName = "Skills/Active Skills/Main Skills/Shackles Arrow")]
public class ShacklesArrow : BowSkill
{
    public override string Name
    {
        get => "Shackles Arrow";
    }

    public override float CooldownTimer
    {
        get
        {
            // Level 1
            float value = 25f;
            // Level 2-4
            value -= 1.5f * Mathf.Max(0, Mathf.Min(3, this.Level - 1));

            return value;
        }
    }

    [SerializeField] private GameObject _effectCircle;
    private GameObject EffectCircle
    {
        get
        {
            if (_effectCircle == null)
            {
                _effectCircle = GameObject.Find("Player/Other Effects/Shackles Circle");
            }

            return _effectCircle;
        }
    }

    public override void Update()
    {
    }

    public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
    {
        if (this.Arrows.Count > 0)
        {
            Vector3 mousePos = LunarMonoBehaviour.Instance.GetMousePos();

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

            this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowBehaviour>().SetUpShacklesArrow(this, this.ProjectilesPositions[index], mousePos, this.ProjectileLifeTime, this.ProjectileSpeed, this.AttributesManager.PhysicalDamage * 2.5f, this.AttributesManager.PhysicalPierce);

            yield return new WaitForSeconds(0.05f);
            this.PlayerController.IsAttacked = false;
            this.AttributesManager.BonusMoveSpeed += 2f;
        }
    }

    public void SetUpShacklesEffect(Vector3 position)
    {
        LunarMonoBehaviour.Instance.StartCoroutine(this.ShacklesEffect(position));
    }

    public IEnumerator ShacklesEffect(Vector3 position)
    {
        this.EffectCircle.SetActive(true);
        this.EffectCircle.transform.position = position;

        foreach (GameObject lockedEnemy in EnemiesManager.Instance.GetEnemiesInCircle(position, 1.8f))
        {
            lockedEnemy.GetComponent<EffectsManager>().LockMovement(2.5f, LockMovementType.Stun);
        }

        yield return new WaitForSeconds(2.5f);

        this.EffectCircle.SetActive(false);
    }
}