using UnityEngine;

public abstract class PlayerSkillsManager : MonoBehaviour
{
    private PlayerMovement _pMovement;
    protected PlayerMovement PlayerMovement
    {
        get
        {
            if (_pMovement == null)
            {
                _pMovement = GetComponent<PlayerMovement>();
            }
            return _pMovement;
        }
    }

    private float _timer;
    public float Timer
    {
        get => _timer;
        set => _timer = value;
    }
    public abstract float CooldownTimer
    {
        get;
    }

    private bool _isUsedSkill;
    public bool IsUsedSkill
    {
        get => _isUsedSkill;
        set => _isUsedSkill = value;
    }

    protected abstract KeyCode SkillKeyCode
    {
        get;
    }
    public abstract string SkillName 
    {
        get;
    }

    protected virtual void Awake() 
    {
        this.IsUsedSkill = false;
        this.Timer = this.CooldownTimer;
    }

    public float SkillCooldownFillAmount()
    {
        return Mathf.Clamp(((this.CooldownTimer - this.Timer) / this.CooldownTimer), 0, 1);
    }
}