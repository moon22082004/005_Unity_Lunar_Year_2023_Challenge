using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttributeChangeManager : MonoBehaviour
{
    /*
    [SerializeField] private Button _levelUpButton;
    private Button LevelUpButton
    {
        get
        {
            if (_levelUpButton == null)
            {
                _levelUpButton = this.transform.GetChild(0).GetComponent<Button>();
            }

            return _levelUpButton;
        }
    }

    [SerializeField] private Button _acceptButton;
    private Button AcceptButton
    {
        get
        {
            if (_acceptButton == null)
            {
                _acceptButton = this.transform.GetChild(2).GetComponent<Button>();
            }

            return _acceptButton;
        }
    }

    [SerializeField] private Button _resetButton;
    private Button ResetButton
    {
        get
        {
            if (_resetButton == null)
            {
                _resetButton = this.transform.GetChild(1).GetComponent<Button>();
            }

            return _resetButton;
        }
    }


    [SerializeField] private TextMeshProUGUI _vigorLevelText;
    private TextMeshProUGUI VigorLevelText
    {
        get
        {
            if (_vigorLevelText == null) 
            {
                _vigorLevelText = this.transform.GetChild(3).GetComponent<TextMeshProUGUI>(); 
            }

            return _vigorLevelText;
        }
    }

    private TextMeshProUGUI _levelText;
    private TextMeshProUGUI LevelText
    {
        get
        {
            if (_levelText == null)
            {
                _levelText = this.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
            }

            return _levelText;
        }
    }

    private TextMeshProUGUI _soulsValue;
    private TextMeshProUGUI SoulsValue
    {
        get
        {
            if (_soulsValue == null)
            {
                _soulsValue = this.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
            }

            return _soulsValue;
        }
    }

    private int CurrentLevel
    {
        get
        {
            AttributesManager playerAttributes = LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>();

            int result = playerAttributes.Vigor + playerAttributes.Mind + playerAttributes.Endurance + playerAttributes.Strength + playerAttributes.Dexterity + playerAttributes.Intelligence + playerAttributes.Faith + playerAttributes.Arcane;

            return result;
        }
    }
    private int CurrentVigorLevel
    {
        get => LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>().Vigor;
        set => LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>().Vigor = value;
    }
    private int CurrentSouls
    {
        get => LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>().Souls;
        set => LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>().Souls = value; 
    }

    private int _offsetVigorLevel;
    private int _offsetSouls;

    private void OnEnable()
    {
        _offsetVigorLevel = 0;
        _offsetSouls = 0;

        this.LevelUpButton.interactable = true;
        this.AcceptButton.interactable = false;
        this.ResetButton.interactable = false;
    }

    protected virtual void Update()
    {
        if ((this.CurrentSouls + _offsetSouls < this.NeededSouls(this.CurrentLevel + _offsetVigorLevel)) || (this.CurrentVigorLevel + _offsetVigorLevel >= 99))
        {
            this.LevelUpButton.interactable = false;
        }

        int vigorLevel = this.CurrentVigorLevel + _offsetVigorLevel;

        if (_offsetVigorLevel > 0)
        {
            this.VigorLevelText.color = Color.red;
        }
        else
        {
            this.VigorLevelText.color = Color.white;
        }

        this.VigorLevelText.text = vigorLevel.ToString();
        this.LevelText.text = (this.CurrentLevel + _offsetVigorLevel).ToString(); 
        this.SoulsValue.text = (this.CurrentSouls + _offsetSouls).ToString();
    }

    // Buttons
    public void OnClickLevelUpButton()
    {
        if (this.CurrentSouls + _offsetSouls >= this.NeededSouls(this.CurrentLevel + _offsetVigorLevel))
        {
            _offsetSouls -= this.NeededSouls(this.CurrentLevel + _offsetVigorLevel);
            _offsetVigorLevel += 1;

            this.AcceptButton.interactable = true;
            this.ResetButton.interactable = true;
        }
    }
    public void OnClickAcceptButton()
    {
        this.CurrentVigorLevel += _offsetVigorLevel;
        this.CurrentSouls += _offsetSouls;

        this.OnClickResetButton();
    }    
    public void OnClickResetButton()
    {
        _offsetVigorLevel = 0;
        _offsetSouls = 0;

        this.AcceptButton.interactable = false;
        this.ResetButton.interactable = false;
    }    

    private int NeededSouls(int attributesCurrentLevel)
    {
        int result = 0;

        // Vigor Level 1
        result += 500;
        // Vigor Level 2-10
        result += 20 * Mathf.Max(0, Mathf.Min(9, attributesCurrentLevel - 1));
        // Vigor Level 11-19
        result += 225 * Mathf.Max(0, Mathf.Min(9, attributesCurrentLevel - 10));
        // Vigor Level 20-27
        result += 284 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 19));
        // Vigor Level 28-35
        result += 364 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 27));
        // Vigor Level 36-43
        result += 442 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 35));
        // Vigor Level 44-51
        result += 539 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 43));
        // Vigor Level 52-59
        result += 637 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 51));
        // Vigor Level 60-67
        result += 733 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 59));
        // Vigor Level 68-75
        result += 851 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 67));
        // Vigor Level 76-83
        result += 980 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 75));
        // Vigor Level 84-91
        result += 1098 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 83));
        // Vigor Level 92-99
        result += 1260 * Mathf.Max(0, Mathf.Min(8, attributesCurrentLevel - 91));

        return result;
    }
    */

    [SerializeField] private List<Button> _attributesChangeLevelUpButton;
    public List<Button> AttributesChangeLevelUpButton
    {
        get 
        {
            if (_attributesChangeLevelUpButton.Count == 0)
            {
                _attributesChangeLevelUpButton = new List<Button>();

                for (int i = 0; i < 8; i++) 
                {
                    _attributesChangeLevelUpButton.Add(this.transform.GetChild(i).GetChild(0).GetComponent<Button>());
                }
            }

            return _attributesChangeLevelUpButton;
        }
    }

    [SerializeField] private List<Button> _attributesChangeAcceptButton;
    public List<Button> AttributesChangeAcceptButton
    {
        get
        {
            if (_attributesChangeAcceptButton.Count == 0)
            {
                _attributesChangeAcceptButton = new List<Button>();

                for (int i = 0; i < 8; i++)
                {
                    _attributesChangeAcceptButton.Add(this.transform.GetChild(i).GetChild(1).GetComponent<Button>());
                }
            }

            return _attributesChangeAcceptButton;
        }
    }
}