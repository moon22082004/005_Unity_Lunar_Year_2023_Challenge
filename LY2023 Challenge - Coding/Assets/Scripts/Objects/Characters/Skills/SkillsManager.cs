using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    private PlayerMovement _pMovement;
    private PlayerMovement PlayerMovement
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

    private Vector3 _mousePos;
    protected virtual void GetMousePos()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 attackVector3 = new Vector3(_mousePos.x - this.ProjectilesPositions[3].x, _mousePos.y - this.ProjectilesPositions[3].y, _mousePos.z - this.ProjectilesPositions[3].z);
        if (attackVector3.x >= attackVector3.y)
        {
            if (attackVector3.x + attackVector3.y >= 0)
            {
                this.PlayerMovement.SetSideDirection(1f);
            }
            else
            {
                this.PlayerMovement.SetDownDirection();
            }
        }
        else
        {
            if (attackVector3.x + attackVector3.y <= 0)
            {
                this.PlayerMovement.SetSideDirection(-1f);
            }
            else
            {
                this.PlayerMovement.SetUpDirection();
            }
        }
    }

    [SerializeField] private List<KeyCode> _skillKeys;

    [SerializeField] private List<float> _cooldownTimers;
    [SerializeField] private List<float> _timers;
    public void ResetTimer(int skillIndex)
    {
        _timers[0] = 0;
        _timers[skillIndex] = 0;
    }

    [SerializeField] private SideSkill _sideSkill;
    public string SideSkillName
    {
        get => _sideSkill.Name;
    }    

    [SerializeField] private List<MainSkill> _mainSkills;
    public List<string> MainSkillNames
    {
        get
        {
            List<string> result = new List<string>();
            for (int i = 0; i < _mainSkills.Count; i++)
            {
                result.Add(_mainSkills[i].Name);
            }

            return result;
        }
    }    

    private Transform _projectilesDownPointTransform;
    private Transform _projectilesHorizontalPointTransform;
    private Transform _projectilesUpPointTransform;
    private Transform _projectilesAlternativePointTransform;
    protected Vector3[] ProjectilesPositions
    {
        get
        {
            if (_projectilesDownPointTransform == null)
            {
                _projectilesDownPointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Down Point").transform;
            }
            if (_projectilesHorizontalPointTransform == null)
            {
                _projectilesHorizontalPointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Horizontal Point").transform;
            }
            if (_projectilesUpPointTransform == null)
            {
                _projectilesUpPointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Up Point").transform;
            }
            if (_projectilesAlternativePointTransform == null)
            {
                _projectilesAlternativePointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Alternative Point").transform;
            }

            return new Vector3[] { _projectilesDownPointTransform.position, _projectilesUpPointTransform.position, _projectilesHorizontalPointTransform.position, _projectilesAlternativePointTransform.position };
        }
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
        if (_cooldownTimers.Count > 0)
        {
            _cooldownTimers[0] = GetComponent<AttributesManager>().AttackSpeed;
        }

        for (int i = 0; i < Mathf.Min(_timers.Count, _cooldownTimers.Count); i++)
        {
            _timers[i] = _cooldownTimers[i];
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
            if ((_timers[i] >= _cooldownTimers[i]) && (_timers[0] >= _cooldownTimers[0]))
            {
                if (Input.GetKeyDown(_skillKeys[i]))
                {
                    this.GetMousePos();

                    StartCoroutine(_mainSkills[i].Execute(_mousePos, this, i));
                }
            }
            else if (_timers[i] < _cooldownTimers[i])
            {
                _timers[i] += Time.deltaTime;
            }
        }

        if (_timers[_timers.Count - 1] >= _cooldownTimers[_cooldownTimers.Count - 1])
        {
            if (Input.GetKeyDown(_skillKeys[_skillKeys.Count - 1]))
            {
                StartCoroutine(_sideSkill.Execute());
                _timers[_timers.Count - 1] = 0;
            }
        }
        else
        {
            _timers[_timers.Count - 1] += Time.deltaTime;
        }
    }
}