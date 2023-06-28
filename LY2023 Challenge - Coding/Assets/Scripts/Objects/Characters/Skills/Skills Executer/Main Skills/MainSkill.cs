using System.Collections;
using UnityEngine;

public abstract class MainSkill : Skill
{
    private PlayerMovement _playerMovement;
    protected PlayerMovement PlayerMovement
    {
        get
        {
            if (_playerMovement == null)
            {
                _playerMovement = GameObject.Find("Player/Character").GetComponent<PlayerMovement>();
            }

            return _playerMovement;
        }
        set => _playerMovement = value;
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

    public abstract void Update();

    public override IEnumerator Execute()
    {
        throw new System.NotImplementedException();
    }
    public virtual IEnumerator Execute(Vector3 mousePos, SkillsManager skillsManager, int skillIndex)
    {
        throw new System.NotImplementedException();
    }
}