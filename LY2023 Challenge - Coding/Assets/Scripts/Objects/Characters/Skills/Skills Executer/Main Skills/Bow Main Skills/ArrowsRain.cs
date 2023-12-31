using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Arrows Rain", menuName = "Skills/Active Skills/Main Skills/Arrows Rain")]
public class ArrowsRain : BowSkill
{
    public override string Name
    {
        get => "Arrows Rain";
    }

    public override float CooldownTimer
    {
        get
        {
            // Level 1
            float value = 12f;
            // Level 2-3
            value -= 1f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4
            value -= 2f * Mathf.Max(0, Mathf.Min(1, this.Level - 3));

            return value;
        }
    }

    protected override List<float> Values
    {
        get
        {
            List<float> values = new List<float>();

            // FIRST VALUE: EACH ARROW DAMAGE RATE
            // Level 1
            float firstValue = 0.45f;
            // Level 2-3
            firstValue += 0.1f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4-5
            firstValue += 0.075f * Mathf.Max(0, Mathf.Min(2, this.Level - 3));

            values.Add(firstValue);

            // SECOND VALUE: SPAWNING ARROWS TIME
            float secondValue = 2f;
            // Level 2-5
            secondValue += 0.25f * Mathf.Max(0, Mathf.Min(4, this.Level - 1));

            values.Add(secondValue);

            return values;
        }
    }

    private Vector3 _rSkillAreaPos;
    private bool _isSpawnedRainedArrows = false;

    private GameObject _effectCircle;
    private GameObject EffectCircle
    {
        get
        {
            if (_effectCircle == null)
            {
                _effectCircle = GameObject.Find("Player/Other Effects/Arrows Rain Circle");
            }

            return _effectCircle;
        }
    }

    public override void Update()
    {
        if (this.EffectCircle.activeInHierarchy)
        {   
            if ((_isSpawnedRainedArrows) && (this.Arrows.Count > 0))
            {     
                if (((Random.Range(0, 1000) <= 100) && (this.NumsOfRainedArchers() <= 2)) ||
                    ((Random.Range(0, 1000) <= 16) && (this.NumsOfRainedArchers() <= 4) && (this.NumsOfRainedArchers() > 2)) ||
                    ((Random.Range(0, 1000) <= 8) && (this.NumsOfRainedArchers() <= 6) && (this.NumsOfRainedArchers() > 4)) ||
                    ((Random.Range(0, 1000) <= 4) && (this.NumsOfRainedArchers() <= 8) && (this.NumsOfRainedArchers() > 6)))
                {
                    this.Arrows[this.InactiveArrowIndex].GetComponent<ArrowBehaviour>().SetUpRainedArrow(_rSkillAreaPos, 1f, this.AttributesManager.PhysicalDamage * this.Values[0], this.AttributesManager.PhysicalPierce);
                }
            }
        }
    }

    public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
    {
        Vector3 mousePos = LunarMonoBehaviour.Instance.GetMousePos();

        if (((Vector2)(mousePos - LunarMonoBehaviour.Instance.Player.transform.position)).magnitude > (this.ProjectileLifeTime * this.ProjectileSpeed))
        {
            this.AttackDistanceCircle.GetComponent<AttackDistanceCircle>().Distance = this.ProjectileLifeTime * this.ProjectileSpeed;

            this.AttackDistanceCircle.SetActive(true);

            yield return new WaitForSeconds(1f);

            this.AttackDistanceCircle.SetActive(false);
        }
        else
        {
            skillsManager.ResetTimer(skillIndex);

            _rSkillAreaPos = mousePos;

            this.EffectCircle.SetActive(true);
            this.EffectCircle.transform.position = _rSkillAreaPos;

            this.PlayerController.IsAttacked = true;

            this.AttributesManager.BonusMoveSpeed -= 2f;

            yield return new WaitForSeconds(0.3f);

            this.AttributesManager.BonusMoveSpeed += 2f;

            this.PlayerController.IsAttacked = false;

            _isSpawnedRainedArrows = true;
            yield return new WaitForSeconds(this.Values[1]);
            _isSpawnedRainedArrows = false;

            yield return new WaitForSeconds(0.7f);

            this.EffectCircle.SetActive(false);
        }
    }

    private int NumsOfRainedArchers()
    {
        int _sum = 0;
        for (int i = 0; i < this.Arrows.Count; i++)
        {
            if ((this.Arrows[i].activeInHierarchy) && (this.Arrows[i].GetComponent<ArrowBehaviour>().TypeOfArcher == ArrowType.RainedArrow))
            {
                _sum += 1;
            }
        }
        return _sum;
    }
}