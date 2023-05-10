using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalSkillsManager : PlayerMainSkillsManager
{
    [SerializeField] private string _weaponName;
    [SerializeField] private float _physicalDamage;

    [SerializeField] private KeyCode _normalAttackKey = KeyCode.Mouse0;

    [SerializeField] private float _normalAttackCooldown;

    public string WeaponName
    {
        get => _weaponName;
        set => _weaponName = value;
    }
    public float PhysicalDamage
    {
        get => _physicalDamage;
        set => _physicalDamage = value;
    }

    protected override void Awake() 
    {
        base.Awake();

        this.CooldownTimer = _normalAttackCooldown;
        this.Timer = _normalAttackCooldown;

        this.SkillKeyCode = _normalAttackKey;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update() 
    {
        if ( this.Timer >= this.CooldownTimer )
        {
            if ( Input.GetKeyDown(this.SkillKeyCode) )
            {
                this.GetMousePos();
                switch (this.WeaponName)
                {
                    case "Wood Bow":
                    {
                        StartCoroutine(this.WoodBowSkillsExecuter.WoodArcherSpawner("Normal Attack", this.PhysicalDamage, this.MousePos, this.ProjectilesPositions));
                        break;
                    }
                    case "Short Sword":
                    {
                        StartCoroutine(this.ShortSwordSkillsExecuter.ShortSwordAttack(this.PhysicalDamage * 1.5f));
                        break;
                    }
                    case "Death Sycthe":
                        //StartCoroutine(this.DeathSyctheSkills.DeathSyctheAttack(this.PhysicalDamage * 1.6f));
                        break;
                    case "Short Gun":
                        break;
                }
            }
        }
        else
        {
            this.Timer += Time.deltaTime;  
        }

        switch (this.WeaponName)
        {
            case "Wood Bow":
            {
                this.WoodBowSkillsExecuter.SkillDisplay();
                break;
            }
            case "Short Sword":
            {
                this.ShortSwordSkillsExecuter.SkillDisplay();
                break;
            }
            case "Death Sycthe":
                break;
            case "Short Gun":
                break;
        }  
    }
}