using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Skills/Active Skills/Side Skills/Heal")]
public class Heal : SideSkill
{
    public override string Name
    {
        get => "Heal";
    }

    public override float CooldownTimer
    {
        get
        {
            // Level 1
            float value = 40f;
            // Level 2-4
            value -= 2f * Mathf.Max(0, Mathf.Min(3, this.Level - 1));

            return value;
        }
    }

    protected override List<float> Values
    {
        get
        {
            List<float> values = new List<float>();

            // FIRST VALUE: HEALING PROPORTION
            // Level 1
            float value = 0.2f;
            // Level 2-4
            value += 0.1f * Mathf.Max(0, Mathf.Min(3, this.Level - 1));

            values.Add(value);

            return values;
        }
    }

    protected override void SetUpEffect()
    {
        this.PlayerEffect = GameObject.Find("Player/Character/Effects/Side Skills/Heal");
        // _healingEffect = Resources.Load("Prefabs/Player/SkillsEffect/SideSkillsEffect/Heal") as GameObject;
    }

    public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
    {
        skillsManager.ResetTimer(skillIndex);

        this.PlayerEffect.SetActive(true);

        this.AttributesManager.IncreaseHealth(this.Values[0] * this.AttributesManager.MaxHP);
        yield return new WaitForSeconds(1f);

        this.PlayerEffect.SetActive(false);
    }
}