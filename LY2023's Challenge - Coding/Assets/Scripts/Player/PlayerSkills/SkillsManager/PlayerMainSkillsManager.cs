using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMainSkillsManager : PlayerSkillsManager
{
    [SerializeField] private GameObject _attackDistanceCircle;
    private bool _isDisplayAttackDistance = false;

    private Transform _projectilesDownPointPos;
    private Transform _projectilesHorizontalPointPos;
    private Transform _projectilesUpPointPos;
    private Transform _projectilesAlternativePointPos;

    private PlayerNormalSkillsManager _pNormalSkillsManager;

    private WoodBowSkillsExecuter _woodBowSkillsExecuter;
    private ShortSwordSkillsExecuter _shortSwordSkillsExecuter;
    private DeathSyctheSkills _deathSyctheSkills;

    private Vector3 _mousePos;

    public Vector3 MousePos 
    {
        get => _mousePos;
        set => _mousePos = value;
    }

    public WoodBowSkillsExecuter WoodBowSkillsExecuter
    {
        get => _woodBowSkillsExecuter;
    }
    public ShortSwordSkillsExecuter ShortSwordSkillsExecuter
    {
        get => _shortSwordSkillsExecuter;
    }
    public DeathSyctheSkills DeathSyctheSkills
    {
        get => _deathSyctheSkills;
    }

    protected bool IsDisplayAttackDistance
    {
        get => _isDisplayAttackDistance;
        set => _isDisplayAttackDistance = value;
    }

    protected GameObject AttackDistanceCircle
    {
        get => _attackDistanceCircle;
    }

    protected PlayerNormalSkillsManager PlayerNormalSkillsManager
    {
        get => _pNormalSkillsManager;
    }

    protected Vector3[] ProjectilesPositions 
    {    
        get => new Vector3[] { this._projectilesDownPointPos.position, this._projectilesUpPointPos.position, this._projectilesHorizontalPointPos.position, this._projectilesAlternativePointPos.position };
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start() 
    {
        base.Start();

        this._attackDistanceCircle = GameObject.Find("Player/Effects/Attack Distance Circle");

        this._pNormalSkillsManager = GetComponent<PlayerNormalSkillsManager>();

        this._woodBowSkillsExecuter = GetComponent<WoodBowSkillsExecuter>();
        this._shortSwordSkillsExecuter = GetComponent<ShortSwordSkillsExecuter>();
        this._deathSyctheSkills = GetComponent<DeathSyctheSkills>();

        this._projectilesDownPointPos = this.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform;
        this._projectilesHorizontalPointPos = this.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform;
        this._projectilesUpPointPos = this.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform;
        this._projectilesAlternativePointPos = this.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform;
    }

    protected virtual void Update() 
    {
    }

    protected virtual void GetMousePos()
    {
        this.MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 attackVector3 = new Vector3(this.MousePos.x - this._projectilesAlternativePointPos.position.x, this.MousePos.y - this._projectilesAlternativePointPos.position.y, this.MousePos.z - this._projectilesAlternativePointPos.position.z);
        if ( attackVector3.x >= attackVector3.y )
        {
            if ( attackVector3.x + attackVector3.y >= 0 )
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
            if ( attackVector3.x + attackVector3.y <= 0 )
            {
                this.PlayerMovement.SetSideDirection(-1f);
            }
            else
            {
                this.PlayerMovement.SetUpDirection();
            }
        }    
    }

    protected IEnumerator DisplayAttackDistance(float attackDistance)
    {    
        this.AttackDistanceCircle.GetComponent<AttackDistanceCircle>().Distance = attackDistance;
                
        this.AttackDistanceCircle.SetActive(true);

        yield return new WaitForSeconds(1f);

        this.AttackDistanceCircle.SetActive(false);
    }
}