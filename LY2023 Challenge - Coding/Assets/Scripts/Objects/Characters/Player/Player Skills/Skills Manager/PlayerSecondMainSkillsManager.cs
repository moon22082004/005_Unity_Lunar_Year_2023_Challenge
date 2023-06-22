using UnityEngine;

public class PlayerSecondMainSkillsManager : PlayerMainSkillsManager
{
    [SerializeField] private KeyCode _secondMainKey = KeyCode.E;
    protected override KeyCode SkillKeyCode
    {
        get => _secondMainKey;
    }

    [SerializeField] private float _secondMainSkillCooldownTimer = 6;
    public override float CooldownTimer
    {
        get => _secondMainSkillCooldownTimer;
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