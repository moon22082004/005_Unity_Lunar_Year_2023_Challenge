using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LY2023Challenge
{
    public abstract class Skill : ScriptableObject
    {
        public abstract string Name
        {
            get;
        }

        public abstract Sprite SkillIcon
        {
            get;
        }

        private int _level;
        public int Level
        {
            get => _level;
            set => _level = value;
        }

        public abstract float CooldownTimer
        {
            get;
        }

        protected virtual List<float> Values
        {
            get;
        }

        [SerializeField] private GameObject _attackDistanceCircle;
        protected GameObject AttackDistanceCircle
        {
            get
            {
                if (_attackDistanceCircle == null)
                {
                    _attackDistanceCircle = GameObject.Find("Player/Character/Effects/Attack Distance Circle");
                }

                return _attackDistanceCircle;
            }
        }

        private AttributesManager _attributesManager;
        protected AttributesManager AttributesManager
        {
            get
            {
                if (_attributesManager == null)
                {
                    _attributesManager = GameObject.Find("Player/Character").GetComponent<AttributesManager>();
                }

                return _attributesManager;
            }
        }

        public abstract IEnumerator Execute(SkillsManager skillsManager, int skillIndex);
    }
}