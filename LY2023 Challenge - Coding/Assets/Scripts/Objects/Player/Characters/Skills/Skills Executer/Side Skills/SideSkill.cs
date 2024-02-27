using System.Collections;
using UnityEngine;

namespace LY2023Challenge
{
    public abstract class SideSkill : Skill
    {
        public override Sprite SkillIcon
        {
            get => Resources.Load<Sprite>("Skill Icons/Side Skills/" + this.Name);
        }

        [SerializeField] private GameObject _playerEffect;
        protected GameObject PlayerEffect
        {
            get
            {
                if (_playerEffect == null)
                {
                    this.SetUpEffect();
                }

                return _playerEffect;
            }
            set => _playerEffect = value;
        }


        public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
        {
            throw new System.NotImplementedException();
        }

        protected abstract void SetUpEffect();
    }
}