using UnityEngine;

public class PlayerFirstMainSkillsManager : PlayerMainSkillsManager
{
    [SerializeField] private KeyCode _firstMainKey = KeyCode.R;
    protected override KeyCode SkillKeyCode
    {
        get => _firstMainKey;
    }

    [SerializeField] private float _firstMainSkillCooldownTimer = 10;
    public override float CooldownTimer
    {
        get => _firstMainSkillCooldownTimer;
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