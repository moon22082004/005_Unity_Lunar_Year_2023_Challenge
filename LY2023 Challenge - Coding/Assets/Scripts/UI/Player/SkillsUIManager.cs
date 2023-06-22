using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUIManager : MonoBehaviour
{
    private PlayerSideSkillsManager _pSideSkillsManager;
    private PlayerFirstMainSkillsManager _pFirstMainSkillsManager;
    private PlayerSecondMainSkillsManager _pSecondMainSkillsManager;
    private PlayerThirdMainSkillsManager _pThirdMainSkillsManager;

    [Header ("Skills Display")]
    [SerializeField] private GameObject _sideSkillDisplays;

    [SerializeField] private GameObject _firstMainSkillDisplays;
    [SerializeField] private GameObject _secondMainSkillDisplays;
    [SerializeField] private GameObject _thirdMainSkillDisplays;

    [Header ("Skills Cooldown Display")]
    [SerializeField] private Image _sideSkillsCooldownDisplay;

    [SerializeField] private Image _firstMainSkillsCooldownDisplay;
    [SerializeField] private Image _secondMainSkillsCooldownDisplay;
    [SerializeField] private Image _thirdMainSkillsCooldownDisplay;

    private void Awake() 
    {
        _sideSkillDisplays = GameObject.Find("Skills/Side Skills");

        _firstMainSkillDisplays = GameObject.Find("Skills/Main Skills 1");
        _secondMainSkillDisplays = GameObject.Find("Skills/Main Skills 2");
        _thirdMainSkillDisplays = GameObject.Find("Skills/Main Skills 3");

        _sideSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(_sideSkillDisplays);
        _firstMainSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(_firstMainSkillDisplays);
        _secondMainSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(_secondMainSkillDisplays);
        _thirdMainSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(_thirdMainSkillDisplays);
            
        GameObject pCharacter = GameObject.Find("Player/Character");

        _pSideSkillsManager = pCharacter.GetComponent<PlayerSideSkillsManager>();

        _pFirstMainSkillsManager = pCharacter.GetComponent<PlayerFirstMainSkillsManager>();
        _pSecondMainSkillsManager = pCharacter.GetComponent<PlayerSecondMainSkillsManager>();
        _pThirdMainSkillsManager = pCharacter.GetComponent<PlayerThirdMainSkillsManager>();
    }

    private void Start() 
    {
    }

    private void Update() 
    {
        this.DisableOtherSkillDisplays(_sideSkillDisplays, _pSideSkillsManager.SkillName);

        this.DisableOtherSkillDisplays(_firstMainSkillDisplays, _pFirstMainSkillsManager.SkillName);
        this.DisableOtherSkillDisplays(_secondMainSkillDisplays, _pSecondMainSkillsManager.SkillName);
        this.DisableOtherSkillDisplays(_thirdMainSkillDisplays, _pThirdMainSkillsManager.SkillName);

        _sideSkillsCooldownDisplay.fillAmount = _pSideSkillsManager.SkillCooldownFillAmount();
        _firstMainSkillsCooldownDisplay.fillAmount = _pFirstMainSkillsManager.SkillCooldownFillAmount();
        _secondMainSkillsCooldownDisplay.fillAmount = _pSecondMainSkillsManager.SkillCooldownFillAmount();
        _thirdMainSkillsCooldownDisplay.fillAmount = _pThirdMainSkillsManager.SkillCooldownFillAmount();
    }

    private Image GetSkillsCooldownDisplay(GameObject skillsDisplay)
    {
        return skillsDisplay.transform.GetChild(skillsDisplay.transform.childCount - 1).gameObject.GetComponent<Image>();
    }

    private void DisableOtherSkillDisplays(GameObject skillDisplays, string activeSkill)
    {
        for (int i = 0; i < (skillDisplays.transform.childCount - 1); i++)
        {
            if (skillDisplays.transform.GetChild(i).gameObject.name != activeSkill)
            {
                skillDisplays.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                skillDisplays.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        skillDisplays.transform.GetChild(skillDisplays.transform.childCount - 1).gameObject.SetActive(true);
    }
}