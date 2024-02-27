using System.Collections.Generic;
using UnityEngine;

namespace LY2023Challenge
{
    public abstract class BowSkill : MainSkill
    {
        [SerializeField] private List<GameObject> _arrows;
        protected List<GameObject> Arrows
        {
            get
            {
                _arrows = new List<GameObject>();

                GameObject arrows = GameObject.Find("Player/Arrows");
                for (int i = 0; i < arrows.transform.childCount; i++)
                {
                    _arrows.Add(arrows.transform.GetChild(i).gameObject);
                }

                return _arrows;
            }
        }

        protected int InactiveArrowIndex
        {
            get
            {
                for (int i = 0; i < this.Arrows.Count; i++)
                {
                    if (!this.Arrows[i].activeInHierarchy)
                    {
                        return i;
                    }
                }
                return 0;
            }
        }

        private Transform _projectilesDownPointTransform;
        private Transform _projectilesHorizontalPointTransform;
        private Transform _projectilesUpPointTransform;
        private Transform _projectilesAlternativePointTransform;
        protected Vector3[] ProjectilesPositions
        {
            get
            {
                if (_projectilesDownPointTransform == null)
                {
                    _projectilesDownPointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Down Point").transform;
                }
                if (_projectilesHorizontalPointTransform == null)
                {
                    _projectilesHorizontalPointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Horizontal Point").transform;
                }
                if (_projectilesUpPointTransform == null)
                {
                    _projectilesUpPointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Up Point").transform;
                }
                if (_projectilesAlternativePointTransform == null)
                {
                    _projectilesAlternativePointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Alternative Point").transform;
                }

                return new Vector3[] { _projectilesDownPointTransform.position, _projectilesUpPointTransform.position, _projectilesHorizontalPointTransform.position, _projectilesAlternativePointTransform.position };
            }
        }

        [SerializeField] private float _projectileLifeTime = 1f;
        [SerializeField] private float _projectileSpeed = 20f;

        protected float ProjectileLifeTime
        {
            get => _projectileLifeTime;
        }
        protected float ProjectileSpeed
        {
            get => _projectileSpeed;
        }
    }
}