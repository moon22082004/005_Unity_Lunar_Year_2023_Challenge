using UnityEngine;
using UnityEngine.UI;

namespace LY2023Challenge
{
    public class SkillsUIManager : MonoBehaviour
    {
        private SkillsManager _playerSkills;

        [Header("Skills Display")]
        [SerializeField] private Image _sideSkillDisplay;

        [SerializeField] private Image _firstMainSkillDisplay;
        [SerializeField] private Image _secondMainSkillDisplay;
        [SerializeField] private Image _thirdMainSkillDisplay;

        [Header("Skills Cooldown Display")]
        [SerializeField] private Image _sideSkillsCooldownDisplay;

        [SerializeField] private Image _firstMainSkillsCooldownDisplay;
        [SerializeField] private Image _secondMainSkillsCooldownDisplay;
        [SerializeField] private Image _thirdMainSkillsCooldownDisplay;

        private void Awake()
        {
            _sideSkillDisplay = GameObject.Find("Skills/Side Skills").GetComponent<Image>();

            _firstMainSkillDisplay = GameObject.Find("Skills/Main Skills 1").GetComponent<Image>();
            _secondMainSkillDisplay = GameObject.Find("Skills/Main Skills 2").GetComponent<Image>();
            _thirdMainSkillDisplay = GameObject.Find("Skills/Main Skills 3").GetComponent<Image>();

            _sideSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(_sideSkillDisplay.gameObject);
            _firstMainSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(_firstMainSkillDisplay.gameObject);
            _secondMainSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(_secondMainSkillDisplay.gameObject);
            _thirdMainSkillsCooldownDisplay = this.GetSkillsCooldownDisplay(_thirdMainSkillDisplay.gameObject);

            GameObject pCharacter = GameObject.Find("Player/Character");

            _playerSkills = pCharacter.GetComponent<SkillsManager>();
        }

        private void Update()
        {
            _sideSkillDisplay.sprite = _playerSkills.SideSkill.SkillIcon;
            _firstMainSkillDisplay.sprite = _playerSkills.MainSkills[1].SkillIcon;
            _secondMainSkillDisplay.sprite = _playerSkills.MainSkills[2].SkillIcon;
            _thirdMainSkillDisplay.sprite = _playerSkills.MainSkills[3].SkillIcon;

            _sideSkillsCooldownDisplay.fillAmount = _playerSkills.SkillCooldownFillAmounts[_playerSkills.SkillCooldownFillAmounts.Count - 1];
            _firstMainSkillsCooldownDisplay.fillAmount = _playerSkills.SkillCooldownFillAmounts[1];
            _secondMainSkillsCooldownDisplay.fillAmount = _playerSkills.SkillCooldownFillAmounts[2];
            _thirdMainSkillsCooldownDisplay.fillAmount = _playerSkills.SkillCooldownFillAmounts[3];
        }

        private Image GetSkillsCooldownDisplay(GameObject skillsDisplay)
        {
            return skillsDisplay.transform.GetChild(0).gameObject.GetComponent<Image>();
        }
    }
}