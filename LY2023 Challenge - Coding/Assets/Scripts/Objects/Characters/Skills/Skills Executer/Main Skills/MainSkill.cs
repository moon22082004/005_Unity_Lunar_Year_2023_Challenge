using System.Collections;
using UnityEngine;

public abstract class MainSkill : Skill
{
    public override Sprite SkillIcon
    {
        get => Resources.Load<Sprite>("Skill Icons/Main Skills/" + this.Name);
    }

    private PlayerController _playerController;
    protected PlayerController PlayerController
    {
        get
        {
            if (_playerController == null)
            {
                _playerController = GameObject.Find("Player/Character").GetComponent<PlayerController>();
            }

            return _playerController;
        }
        set => _playerController = value;
    }

    public abstract void Update();

    public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
    {
        throw new System.NotImplementedException();
    }
}