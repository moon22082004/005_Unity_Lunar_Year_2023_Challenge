using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSwordSkillsExecuter { }/* : WeaponSkillsExecuter
{
    
    [Header ("Attack Ranges")]
    [SerializeField] private PolygonCollider2D _swordRangeDown;
    [SerializeField] private PolygonCollider2D _swordRangeHorizontal;
    [SerializeField] private PolygonCollider2D _swordRangeUp;

    private Vector2 _attackDirection;
    private Vector3 _rSkillPos;

    [SerializeField] private GameObject _rCircle;
    private float _eDamage;
    [SerializeField] private GameObject _spaceEffect;

    public Vector3 RSkillPos
    {
        get => this._rSkillPos;
        set => this._rSkillPos = value;
    }

    protected override void Start() 
    {
        base.Start();

        GameObject swordRanges = GameObject.Find("Player/Weapons/ShortSwordWeapon");

        _swordRangeDown = swordRanges.transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>();
        _swordRangeHorizontal = swordRanges.transform.GetChild(1).gameObject.GetComponent<PolygonCollider2D>();
        _swordRangeUp = swordRanges.transform.GetChild(2).gameObject.GetComponent<PolygonCollider2D>();

        GameObject shortSwordEffects = GameObject.Find("Player/Character/Effects/ShortSword");
        _rCircle = shortSwordEffects.transform.GetChild(0).gameObject;
        _spaceEffect = shortSwordEffects.transform.GetChild(1).gameObject;
    }

    private void FixedUpdate() 
    {
        if ( this.PlayerSecondMainSkillsManager.IsUsedSkill )
        {
            this.transform.position += new Vector3(this._attackDirection.x, this._attackDirection.y, 0);
        }
        if ( this.PlayerThirdMainSkillsManager.IsUsedSkill )
        {
            this._spaceEffect.transform.position = this.transform.position + new Vector3(0, 1.15f, 0);
        }
    }

    public void SkillDisplay() 
    {
        if ( this.PlayerFirstMainSkillsManager.IsUsedSkill )
        {
            this._rCircle.SetActive(true);
            this._rCircle.transform.position = this._rSkillPos;
        }
        else
        {
            this._rCircle.SetActive(false);
        }
    }

    public IEnumerator ShortSwordAttack(float damage)
    {
        this.PlayerNormalSkillsManager.Timer = 0;

        this.PlayerMovement.IsAttacked = true;
        //this.PlayerMovement.MoveSpeed /= 5;
        this.PlayerMovement.ShortSword.SetActiveParentAnimation(true);

        yield return new WaitForSeconds(0.3f);

        switch ( this.PlayerMovement.Direction )
        {
            case "Down":
            {
                this._swordRangeDown.enabled = true;
                this._swordRangeDown.GetComponent<MeleeWeaponsTriggerDamage>().Damage = damage;
                break;
            }
            case "Up":
            {
                this._swordRangeUp.enabled = true;
                this._swordRangeUp.GetComponent<MeleeWeaponsTriggerDamage>().Damage = damage;
                break;
            }
            default:
            {
                this._swordRangeHorizontal.enabled = true;
                this._swordRangeHorizontal.GetComponent<MeleeWeaponsTriggerDamage>().Damage = damage;
                break;
            }
        }
        yield return new WaitForSeconds(0.25f);

        this._swordRangeDown.enabled = false;
        this._swordRangeUp.enabled = false;
        this._swordRangeHorizontal.enabled = false;
        
        this.PlayerMovement.IsAttacked = false;
        //this.PlayerMovement.MoveSpeed *= 5;
        this.PlayerMovement.ShortSword.SetActiveParentAnimation(false);
    }

    public IEnumerator RShortSword(float damage)
    {
        this.PlayerFirstMainSkillsManager.Timer = 0;
        this.transform.position = this._rSkillPos;

        this.PlayerFirstMainSkillsManager.IsUsedSkill = true;
        yield return new WaitForSeconds(0.15f);
            
        StartCoroutine(this.ShortSwordAttack(damage));

        yield return new WaitForSeconds(1.85f);
        this.PlayerFirstMainSkillsManager.IsUsedSkill = false;
    }

    public IEnumerator EShortSword(float damage, Vector3 mousePos)
    {
        this.PlayerSecondMainSkillsManager.Timer = 0;

        this.PlayerMovement.IsAttacked = true;
        this.PlayerMovement.CanMoveNormally = false;
        //this.PlayerMovement.MoveSpeed /= 20;
        this.PlayerMovement.ShortSword.SetActiveParentAnimation(true);

        this._eDamage = damage;

        this._attackDirection = new Vector2(mousePos.x - this.transform.position.x, mousePos.y - this.transform.position.y);
        //this._attackDirection = new Vector2(this._attackDirection.x / this._attackDirection.magnitude * this.PlayerMovement.MoveSpeed, this._attackDirection.y / this._attackDirection.magnitude * this.PlayerMovement.MoveSpeed);

        this.PlayerSecondMainSkillsManager.IsUsedSkill = true;

        yield return new WaitForSeconds(0.55f);

        this.PlayerSecondMainSkillsManager.IsUsedSkill = false;

        this.PlayerMovement.IsAttacked = false;
        this.PlayerMovement.CanMoveNormally = true;
        //this.PlayerMovement.MoveSpeed *= 20;
        this.PlayerMovement.ShortSword.SetActiveParentAnimation(false);
    }

    public IEnumerator SpaceShortSword()
    {
        this.PlayerThirdMainSkillsManager.Timer = 0;
        this.PlayerThirdMainSkillsManager.IsUsedSkill = true;

        this._spaceEffect.SetActive(true);

        //this.PlayerMovement.MoveSpeed *= 1.5f;
        //this.PlayerNormalSkillsManager.PhysicalDamage *= 1.5f;
        
        yield return new WaitForSeconds(10f);

        //this.PlayerMovement.MoveSpeed /= 1.5f;
        //this.PlayerNormalSkillsManager.PhysicalDamage /= 1.5f;

        this._spaceEffect.SetActive(false);

        this.PlayerThirdMainSkillsManager.IsUsedSkill = false;      
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if ( (collision.gameObject.tag == "Enemy") && (this.PlayerSecondMainSkillsManager.IsUsedSkill) )
        {
            collision.gameObject.GetComponent<AttributesManager>().IncreaseHealth(-this._eDamage);   
        } 
    }
    
}*/