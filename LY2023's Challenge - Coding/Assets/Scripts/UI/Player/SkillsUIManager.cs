using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUIManager : MonoBehaviour
{
    private PlayerSideSkillsManager _pSideSkillsManager;
    private PlayerNormalSkillsManager _pNormalSkillsManager;
    private PlayerFirstMainSkillsManager _pFirstMainSkillsManager;
    private PlayerSecondMainSkillsManager _pSecondMainSkillsManager;
    private PlayerThirdMainSkillsManager _pThirdMainSkillsManager;

    [Header ("Skills Display")]
    [SerializeField] private GameObject _sideSkillsDisplay;

    [SerializeField] private GameObject _firstMainSkillsDisplay;
    [SerializeField] private GameObject _secondMainSkillsDisplay;
    [SerializeField] private GameObject _thirdMainSkillsDisplay;

    [Header ("Skills Cooldown Display")]
    [SerializeField] private Image _sideSkillsCooldownDisplay;

    [SerializeField] private Image _firstMainSkillsCooldownDisplay;
    [SerializeField] private Image _secondMainSkillsCooldownDisplay;
    [SerializeField] private Image _thirdMainSkillsCooldownDisplay;

    private void Awake() 
    {
        this._sideSkillsDisplay = GameObject.Find("Skills/Side Skills (Q)");

        this._firstMainSkillsDisplay = GameObject.Find("Skills/Main Skills (R)");
        this._secondMainSkillsDisplay = GameObject.Find("Skills/Main Skills (E)");
        this._thirdMainSkillsDisplay = GameObject.Find("Skills/Main Skills (Space)");

        this._sideSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(this._sideSkillsDisplay);
        this._firstMainSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(this._firstMainSkillsDisplay);
        this._secondMainSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(this._secondMainSkillsDisplay);
        this._thirdMainSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(this._thirdMainSkillsDisplay);

        GameObject pCharacter = GameObject.Find("Player/Character");

        this._pSideSkillsManager = pCharacter.GetComponent<PlayerSideSkillsManager>();

        this._pNormalSkillsManager = pCharacter.GetComponent<PlayerNormalSkillsManager>();
        this._pFirstMainSkillsManager = pCharacter.GetComponent<PlayerFirstMainSkillsManager>();
        this._pSecondMainSkillsManager = pCharacter.GetComponent<PlayerSecondMainSkillsManager>();
        this._pThirdMainSkillsManager = pCharacter.GetComponent<PlayerThirdMainSkillsManager>();
    }

    private void Start() 
    {
    }

    private void Update() 
    {
        switch (this._pSideSkillsManager.SkillName)
        {
            case "Run":
            {
                this.DisableOtherQSkills(0);
                break;
            }
            case "Heal":
            {
                this.DisableOtherQSkills(1);
                break;
            }
        }
        switch (this._pNormalSkillsManager.WeaponName)
        {
            case "Wood Bow":
            {
                this.DisableOtherMainSkills(0);
                break;
            }
            case "Short Sword":
            {
                this.DisableOtherMainSkills(1);
                break;
            }
            case "Short Gun":
            {
                this.DisableOtherMainSkills(2);
                break;
            }
            case "Rifle":
            {
                this.DisableOtherMainSkills(3);
                break;
            }
            case "Death Sycthe":
            {
                this.DisableOtherMainSkills(4);
                break;
            }
            case "Beast Hammer":
            {
                this.DisableOtherMainSkills(5);
                break;
            }
        }

        this._sideSkillsCooldownDisplay.fillAmount = this._pSideSkillsManager.SkillCooldownFillAmount();
        this._firstMainSkillsCooldownDisplay.fillAmount = this._pFirstMainSkillsManager.SkillCooldownFillAmount();
        this._secondMainSkillsCooldownDisplay.fillAmount = this._pSecondMainSkillsManager.SkillCooldownFillAmount();
        this._thirdMainSkillsCooldownDisplay.fillAmount = this._pThirdMainSkillsManager.SkillCooldownFillAmount();
    }

    private Image GetSkillsCooldownDisplay(GameObject skillsDisplay)
    {
        return skillsDisplay.transform.GetChild(skillsDisplay.transform.childCount - 1).gameObject.GetComponent<Image>();
    }

    private void DisableOtherQSkills(int index)
    {
        for (int i = 0; i < (this._sideSkillsDisplay.transform.childCount - 1); i++)
        {
            if ( i != index )
            {
                this._sideSkillsDisplay.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                this._sideSkillsDisplay.transform.GetChild(i).gameObject.SetActive(true);             
            }
        }    
        this._sideSkillsDisplay.transform.GetChild(this._sideSkillsDisplay.transform.childCount - 1).gameObject.SetActive(true);       
    }

    private void DisableOtherMainSkills(int index)
    {
        for (int i = 0; i < (this._firstMainSkillsDisplay.transform.childCount - 1); i++)
        {
            if ( i != index )
            {
                this._firstMainSkillsDisplay.transform.GetChild(i).gameObject.SetActive(false);
                this._secondMainSkillsDisplay.transform.GetChild(i).gameObject.SetActive(false);
                this._thirdMainSkillsDisplay.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                this._firstMainSkillsDisplay.transform.GetChild(i).gameObject.SetActive(true);
                this._secondMainSkillsDisplay.transform.GetChild(i).gameObject.SetActive(true);
                this._thirdMainSkillsDisplay.transform.GetChild(i).gameObject.SetActive(true);                
            }
        }
        this._firstMainSkillsDisplay.transform.GetChild(this._firstMainSkillsDisplay.transform.childCount - 1).gameObject.SetActive(true);
        this._secondMainSkillsDisplay.transform.GetChild(this._secondMainSkillsDisplay.transform.childCount - 1).gameObject.SetActive(true);
        this._thirdMainSkillsDisplay.transform.GetChild(this._thirdMainSkillsDisplay.transform.childCount - 1).gameObject.SetActive(true);  
    }
}