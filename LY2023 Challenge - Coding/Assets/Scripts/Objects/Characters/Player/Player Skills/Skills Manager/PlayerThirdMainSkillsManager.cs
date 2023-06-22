using UnityEngine;

public class PlayerThirdMainSkillsManager : PlayerMainSkillsManager
{
    [SerializeField] private KeyCode _thirdMainKey = KeyCode.Space;
    protected override KeyCode SkillKeyCode
    {
        get => _thirdMainKey;
    }

    [SerializeField] private float _thirdMainSkillCooldownTimer;
    public override float CooldownTimer
    {
        get => _thirdMainSkillCooldownTimer;
    }

    protected override void Awake() 
    {
        base.Awake();
    }

    protected override void Update() 
    {
        base.Update();
    }
}