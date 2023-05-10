using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkillsManager : MonoBehaviour
{
    private float _timer;
    private bool _isUsedSkill;
    private string _skillName;
    private float _cooldownTimer;
    private KeyCode _skillKeyCode;
    private PlayerMovement _pMovement;

    public float Timer
    {
        get => _timer;
        set => _timer = value;
    }

    public bool IsUsedSkill
    {
        get => _isUsedSkill;
        set => _isUsedSkill = value;
    }
    
    public string SkillName 
    {
        get => _skillName;
        set => _skillName = value;
    }

    public float CooldownTimer
    {
        get => _cooldownTimer;
        set => _cooldownTimer = value;
    }

    protected KeyCode SkillKeyCode
    {
        get => _skillKeyCode;
        set => _skillKeyCode = value;
    }

    protected PlayerMovement PlayerMovement
    {
        get => _pMovement;
        set => _pMovement = value;
    }

    protected virtual void Awake() 
    {
        this.IsUsedSkill = false;
    }

    protected virtual void Start() 
    {
        this.PlayerMovement = GetComponent<PlayerMovement>();
    }

    public float SkillCooldownFillAmount()
    {
        return Mathf.Clamp(((this.CooldownTimer - this.Timer) / this.CooldownTimer), 0, 1);
    }
}