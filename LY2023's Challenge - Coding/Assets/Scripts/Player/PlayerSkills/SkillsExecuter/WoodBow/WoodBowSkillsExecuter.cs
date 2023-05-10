using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBowSkillsExecuter : WeaponSkillsExecuter
{
    [Header("Projectiles Attributes")]
    [SerializeField] private float _projectilesLifeTime = 1;
    [SerializeField] private float _projectileSpeed = 20;

    public override float AttackRange
    {
        get => this._projectilesLifeTime * this._projectileSpeed;
    }

    [SerializeField] private GameObject[] _woodBowArchers;

    private bool _isSpawnedRArcher = false;
    private Vector3 _rSkillAreaPos;
    [SerializeField] private GameObject _rCircle;
    private float _rDamage;

    [SerializeField] private GameObject _spaceCircle;

    public bool IsUsedSpaceSkill
    {
        get => this.PlayerThirdMainSkillsManager.IsUsedSkill;
    }

    protected override void Start() 
    {
        base.Start();

        this._rCircle = GameObject.Find("Player/Effects/WoodBow/R WoodBow Circle");
        this._spaceCircle = GameObject.Find("Player/Effects/WoodBow/Space Woodbow Circle");
    }

    public void SkillDisplay() 
    {
        if ( this.PlayerFirstMainSkillsManager.IsUsedSkill )
        {
            this._rCircle.SetActive(true);
            this._rCircle.transform.position = this._rSkillAreaPos;

            if ( ((Random.Range(0, 1000) <= 100) && (this.NumbersOfRArcher() <= 2)) ||
                 ((Random.Range(0, 1000) <= 16) && (this.NumbersOfRArcher() <= 4) && (this.NumbersOfRArcher() > 2)) ||
                 ((Random.Range(0, 1000) <= 8) && (this.NumbersOfRArcher() <= 6) && (this.NumbersOfRArcher() > 4)) ||
                 ((Random.Range(0, 1000) <= 4) && (this.NumbersOfRArcher() <= 8) && (this.NumbersOfRArcher() > 6)) )
                if ( this._isSpawnedRArcher ) 
                {
                    this._woodBowArchers[FindWoodArcher()].GetComponent<WoodArcher>().SetUpRWoodArcher(this._rSkillAreaPos, 1, "R Skill", this._rDamage);
                }
        }
        else
        {
            this._rCircle.SetActive(false);
        }

        if ( this.PlayerThirdMainSkillsManager.IsUsedSkill )
        {
            this._spaceCircle.SetActive(true);
        }
        else
        {
            this._spaceCircle.SetActive(false);
        }
    }

    public IEnumerator WoodArcherSpawner(string typeOfArcher, float physicalDamage, Vector3 mousePos, Vector3[] projectilesPositions)
    {
        switch (typeOfArcher)
        {
            case "E Skill":
            {
                this.PlayerSecondMainSkillsManager.Timer = 0;
                break;
            }
            case "Space Skill":
            {
                this.PlayerThirdMainSkillsManager.Timer = 0;
                break;
            }
        }
        this.PlayerNormalSkillsManager.Timer = 0;

        this.PlayerMovement.IsAttacked = true;
        this.PlayerMovement.MoveSpeed /= 2;
        this.PlayerMovement.WoodBow.SetActiveParentAnimation(true);

        yield return new WaitForSeconds(0.25f);
        switch ( this.PlayerMovement.Direction )
        {
            case "Down":
            {
                if ( mousePos.y < projectilesPositions[0].y )
                {
                    this._woodBowArchers[this.FindWoodArcher()].GetComponent<WoodArcher>().SetUpNormalWoodArcher(projectilesPositions[0], mousePos, this._projectilesLifeTime, this._projectileSpeed, typeOfArcher, physicalDamage);
                }
                else
                {
                    this._woodBowArchers[this.FindWoodArcher()].GetComponent<WoodArcher>().SetUpNormalWoodArcher(projectilesPositions[3], mousePos, this._projectilesLifeTime, this._projectileSpeed, typeOfArcher, physicalDamage);
                }   
                break;
            }
            case "Up":
            {
                if ( mousePos.y > projectilesPositions[1].y )
                {
                    this._woodBowArchers[this.FindWoodArcher()].GetComponent<WoodArcher>().SetUpNormalWoodArcher(projectilesPositions[1], mousePos, this._projectilesLifeTime, this._projectileSpeed, typeOfArcher, physicalDamage);
                }
                else
                {
                    this._woodBowArchers[this.FindWoodArcher()].GetComponent<WoodArcher>().SetUpNormalWoodArcher(projectilesPositions[3], mousePos, this._projectilesLifeTime, this._projectileSpeed, typeOfArcher, physicalDamage);
                }
                break;
            }
            case "Left":
            {
                if ( mousePos.x < projectilesPositions[2].x )
                {
                    this._woodBowArchers[this.FindWoodArcher()].GetComponent<WoodArcher>().SetUpNormalWoodArcher(projectilesPositions[2], mousePos, this._projectilesLifeTime, this._projectileSpeed, typeOfArcher, physicalDamage);
                }
                else
                {
                    this._woodBowArchers[this.FindWoodArcher()].GetComponent<WoodArcher>().SetUpNormalWoodArcher(projectilesPositions[3], mousePos, this._projectilesLifeTime, this._projectileSpeed, typeOfArcher, physicalDamage);
                }
                break;
            }
            case "Right":
            {
                if ( mousePos.x > projectilesPositions[2].x )
                {
                    this._woodBowArchers[this.FindWoodArcher()].GetComponent<WoodArcher>().SetUpNormalWoodArcher(projectilesPositions[2], mousePos, this._projectilesLifeTime, this._projectileSpeed, typeOfArcher, physicalDamage);
                }
                else
                {
                    this._woodBowArchers[this.FindWoodArcher()].GetComponent<WoodArcher>().SetUpNormalWoodArcher(projectilesPositions[3], mousePos, this._projectilesLifeTime, this._projectileSpeed, typeOfArcher, physicalDamage);
                }
                break; 
            }           
        }

        yield return new WaitForSeconds(0.05f);
        this.PlayerMovement.IsAttacked = false;
        this.PlayerMovement.MoveSpeed *= 2;
        this.PlayerMovement.WoodBow.SetActiveParentAnimation(false);
    }

    public IEnumerator RWoodBow(float physicalDamage, Vector3 mousePos)
    {
        this._rSkillAreaPos = mousePos;

        this._rDamage = physicalDamage;
        this.PlayerFirstMainSkillsManager.Timer = 0;
        this.PlayerNormalSkillsManager.Timer = 0;

        this.PlayerMovement.IsAttacked = true;
        this.PlayerMovement.MoveSpeed /= 2;
        this.PlayerMovement.WoodBow.SetActiveParentAnimation(true);

        yield return new WaitForSeconds(0.3f);

        this.PlayerMovement.IsAttacked = false;
        this.PlayerMovement.MoveSpeed *= 2;
        this.PlayerMovement.WoodBow.SetActiveParentAnimation(false);

        this.PlayerFirstMainSkillsManager.IsUsedSkill = true;
        this._isSpawnedRArcher = true;
        yield return new WaitForSeconds(2.3f);
        this._isSpawnedRArcher = false;
        yield return new WaitForSeconds(0.7f);
        this.PlayerFirstMainSkillsManager.IsUsedSkill = false;
    }

    public void SetUpSpaceWoodArcherEffect(Vector3 _contactPos)
    {
        this._spaceCircle.transform.position = _contactPos;
        StartCoroutine(this.SpaceWoodArcherHitEffect());
    }

    private IEnumerator SpaceWoodArcherHitEffect()
    {
        this.PlayerThirdMainSkillsManager.IsUsedSkill = true;

        yield return new WaitForSeconds(2.5f);

        this.PlayerThirdMainSkillsManager.IsUsedSkill = false;
    }

    private int FindWoodArcher()
    {
        for (int i = 0; i < this._woodBowArchers.Length; i++)
        {
            if (!this._woodBowArchers[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private int NumbersOfRArcher()
    {
        int _sum = 0;
        for (int i = 0; i < this._woodBowArchers.Length; i++)
        {
            if ( (this._woodBowArchers[i].activeInHierarchy) && (this._woodBowArchers[i].GetComponent<WoodArcher>().TypeOfArcher == "R Skill" ) )
            {
                _sum += 1;
            }
        }
        return _sum;
    }
}