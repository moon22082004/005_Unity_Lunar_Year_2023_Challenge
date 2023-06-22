using UnityEngine;

public abstract class PlayerMainSkillsManager : PlayerSkillsManager
{
    private Vector3 _mousePos;
    public Vector3 MousePos 
    {
        get => _mousePos;
    }

    [SerializeField] private MainSkill _mainSkill;
    public MainSkill MainSkill
    {
        get => _mainSkill; 
        set => _mainSkill = value;
    }
    public override string SkillName
    {
        get => this.MainSkill.Name;
    }

    private bool _isDisplayAttackDistance = false;
    protected bool IsDisplayAttackDistance
    {
        get => _isDisplayAttackDistance;
        set => _isDisplayAttackDistance = value;
    }

    private PlayerNormalSkillsManager _pNormalSkillsManager;
    private PlayerNormalSkillsManager PlayerNormalSkillsManager
    {
        get
        {
            if (_pNormalSkillsManager == null)
            {
                _pNormalSkillsManager = GetComponent<PlayerNormalSkillsManager>();
            }

            return _pNormalSkillsManager;
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

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Update() 
    {
        this.MainSkill.Update();

        if ((this.Timer >= this.CooldownTimer) && (this.PlayerNormalSkillsManager.Timer >= this.PlayerNormalSkillsManager.CooldownTimer))
        {
            if (Input.GetKeyDown(this.SkillKeyCode))
            {
                this.GetMousePos();

                StartCoroutine(this.MainSkill.Execute(this.MousePos, this));
            }
        }
        else if (this.Timer < this.CooldownTimer)
        {
            this.Timer += Time.deltaTime;
        }
    }

    public void ResetTimer()
    {
        this.Timer = 0;
        this.PlayerNormalSkillsManager.Timer = 0;
    }

    protected virtual void GetMousePos()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 attackVector3 = new Vector3(this.MousePos.x - this.ProjectilesPositions[3].x, this.MousePos.y - this.ProjectilesPositions[3].y, this.MousePos.z - this.ProjectilesPositions[3].z);
        if (attackVector3.x >= attackVector3.y)
        {
            if (attackVector3.x + attackVector3.y >= 0)
            {
                this.PlayerMovement.SetSideDirection(0.75f);
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
}