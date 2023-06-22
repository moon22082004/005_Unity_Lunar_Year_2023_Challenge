using UnityEngine;

public class PlayerSideSkillsManager : PlayerSkillsManager
{
    [SerializeField] private KeyCode _sideKey = KeyCode.Q;
    protected override KeyCode SkillKeyCode
    {
        get => _sideKey;
    }

    [SerializeField] private SideSkill _sideSkill;
    public override string SkillName
    {
        get => _sideSkill.Name;
    }

    [SerializeField] private float _sideSkillCooldownTimer;
    public override float CooldownTimer
    {
        get => _sideSkillCooldownTimer;
    }

    protected override void Awake() 
    {
        base.Awake();
    }

    private void Update()
    {
        if (this.Timer >= this.CooldownTimer)
        {
            if (Input.GetKeyDown(this.SkillKeyCode))
            {
                StartCoroutine(_sideSkill.Execute());
                this.Timer = 0;
            }
        }
        else
        {
            this.Timer += Time.deltaTime;
        }
    }
}