using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirstMainSkillsManager : PlayerMainSkillsManager
{
    [SerializeField] private KeyCode _firstMainKey = KeyCode.R;

    [SerializeField] private float _rCooldownTimer = 10;

    protected override void Awake() 
    {
        base.Awake();
        
        this.CooldownTimer = _rCooldownTimer;
        this.Timer = _rCooldownTimer; 

        this.SkillKeyCode = _firstMainKey;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update() 
    {
        if ( (this.Timer >= this.CooldownTimer) && (this.PlayerNormalSkillsManager.Timer >= this.PlayerNormalSkillsManager.CooldownTimer) )
        {
            if ( Input.GetKeyDown(this.SkillKeyCode) )
            {
                this.GetMousePos();
                switch (this.PlayerNormalSkillsManager.WeaponName)
                {
                    case "Wood Bow":
                    {
                        if ( ((Vector2)(this.transform.position - this.MousePos)).magnitude <= (this.WoodBowSkillsExecuter.AttackRange) )
                        {
                            StartCoroutine(this.WoodBowSkillsExecuter.RWoodBow(this.PlayerNormalSkillsManager.PhysicalDamage * 0.5f, this.MousePos));
                        }
                        else
                        {
                            if ( !this.IsDisplayAttackDistance )
                            {
                                StartCoroutine(this.DisplayAttackDistance(this.WoodBowSkillsExecuter.AttackRange));
                            }
                        }
                        break;
                    }
                    case "Short Sword":
                    {
                        if ( ((Vector2)(this.transform.position - this.MousePos)).magnitude <= (4f) )
                        {
                            this.ShortSwordSkillsExecuter.RSkillPos = this.MousePos;
                            StartCoroutine(this.ShortSwordSkillsExecuter.RShortSword(this.PlayerNormalSkillsManager.PhysicalDamage));
                        }
                        else
                        {
                            if ( !this.IsDisplayAttackDistance )
                            {
                                StartCoroutine(this.DisplayAttackDistance(4f));
                            }
                        }
                        break;
                    }
                    case "Death Sycthe":
                    {
                        //StartCoroutine(this.DeathSyctheSkills.RDeathSycthe(this.PlayerNormalSkillsManager.PhysicalDamage * 2.5f));
                        break;
                    }
                    case "Short Gun":
                    {
                        break;
                    }
                }
            }
        }
        else if ( this.Timer < this.CooldownTimer )
        {
            this.Timer += Time.deltaTime;
        }
    }
}