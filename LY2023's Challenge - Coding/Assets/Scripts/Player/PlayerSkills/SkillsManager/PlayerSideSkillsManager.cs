using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideSkillsManager : PlayerSkillsManager
{
    [SerializeField] private KeyCode _sideKey = KeyCode.Q;
    [SerializeField] private GameObject healingEffect;

    [SerializeField] private string _qSkillName;
    [SerializeField] private float _qCooldownTimer;

    private AttributesManager _attributesManager;

    protected override void Awake() 
    {
        base.Awake();
        
        this.SkillName = _qSkillName;

        this.CooldownTimer = _qCooldownTimer;
        this.Timer = _qCooldownTimer; 

        this.SkillKeyCode = _sideKey;
    }

    protected override void Start()
    {
        base.Start();
        
        this._attributesManager = GetComponent<AttributesManager>();
    }

    private void Update()
    {
        if ( this.Timer >= this.CooldownTimer )
        {
            if ( Input.GetKeyDown(this.SkillKeyCode) )
            {
                switch (this.SkillName)
                {
                    case "Run":
                        StartCoroutine(this.QRun());
                        break;
                    case "Heal":
                        StartCoroutine(this.QHeal());
                        break;
                }
            }
        }
        else
            this.Timer += Time.deltaTime;

        // Display
        if ( this.IsUsedSkill )
            switch (this.SkillName)
            {
                case "Heal":
                    this.healingEffect.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.15f, this.transform.position.z);
                    break;
            }
    }

    private IEnumerator QRun()
    {
        this.Timer = 0;
        
        this.PlayerMovement.IsRun = true;
        this.PlayerMovement.MoveSpeed *= 2;
        yield return new WaitForSeconds(10f);
        this.PlayerMovement.MoveSpeed /= 2;
        this.PlayerMovement.IsRun = false;
    }

    private IEnumerator QHeal()
    {
        this.Timer = 0;
        this.IsUsedSkill = true;

        this.healingEffect.SetActive(true);

        this._attributesManager.TakeDamage(-0.15f * this._attributesManager.MaxLife);
        yield return new WaitForSeconds(1f);

        this.healingEffect.SetActive(false);

        this.IsUsedSkill = false;
    }
}