using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LY2023Challenge
{
    [CreateAssetMenu(fileName = "Run", menuName = "Skills/Active Skills/Side Skills/Run")]
    public class Run : SideSkill
    {
        private PlayerController _playerController;
        private PlayerController PlayerController
        {
            get
            {
                if (_playerController == null)
                {
                    _playerController = GameObject.Find("Player/Character").GetComponent<PlayerController>();
                }

                return _playerController;
            }
        }

        public override string Name
        {
            get => "Run";
        }

        public override float CooldownTimer
        {
            get
            {
                // Level 1
                float value = 35f;
                // Level 2-3
                value -= 1.5f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
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

                // FIRST VALUE: BONUS MOVE SPEED
                // Level 1
                float value = 3f;
                // Level 2-3
                value += 0.75f * Mathf.Max(0, Mathf.Min(2, this.Level - 1));
                // Level 4
                value += 0.5f * Mathf.Max(0, Mathf.Min(1, this.Level - 3));

                values.Add(value);

                return values;
            }
        }

        protected override void SetUpEffect()
        {
            this.PlayerEffect = GameObject.Find("Player/Character/Effects/Side Skills/Run");
        }

        public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
        {
            skillsManager.ResetTimer(skillIndex);

            this.PlayerEffect.SetActive(true);

            this.PlayerController.IsRun = true;

            float bonusValue = this.Values[0];

            this.AttributesManager.BonusMoveSpeed += bonusValue;
            yield return new WaitForSeconds(8f);
            this.AttributesManager.BonusMoveSpeed -= bonusValue;

            this.PlayerController.IsRun = false;

            this.PlayerEffect.SetActive(false);
        }
    }
}