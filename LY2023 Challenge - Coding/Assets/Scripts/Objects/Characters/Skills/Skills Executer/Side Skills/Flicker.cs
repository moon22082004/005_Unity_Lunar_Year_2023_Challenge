using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flicker", menuName = "Skills/Active Skills/Side Skills/Flicker")]
public class Flicker : SideSkill
{
    public override string Name
    {
        get => "Flicker";
    }

    public override float CooldownTimer
    {
        get
        {
            // Level 1
            float value = 60f;
            // Level 2-3
            value -= 2.5f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4
            value -= 5f * Mathf.Max(0, Mathf.Min(1, this.Level - 3));

            return value;
        }
    }

    protected override List<float> Values
    {
        get
        {
            List<float> values = new List<float>();

            // FIRST VALUE: MAX RANGE
            // Level 1
            float value = 4f;
            // Level 2-3
            value += 0.3f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
            // Level 4
            value += 0.4f * Mathf.Max(0, Mathf.Min(1, this.Level - 3));

            values.Add(value);

            return values;
        }
    }

    protected override void SetUpEffect()
    {
        this.PlayerEffect = GameObject.Find("Player/Character/Effects/Side Skills/Dust");
    }

    public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
    {
        Vector3 mousePos = LunarMonoBehaviour.Instance.GetMousePos();
        //Debug.Log(mousePos + " and " + LunarMonoBehaviour.Instance.Player.transform.position);

        if (((Vector2)(mousePos - LunarMonoBehaviour.Instance.Player.transform.position)).magnitude > this.Values[0])
        {
            this.AttackDistanceCircle.GetComponent<AttackDistanceCircle>().Distance = this.Values[0];

            this.AttackDistanceCircle.SetActive(true);

            yield return new WaitForSeconds(1f);

            this.AttackDistanceCircle.SetActive(false);
        }
        else
        {
            skillsManager.ResetTimer(skillIndex);

            yield return new WaitForSeconds(0.15f);

            this.PlayerEffect.SetActive(true);

            LunarMonoBehaviour.Instance.Player.transform.position = mousePos;
            yield return new WaitForSeconds(0.35f);

            this.PlayerEffect.SetActive(false);
        }
    }
}