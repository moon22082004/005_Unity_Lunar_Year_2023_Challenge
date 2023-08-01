using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecoverMana", menuName = "Skills/Active Skills/Side Skills/Recover Mana")]
public class RecoverMana : SideSkill
{
    public override string Name
    {
        get => "Recover Mana";
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

            // FIRST VALUE: MANA RECOVERING PROPORTION
            // Level 1
            float value = 0.15f;
            // Level 2-3
            value += 0.1f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4
            value += 0.15f * Mathf.Max(0, Mathf.Min(1, this.Level - 3));

            values.Add(value);

            return values;
        }
    }

    protected override void SetUpEffect()
    {
        this.PlayerEffect = GameObject.Find("Player/Character/Effects/Side Skills/Recovering Mana");
    }

    public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
    {
        skillsManager.ResetTimer(skillIndex);

        this.PlayerEffect.SetActive(true);

        this.AttributesManager.ChangeFP(this.Values[0] * this.AttributesManager.MaxFP);
        yield return new WaitForSeconds(1f);

        this.PlayerEffect.SetActive(false);
    }
}