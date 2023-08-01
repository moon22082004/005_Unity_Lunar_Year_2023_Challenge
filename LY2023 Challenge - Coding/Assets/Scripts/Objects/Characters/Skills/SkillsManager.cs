using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    [SerializeField] private List<KeyCode> _skillKeys;
    public List<KeyCode> SkillKeys => _skillKeys;

    [SerializeField] private List<float> _cooldownTimers;
    private List<float> CooldownTimers
    {
        get 
        {
            if (_cooldownTimers.Count > 0)
            {
                _cooldownTimers[0] = GetComponent<AttributesManager>().AttackSpeed;
            }
            if (_cooldownTimers.Count > 1)
            {
                _cooldownTimers[1] = this.MainSkills[1].CooldownTimer;
            }
            if (_cooldownTimers.Count > 2)
            {
                _cooldownTimers[2] = this.MainSkills[2].CooldownTimer;
            }
            if (_cooldownTimers.Count > 3)
            {
                _cooldownTimers[3] = this.MainSkills[3].CooldownTimer;
            }
            if (_cooldownTimers.Count > 4)
            {
                _cooldownTimers[4] = this.SideSkill.CooldownTimer;
            }

            return _cooldownTimers;
        }
    }    
    [SerializeField] private List<float> _timers;
    public void ResetTimer(int skillIndex)
    {
        _timers[0] = 0;
        _timers[skillIndex] = 0;
    }

    [SerializeField] private SideSkill _sideSkill;
    public SideSkill SideSkill
    {
        get => _sideSkill;
        set => _sideSkill = value;
    }

    [SerializeField] private List<MainSkill> _mainSkills;
    public List<MainSkill> MainSkills
    {
        get => _mainSkills;
    }    

    public List<float> SkillCooldownFillAmounts
    {
        get 
        {
            List<float> result = new List<float>();
            for (int i = 0; i < _skillKeys.Count; i++) 
            {
                result.Add(Mathf.Clamp((_cooldownTimers[i] - _timers[i]) / _cooldownTimers[i], 0, 1));
            }

            return result;
        }
    }

    private void Awake()
    {
        for (int i = 0; i < Mathf.Min(_timers.Count, this.CooldownTimers.Count); i++)
        {
            _timers[i] = this.CooldownTimers[i];
        }
    }

    private void Update()
    {
        foreach (MainSkill mainskill in _mainSkills)
        {
            mainskill.Update();
        }

        for (int i = 0; i < _mainSkills.Count; i++)
        {
            if ((_timers[i] >= this.CooldownTimers[i]) && (_timers[0] >= this.CooldownTimers[0]))
            {
                if ((Input.GetKeyDown(_skillKeys[i])) && (!LunarMonoBehaviour.Instance.IsPausedGame))
                {
                    StartCoroutine(_mainSkills[i].Execute(this, i));
                }
            }
            else if (_timers[i] < this.CooldownTimers[i])
            {
                _timers[i] += Time.deltaTime;
            }
        }

        if (_timers[_timers.Count - 1] >= this.CooldownTimers[this.CooldownTimers.Count - 1])
        {
            if ((Input.GetKeyDown(_skillKeys[_skillKeys.Count - 1])) && (!LunarMonoBehaviour.Instance.IsPausedGame))
            {
                StartCoroutine(_sideSkill.Execute(this, _timers.Count - 1));
            }
        }
        else
        {
            _timers[_timers.Count - 1] += Time.deltaTime;
        }
    }
}