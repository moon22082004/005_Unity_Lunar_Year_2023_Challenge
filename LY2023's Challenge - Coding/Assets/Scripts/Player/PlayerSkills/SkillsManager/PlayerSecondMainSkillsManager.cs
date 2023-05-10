using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondMainSkillsManager : PlayerMainSkillsManager
{
    [SerializeField] private KeyCode _secondMainKey = KeyCode.E;

    [SerializeField] private float _eCooldownTimer = 6;

    protected override void Awake() 
    {
        base.Awake();

        this.CooldownTimer = _eCooldownTimer;
        this.Timer = _eCooldownTimer; 

        this.SkillKeyCode = _secondMainKey;
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
                        StartCoroutine(this.WoodBowSkillsExecuter.WoodArcherSpawner("E Skill", this.PlayerNormalSkillsManager.PhysicalDamage / 2, this.MousePos, this.ProjectilesPositions));
                        break;
                    }
                    case "Short Sword":
                    {
                        StartCoroutine(this.ShortSwordSkillsExecuter.EShortSword(this.PlayerNormalSkillsManager.PhysicalDamage * 2.5f, this.MousePos));
                        break;
                    }
                    case "Death Sycthe":
                        break;
                    case "Short Gun":
                        break;
                }
            }
        }
        else if ( this.Timer < this.CooldownTimer )
        {
            this.Timer += Time.deltaTime;
        }
    }
}
