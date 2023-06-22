using UnityEngine;

public class PlayerNormalSkillsManager : PlayerMainSkillsManager
{
    [SerializeField] private KeyCode _normalAttackKey = KeyCode.Mouse0;
    protected override KeyCode SkillKeyCode
    {
        get => _normalAttackKey;
    }

    public override float CooldownTimer 
    {
        get => GetComponent<AttributesManager>().AttackSpeed;
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