using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSkillsExecuter : MonoBehaviour
{
    /*
    private PlayerMovement _playerMovement;

    private PlayerNormalSkillsManager _pNormalSkillsManager;
    private PlayerFirstMainSkillsManager _pFirstMainSkillsManager;
    private PlayerSecondMainSkillsManager _pSecondMainSkillsManager;
    private PlayerThirdMainSkillsManager _pThirdMainSkillsManager;

    protected PlayerMovement PlayerMovement
    {
        get => _playerMovement;
    }

    protected PlayerNormalSkillsManager PlayerNormalSkillsManager
    {
        get => _pNormalSkillsManager;
    }
    protected PlayerFirstMainSkillsManager PlayerFirstMainSkillsManager
    {
        get => _pFirstMainSkillsManager;
    }
    protected PlayerSecondMainSkillsManager PlayerSecondMainSkillsManager
    {
        get => _pSecondMainSkillsManager;
    }
    protected PlayerThirdMainSkillsManager PlayerThirdMainSkillsManager
    {
        get => _pThirdMainSkillsManager;
    }

    [SerializeField] private float _physicalDamage;
    [SerializeField] private float _armorPierce;
    [SerializeField] private float _criticalChange;
    [SerializeField] private float _physicalLifeSteal;
    [SerializeField] private float _magicDamage;
    [SerializeField] private float _magicPierce;
    [SerializeField] private float _magicLifeSteal;

    public float PhysicalDamage
    {
        get => this._physicalDamage;
    }
    public float ArmorPierce
    {
        get => this._armorPierce;
    }
    public float CriticalChange
    {
        get => this._criticalChange;
    }
    public float PhysicalLifeSteal
    {
        get => this._physicalLifeSteal;
    }
    public float MagicDamage
    {
        get => this._magicDamage;
    }
    public float MagicPierce
    {
        get => this._magicPierce;
    }
    public float MagicLifeSteal
    {
        get => this._magicLifeSteal;
    }
    public virtual float AttackRange
    {
        get => 1;
    }

    protected virtual void Start()
    {
        this._playerMovement = GetComponent<PlayerMovement>();

        this._pNormalSkillsManager = GetComponent<PlayerNormalSkillsManager>();
        this._pFirstMainSkillsManager = GetComponent<PlayerFirstMainSkillsManager>();
        this._pSecondMainSkillsManager = GetComponent<PlayerSecondMainSkillsManager>();
        this._pThirdMainSkillsManager = GetComponent<PlayerThirdMainSkillsManager>();
    }
    */
}