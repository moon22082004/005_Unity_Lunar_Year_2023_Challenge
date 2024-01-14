using UnityEngine;
using UnityEngine.UI;

public class MagicFormationPanelAttributesUpgradePageGeneralSection : MonoBehaviour
{
    private AttributesManager PlayerAttributes => LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>();

    [SerializeField] private InspectionPanelGeneralAttributesPage _generalAttributes;
    public InspectionPanelGeneralAttributesPage GeneralAttributes
    {
        get 
        {
            if (_generalAttributes == null)
            {
                _generalAttributes = GetComponent<InspectionPanelGeneralAttributesPage>();
            }

            return _generalAttributes;
        }
    }

    [SerializeField] MagicFormationPanelAttributesUpgradePageDetailedSection _detailedSection;
    public MagicFormationPanelAttributesUpgradePageDetailedSection DetailedSection
    {
        get
        {
            if (_detailedSection == null)
            {
                _detailedSection = this.transform.parent.GetChild(2).GetComponent<MagicFormationPanelAttributesUpgradePageDetailedSection>();
            }

            return _detailedSection;
        }
    }

    [SerializeField] private int _vigorTemporaryLevelOffset;
    public int VigorTemporaryLevel => this.PlayerAttributes.Vigor + _vigorTemporaryLevelOffset;
    private Button VigorUpgradeButton => this.GeneralAttributes.VigorUIGameObject.transform.GetChild(4).GetComponent<Button>();

    [SerializeField] private int _mindTemporaryLevelOffset;
    public int MindTemporaryLevel => this.PlayerAttributes.Mind + _mindTemporaryLevelOffset;
    private Button MindUpgradeButton => this.GeneralAttributes.MindUIGameObject.transform.GetChild(4).GetComponent<Button>();

    [SerializeField] private int _enduranceTemporaryLevelOffset;
    public int EnduranceTemporaryLevel => this.PlayerAttributes.Endurance + _enduranceTemporaryLevelOffset;
    private Button EnduranceUpgradeButton => this.GeneralAttributes.EnduranceUIGameObject.transform.GetChild(4).GetComponent<Button>();

    [SerializeField] private int _arcaneTemporaryLevelOffset;
    public int ArcaneTemporaryLevel => this.PlayerAttributes.Arcane + _arcaneTemporaryLevelOffset;
    private Button ArcaneUpgradeButton => this.GeneralAttributes.ArcaneUIGameObject.transform.GetChild(4).GetComponent<Button>();

    [SerializeField] private int _strengthTemporaryLevelOffset;
    public int StrengthTemporaryLevel => this.PlayerAttributes.Strength + _strengthTemporaryLevelOffset;
    private Button StrengthUpgradeButton => this.GeneralAttributes.StrengthUIGameObject.transform.GetChild(4).GetComponent<Button>();

    [SerializeField] private int _dexterityTemporaryLevelOffset;
    public int DexterityTemporaryLevel => this.PlayerAttributes.Dexterity + _dexterityTemporaryLevelOffset;
    private Button DexterityUpgradeButton => this.GeneralAttributes.DexterityUIGameObject.transform.GetChild(4).GetComponent<Button>();

    [SerializeField] private int _intelligenceTemporaryLevelOffset;
    public int IntelligenceTemporaryLevel => this.PlayerAttributes.Intelligence + _intelligenceTemporaryLevelOffset;
    private Button IntelligenceUpgradeButton => this.GeneralAttributes.IntelligenceUIGameObject.transform.GetChild(4).GetComponent<Button>();

    [SerializeField] private int _faithTemporaryLevelOffset;
    public int FaithTemporaryLevel => this.PlayerAttributes.Faith + _faithTemporaryLevelOffset;
    private Button FaithUpgradeButton => this.GeneralAttributes.FaithUIGameObject.transform.GetChild(4).GetComponent<Button>();

    [SerializeField] private int _elixirTemporaryValueOffset;
    private int ElixirTemporaryValue => this.PlayerAttributes.Elixir + _elixirTemporaryValueOffset;

    [SerializeField] private Button _confirmUpgradeButton;
    private Button ConfirmUpgradeButton
    {
        get
        {
            if (_confirmUpgradeButton == null) 
            {
                _confirmUpgradeButton = this.transform.GetChild(2).GetComponent<Button>();
            }

            return _confirmUpgradeButton;
        }
    }

