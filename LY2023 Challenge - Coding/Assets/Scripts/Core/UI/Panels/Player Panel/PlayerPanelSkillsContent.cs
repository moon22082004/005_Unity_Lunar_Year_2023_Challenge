using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayerPanelSkillsContent : MonoBehaviour
{
    [SerializeField] private SkillsManager _playerSkills;
    private SkillsManager PlayerSkills
    {
        get
        {
            if (_playerSkills == null)
            {
                _playerSkills = GameObject.Find("Player/Character").GetComponent<SkillsManager>();
            }

            return _playerSkills;
        }
    }

    [SerializeField] private int _currentPage;
    [SerializeField] private string _changeSkillTypeName;

    [SerializeField] private Transform _equippedSkillsPageTransform;
    private Transform EquippedSkillsPageTransform
    {
        get
        {
            if (_equippedSkillsPageTransform == null)
            {
                _equippedSkillsPageTransform = this.transform.GetChild(0);
            }

            return _equippedSkillsPageTransform;
        }
    }

    private Image _sideEquippedSkillDisplay;
    private Image SideEquippedSkillDisplay
    {
        get 
        {
            if (_sideEquippedSkillDisplay == null)
            {
                _sideEquippedSkillDisplay = this.EquippedSkillsPageTransform.GetChild(0).GetChild(0).GetComponent<Image>();
            }

            return _sideEquippedSkillDisplay;
        }
    }
    private Image _firstMainEquippedSkillDisplay;
    private Image FirstMainEquippedSkillDisplay
    {
        get
        {
            if (_firstMainEquippedSkillDisplay == null)
            {
                _firstMainEquippedSkillDisplay = this.EquippedSkillsPageTransform.GetChild(1).GetChild(0).GetComponent<Image>();
            }

            return _firstMainEquippedSkillDisplay;
        }
    }
    private Image _secondMainEquippedSkillDisplay;
    private Image SecondMainEquippedSkillDisplay
    {
        get
        {
            if (_secondMainEquippedSkillDisplay == null)
            {
                _secondMainEquippedSkillDisplay = this.EquippedSkillsPageTransform.GetChild(2).GetChild(0).GetComponent<Image>();
            }

            return _secondMainEquippedSkillDisplay;
        }
    }
    private Image _thirdMainEquippedSkillDisplay;
    private Image ThirdMainEquippedSkillDisplay
    {
        get
        {
            if (_thirdMainEquippedSkillDisplay == null)
            {
                _thirdMainEquippedSkillDisplay = this.EquippedSkillsPageTransform.GetChild(3).GetChild(0).GetComponent<Image>();
            }

            return _thirdMainEquippedSkillDisplay;
        }
    }

    private TextMeshProUGUI _sideEquippedSkillCode;
    private TextMeshProUGUI SideEquippedSkillCode
    {
        get
        {
            if (_sideEquippedSkillCode == null)
            {
                _sideEquippedSkillCode = this.EquippedSkillsPageTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            }

            return _sideEquippedSkillCode;
        }
    }
    private TextMeshProUGUI _firstMainEquippedSkillCode;
    private TextMeshProUGUI FirstMainEquippedSkillCode
    {
        get
        {
            if (_firstMainEquippedSkillCode == null)
            {
                _firstMainEquippedSkillCode = this.EquippedSkillsPageTransform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            }

            return _firstMainEquippedSkillCode;
        }
    }
    private TextMeshProUGUI _secondMainEquippedSkillCode;
    private TextMeshProUGUI SecondMainEquippedSkillCode
    {
        get
        {
            if (_secondMainEquippedSkillCode == null)
            {
                _secondMainEquippedSkillCode = this.EquippedSkillsPageTransform.GetChild(2).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            }

            return _secondMainEquippedSkillCode;
        }
    }
    private TextMeshProUGUI _thirdMainEquippedSkillCode;
    private TextMeshProUGUI ThirdMainEquippedSkillCode
    {
        get
        {
            if (_thirdMainEquippedSkillCode == null)
            {
                _thirdMainEquippedSkillCode = this.EquippedSkillsPageTransform.GetChild(3).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            }

            return _thirdMainEquippedSkillCode;
        }
    }

    [SerializeField] private Transform _availableSkillsPagesTransform;
    private Transform AvailableSkillsPagesTransform
    {
        get
        {
            if (_availableSkillsPagesTransform == null)
            {
                _availableSkillsPagesTransform = this.transform.GetChild(1);
            }

            return _availableSkillsPagesTransform;
        }
    }

    [SerializeField] private GameObject _skillPage;
    public GameObject SkillPage
    {
        get
        {
            if (_skillPage == null)
            {
                _skillPage = Resources.Load("Prefabs/UI/Player Panel/Skill Page") as GameObject;
            }

            return _skillPage;
        }
    }

    private List<Skill> AvailableSkills
    {
        get => LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>().SkillsByType(_changeSkillTypeName);
    }

    private int NumberOfSkillPages
    {
        get
        {
            return (1 + (int)(this.AvailableSkills.Count / 15));
        }
    }

    [SerializeField] private int _currentSkillPage;

    private void OnEnable()
    {
        _currentPage = 0;
        _currentSkillPage = 0;
    }

    private void Update()
    {
        if (_currentPage == 0) 
        {
            if (this.AvailableSkillsPagesTransform.childCount > 1)
            {
                int numOfPreviousSkillsPage = this.AvailableSkillsPagesTransform.childCount - 1;
                for (int i = numOfPreviousSkillsPage; i >= 1; i--)
                {
                    Destroy(this.AvailableSkillsPagesTransform.GetChild(i).gameObject);
                }
            }

            this.EquippedSkillsPageTransform.gameObject.SetActive(true);
            this.AvailableSkillsPagesTransform.gameObject.SetActive(false);

            this.SideEquippedSkillDisplay.sprite = this.PlayerSkills.SideSkill.SkillIcon;
            this.FirstMainEquippedSkillDisplay.sprite = this.PlayerSkills.MainSkills[1].SkillIcon;
            this.SecondMainEquippedSkillDisplay.sprite = this.PlayerSkills.MainSkills[2].SkillIcon;
            this.ThirdMainEquippedSkillDisplay.sprite = this.PlayerSkills.MainSkills[3].SkillIcon;

            this.SideEquippedSkillCode.text = this.PlayerSkills.SkillKeys[this.PlayerSkills.SkillKeys.Count - 1].ToString();
            this.FirstMainEquippedSkillCode.text = this.PlayerSkills.SkillKeys[1].ToString();
            this.SecondMainEquippedSkillCode.text = this.PlayerSkills.SkillKeys[2].ToString();
            this.ThirdMainEquippedSkillCode.text = this.PlayerSkills.SkillKeys[3].ToString();
        }
        else
        {
            this.EquippedSkillsPageTransform.gameObject.SetActive(false);
            this.AvailableSkillsPagesTransform.gameObject.SetActive(true);

            while (this.AvailableSkillsPagesTransform.childCount < this.NumberOfSkillPages + 1)
            {
                GameObject page = Instantiate(this.SkillPage);
                page.name = $"{this.SkillPage.name} {this.AvailableSkillsPagesTransform.childCount}";
                page.transform.SetParent(this.AvailableSkillsPagesTransform, false);
            }

            this.AvailableSkillsPagesTransform.GetChild(0).GetChild(0).GetComponent<Button>().interactable = !(_currentSkillPage == 0);
            this.AvailableSkillsPagesTransform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = !(_currentSkillPage == this.NumberOfSkillPages - 1);

            for (int i = 0; i < this.NumberOfSkillPages; i++)
            {
                if (i != _currentSkillPage)
                {
                    this.AvailableSkillsPagesTransform.GetChild(i + 1).gameObject.SetActive(false);
                }
                else
                {
                    this.AvailableSkillsPagesTransform.GetChild(i + 1).gameObject.SetActive(true);
                }
            }

            for (int i = 1; i <= this.NumberOfSkillPages; i++)
            {
                List<Skill> skills = new List<Skill>();
                for (int j = ((i - 1) * 15); j < Mathf.Min(i * 15, this.AvailableSkills.Count); j++)
                {
                    skills.Add(this.AvailableSkills[j]);
                }

                this.AvailableSkillsPagesTransform.GetChild(i).GetComponent<SkillIconsUIManager>().Skills = skills;
            }
        }    
    }

    public void CallChangeMainSkillPage(int index)
    {
        string skillTypeName = "MainSkill";
        _changeSkillTypeName = skillTypeName;
        _currentPage = 1;

        while (this.AvailableSkillsPagesTransform.childCount < this.NumberOfSkillPages + 1)
        {
            GameObject page = Instantiate(this.SkillPage);
            page.name = $"{this.SkillPage.name} {this.AvailableSkillsPagesTransform.childCount}";
            page.transform.SetParent(this.AvailableSkillsPagesTransform, false);
        }

        _currentSkillPage = 0;

        for (int i = 1; i <= this.NumberOfSkillPages; i++)
        {
            foreach (Button button in this.AvailableSkillsPagesTransform.GetChild(i).GetComponent<SkillIconsUIManager>().Buttons)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => this.ChangeSkill(skillTypeName, index, button.GetComponent<SkillIconUISlotManager>().Skill));
            }
        }
    }

    public void CallChangeSideSkillPage()
    {
        string skillTypeName = "SideSkill";
        _changeSkillTypeName = skillTypeName;
        _currentPage = 1;

        while (this.AvailableSkillsPagesTransform.childCount < this.NumberOfSkillPages + 1)
        {
            GameObject page = Instantiate(this.SkillPage);
            page.name = $"{this.SkillPage.name} {this.AvailableSkillsPagesTransform.childCount}";
            page.transform.SetParent(this.AvailableSkillsPagesTransform, false);
        }

        _currentSkillPage = 0;

        for (int i = 1; i <= this.NumberOfSkillPages; i++)
        {
            foreach (Button button in this.AvailableSkillsPagesTransform.GetChild(i).GetComponent<SkillIconsUIManager>().Buttons)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => this.ChangeSkill(skillTypeName, 0, button.GetComponent<SkillIconUISlotManager>().Skill));
            }
        }
    }

    public void ChangeSkill(string skillTypeName, int index, Skill choosenSkill)
    {
        if (choosenSkill != null)
        {
            LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>().SwapSkillFromCharacter(skillTypeName, index, choosenSkill, LunarMonoBehaviour.Instance.Player.GetComponent<SkillsManager>());
            _currentPage = 0;
        }
    }
}