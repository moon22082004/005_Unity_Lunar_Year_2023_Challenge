using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThirdMainSkillsManager : PlayerMainSkillsManager
{
    [SerializeField] private KeyCode _thirdMainKey = KeyCode.Space;

    [SerializeField] private float _spaceCooldownTimer = 6;

    protected override void Awake() 
    {
        base.Awake();

        this.CooldownTimer = _spaceCooldownTimer;
        this.Timer = _spaceCooldownTimer; 

        this.SkillKeyCode = _thirdMainKey;
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
                        StartCoroutine(this.WoodBowSkillsExecuter.WoodArcherSpawner("Space Skill", this.PlayerNormalSkillsManager.PhysicalDamage * 1.5f, this.MousePos, this.ProjectilesPositions));
                        break;
                    }
                    case "Short Sword":
                    {
                        StartCoroutine(this.ShortSwordSkillsExecuter.SpaceShortSword());
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