    private int NeededElixir(int attributeLevel)
    {
        int result = 0;

        // Vigor Level 1
        result += 500;
        // Vigor Level 2-10
        result += 20 * Mathf.Max(0, Mathf.Min(9, attributeLevel - 1));
        // Vigor Level 11-19
        result += 225 * Mathf.Max(0, Mathf.Min(9, attributeLevel - 10));
        // Vigor Level 20-27
        result += 284 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 19));
        // Vigor Level 28-35
        result += 364 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 27));
        // Vigor Level 36-43
        result += 442 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 35));
        // Vigor Level 44-51
        result += 539 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 43));
        // Vigor Level 52-59
        result += 637 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 51));
        // Vigor Level 60-67
        result += 733 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 59));
        // Vigor Level 68-75
        result += 851 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 67));
        // Vigor Level 76-83
        result += 980 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 75));
        // Vigor Level 84-91
        result += 1098 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 83));
        // Vigor Level 92-99
        result += 1260 * Mathf.Max(0, Mathf.Min(8, attributeLevel - 91));

        return result;
    }

    private void CheckIfAttributesCanUpgrade()
    {
        this.VigorUpgradeButton.interactable = (this.NeededElixir(this.VigorTemporaryLevel) <= this.ElixirTemporaryValue);
        this.MindUpgradeButton.interactable = (this.NeededElixir(this.MindTemporaryLevel) <= this.ElixirTemporaryValue);
        this.EnduranceUpgradeButton.interactable = (this.NeededElixir(this.EnduranceTemporaryLevel) <= this.ElixirTemporaryValue);
        this.ArcaneUpgradeButton.interactable = (this.NeededElixir(this.ArcaneTemporaryLevel) <= this.ElixirTemporaryValue);
        this.StrengthUpgradeButton.interactable = (this.NeededElixir(this.StrengthTemporaryLevel) <= this.ElixirTemporaryValue);
        this.DexterityUpgradeButton.interactable = (this.NeededElixir(this.DexterityTemporaryLevel) <= this.ElixirTemporaryValue);
        this.IntelligenceUpgradeButton.interactable = (this.NeededElixir(this.IntelligenceTemporaryLevel) <= this.ElixirTemporaryValue);
        this.FaithUpgradeButton.interactable = (this.NeededElixir(this.FaithTemporaryLevel) <= this.ElixirTemporaryValue);

        this.DetailedSection.UpdateDetailedAttributesDisplays();
    }

    private void OnEnable()
    {
        this.CheckIfAttributesCanUpgrade();

        this.ResetOffsetValues();

        this.ConfirmUpgradeButton.interactable = false;
    }

    public void PrepareToUpgradeVigor()
    {
        _elixirTemporaryValueOffset -= this.NeededElixir(this.VigorTemporaryLevel);
        _vigorTemporaryLevelOffset +=1;
        this.GeneralAttributes.UpdateTemporaryGeneralAttribute(this.GeneralAttributes.VigorUIGameObject, this.VigorTemporaryLevel);
        this.GeneralAttributes.UpdateTemporaryElixirValue(this.ElixirTemporaryValue);

        this.CheckIfAttributesCanUpgrade();
    }

    public void PrepareToUpgradeMind()
    {
        _elixirTemporaryValueOffset -= this.NeededElixir(this.MindTemporaryLevel);
        _mindTemporaryLevelOffset += 1;
        this.GeneralAttributes.UpdateTemporaryGeneralAttribute(this.GeneralAttributes.MindUIGameObject, this.MindTemporaryLevel);
        this.GeneralAttributes.UpdateTemporaryElixirValue(this.ElixirTemporaryValue);

        this.CheckIfAttributesCanUpgrade();
    }

    public void PrepareToUpgradeEndurance()
    {
        _elixirTemporaryValueOffset -= this.NeededElixir(this.EnduranceTemporaryLevel);
        _enduranceTemporaryLevelOffset += 1;
        this.GeneralAttributes.UpdateTemporaryGeneralAttribute(this.GeneralAttributes.EnduranceUIGameObject, this.EnduranceTemporaryLevel);
        this.GeneralAttributes.UpdateTemporaryElixirValue(this.ElixirTemporaryValue);

        this.CheckIfAttributesCanUpgrade();
    }

    public void PrepareToUpgradeArcane()
    {
        _elixirTemporaryValueOffset -= this.NeededElixir(this.ArcaneTemporaryLevel);
        _arcaneTemporaryLevelOffset += 1;
        this.GeneralAttributes.UpdateTemporaryGeneralAttribute(this.GeneralAttributes.ArcaneUIGameObject, this.ArcaneTemporaryLevel);
        this.GeneralAttributes.UpdateTemporaryElixirValue(this.ElixirTemporaryValue);

        this.CheckIfAttributesCanUpgrade();
    }

    public void PrepareToUpgradeStrength()
    {
        _elixirTemporaryValueOffset -= this.NeededElixir(this.StrengthTemporaryLevel);
        _strengthTemporaryLevelOffset += 1;
        this.GeneralAttributes.UpdateTemporaryGeneralAttribute(this.GeneralAttributes.StrengthUIGameObject, this.StrengthTemporaryLevel);
        this.GeneralAttributes.UpdateTemporaryElixirValue(this.ElixirTemporaryValue);

        this.CheckIfAttributesCanUpgrade();
    }

    public void PrepareToUpgradeDexterity()
    {
        _elixirTemporaryValueOffset -= this.NeededElixir(this.DexterityTemporaryLevel);
        _dexterityTemporaryLevelOffset += 1;
        this.GeneralAttributes.UpdateTemporaryGeneralAttribute(this.GeneralAttributes.DexterityUIGameObject, this.DexterityTemporaryLevel);
        this.GeneralAttributes.UpdateTemporaryElixirValue(this.ElixirTemporaryValue);

        this.CheckIfAttributesCanUpgrade();
    }

    public void PrepareToUpgradeIntelligence()
    {
        _elixirTemporaryValueOffset -= this.NeededElixir(this.IntelligenceTemporaryLevel);
        _intelligenceTemporaryLevelOffset += 1;
        this.GeneralAttributes.UpdateTemporaryGeneralAttribute(this.GeneralAttributes.IntelligenceUIGameObject, this.IntelligenceTemporaryLevel);
        this.GeneralAttributes.UpdateTemporaryElixirValue(this.ElixirTemporaryValue);

        this.CheckIfAttributesCanUpgrade();
    }

    public void PrepareToUpgradeFaith()
    {
        _elixirTemporaryValueOffset -= this.NeededElixir(this.FaithTemporaryLevel);
        _faithTemporaryLevelOffset += 1;
        this.GeneralAttributes.UpdateTemporaryGeneralAttribute(this.GeneralAttributes.FaithUIGameObject, this.FaithTemporaryLevel);
        this.GeneralAttributes.UpdateTemporaryElixirValue(this.ElixirTemporaryValue);

        this.CheckIfAttributesCanUpgrade();
    }

    private void ResetOffsetValues()
    {
        _vigorTemporaryLevelOffset = 0;
        _mindTemporaryLevelOffset = 0;
        _enduranceTemporaryLevelOffset = 0;
        _arcaneTemporaryLevelOffset = 0;
        _strengthTemporaryLevelOffset = 0;
        _dexterityTemporaryLevelOffset = 0;
        _intelligenceTemporaryLevelOffset = 0;
        _faithTemporaryLevelOffset = 0;

        _elixirTemporaryValueOffset = 0;
    }

    public void ConfirmUpgrade()
    {
        this.PlayerAttributes.Vigor = this.VigorTemporaryLevel;
        this.PlayerAttributes.Mind = this.MindTemporaryLevel;
        this.PlayerAttributes.Endurance = this.EnduranceTemporaryLevel;
        this.PlayerAttributes.Arcane = this.ArcaneTemporaryLevel;
        this.PlayerAttributes.Strength = this.StrengthTemporaryLevel;
        this.PlayerAttributes.Dexterity = this.DexterityTemporaryLevel;
        this.PlayerAttributes.Intelligence = this.IntelligenceTemporaryLevel;
        this.PlayerAttributes.Faith = this.FaithTemporaryLevel;

        this.PlayerAttributes.Elixir = this.ElixirTemporaryValue;

        this.ResetOffsetValues();

        this.GeneralAttributes.UpdateGeneralAttributes();

        this.CheckIfAttributesCanUpgrade();
    }

    private void Update()
    {
        this.ConfirmUpgradeButton.interactable = (_elixirTemporaryValueOffset != 0);
    }
}
