using System.Collections;
using UnityEngine;

public abstract class MainSkill : Skill
{
    public override Sprite SkillIcon
    {
        get => Resources.Load<Sprite>("Skill Icons/Main Skills/" + this.Name);
    }

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

    public abstract void Update();

    public override IEnumerator Execute(SkillsManager skillsManager, int skillIndex)
    {
        throw new System.NotImplementedException();
    }
}