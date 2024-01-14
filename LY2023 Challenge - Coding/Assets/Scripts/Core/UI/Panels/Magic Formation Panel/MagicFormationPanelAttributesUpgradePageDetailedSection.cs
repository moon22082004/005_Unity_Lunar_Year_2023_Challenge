using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MagicFormationPanelAttributesUpgradePageDetailedSection : MonoBehaviour
{
    private AttributesManager PlayerAttributes => LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>();
    private EquipmentsManager PlayerEquipments => LunarMonoBehaviour.Instance.Player.GetComponent<EquipmentsManager>();

    [SerializeField] MagicFormationPanelAttributesUpgradePageGeneralSection _generalSection;
    public MagicFormationPanelAttributesUpgradePageGeneralSection GeneralSection
    {
        get 
        {
            if (_generalSection == null)
            {
                _generalSection = this.transform.parent.GetChild(1).GetComponent<MagicFormationPanelAttributesUpgradePageGeneralSection>();
            }

            return _generalSection; 
        }
    }

    [SerializeField] private TextMeshProUGUI _hPMaxValue;
    private TextMeshProUGUI HPMaxValue
    {
        get
        {
            if (_hPMaxValue == null)
            {
                _hPMaxValue = this.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
            }

            return _hPMaxValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _fPMaxValue;
    private TextMeshProUGUI FPMaxValue
    {
        get
        {
            if (_fPMaxValue == null)
            {
                _fPMaxValue = this.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
            }

            return _fPMaxValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _equipLoadMaxValue;
    private TextMeshProUGUI EquipLoadMaxValue
    {
        get
        {
            if (_equipLoadMaxValue == null)
            {
                _equipLoadMaxValue = this.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
            }

            return _equipLoadMaxValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _moveSpeedValue;
    private TextMeshProUGUI MoveSpeedValue
    {
        get
        {
            if (_moveSpeedValue == null)
            {
                _moveSpeedValue = this.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
            }

            return _moveSpeedValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _attackSpeedValue;
    private TextMeshProUGUI AttackSpeedValue
    {
        get
        {
            if (_attackSpeedValue == null)
            {
                _attackSpeedValue = this.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
            }

            return _attackSpeedValue;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _physicalDefenseValues;
    private List<TextMeshProUGUI> PhysicalDefenseValues
    {
        get
        {
            if (_physicalDefenseValues.Count < 2)
            {
                _physicalDefenseValues = new List<TextMeshProUGUI>();

                _physicalDefenseValues.Add(this.transform.GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>());
                _physicalDefenseValues.Add(this.transform.GetChild(5).GetChild(2).GetComponent<TextMeshProUGUI>());
            }

            return _physicalDefenseValues;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _magicDefenseValues;
    private List<TextMeshProUGUI> MagicDefenseValues
    {
        get
        {
            if (_magicDefenseValues.Count < 2)
            {
                _magicDefenseValues = new List<TextMeshProUGUI>();

                _magicDefenseValues.Add(this.transform.GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>());
                _magicDefenseValues.Add(this.transform.GetChild(6).GetChild(2).GetComponent<TextMeshProUGUI>());
            }

            return _magicDefenseValues;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _physicalDamageValues;
    private List<TextMeshProUGUI> PhysicalDamageValues
    {
        get
        {
            if (_physicalDamageValues.Count < 2)
            {
                _physicalDamageValues = new List<TextMeshProUGUI>();

                _physicalDamageValues.Add(this.transform.GetChild(7).GetChild(1).GetComponent<TextMeshProUGUI>());
                _physicalDamageValues.Add(this.transform.GetChild(7).GetChild(2).GetComponent<TextMeshProUGUI>());
            }

            return _physicalDamageValues;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _physicalPierceValues;
    private List<TextMeshProUGUI> PhysicalPierceValues
    {
        get
        {
            if (_physicalPierceValues.Count < 2)
            {
                _physicalPierceValues = new List<TextMeshProUGUI>();

                _physicalPierceValues.Add(this.transform.GetChild(8).GetChild(1).GetComponent<TextMeshProUGUI>());
                _physicalPierceValues.Add(this.transform.GetChild(8).GetChild(2).GetComponent<TextMeshProUGUI>());
            }

            return _physicalPierceValues;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _physicalLifeStealValues;
    private List<TextMeshProUGUI> PhysicalLifeStealValues
    {
        get
        {
            if (_physicalLifeStealValues.Count < 2)
            {
                _physicalLifeStealValues = new List<TextMeshProUGUI>();

                _physicalLifeStealValues.Add(this.transform.GetChild(9).GetChild(1).GetComponent<TextMeshProUGUI>());
                _physicalLifeStealValues.Add(this.transform.GetChild(9).GetChild(2).GetComponent<TextMeshProUGUI>());
            }

            return _physicalLifeStealValues;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _magicDamageValues;
    private List<TextMeshProUGUI> MagicDamageValues
    {
        get
        {
            if (_magicDamageValues.Count < 2)
            {
                _magicDamageValues = new List<TextMeshProUGUI>();

                _magicDamageValues.Add(this.transform.GetChild(10).GetChild(1).GetComponent<TextMeshProUGUI>());
                _magicDamageValues.Add(this.transform.GetChild(10).GetChild(2).GetComponent<TextMeshProUGUI>());
            }

            return _magicDamageValues;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _magicPierceValues;
    private List<TextMeshProUGUI> MagicPierceValues
    {
        get
        {
            if (_magicPierceValues.Count < 2)
            {
                _magicPierceValues = new List<TextMeshProUGUI>();

                _magicPierceValues.Add(this.transform.GetChild(11).GetChild(1).GetComponent<TextMeshProUGUI>());
                _magicPierceValues.Add(this.transform.GetChild(11).GetChild(2).GetComponent<TextMeshProUGUI>());
            }

            return _magicPierceValues;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _magicLifeStealValues;
    private List<TextMeshProUGUI> MagicLifeStealValues
    {
        get
        {
            if (_magicLifeStealValues.Count < 2)
            {
                _magicLifeStealValues = new List<TextMeshProUGUI>();

                _magicLifeStealValues.Add(this.transform.GetChild(12).GetChild(1).GetComponent<TextMeshProUGUI>());
                _magicLifeStealValues.Add(this.transform.GetChild(12).GetChild(2).GetComponent<TextMeshProUGUI>());
            }

            return _magicLifeStealValues;
        }
    }

    private void OnEnable()
    {
        this.UpdateDetailedAttributesDisplays();
    }

    public void UpdateDetailedAttributesDisplays()
    {
        this.HPMaxValue.text = AttributesCalculator.BaseMaxHP(this.GeneralSection.VigorTemporaryLevel).ToString();
        this.FPMaxValue.text = AttributesCalculator.BaseMaxFP(this.GeneralSection.MindTemporaryLevel).ToString();
        this.EquipLoadMaxValue.text = AttributesCalculator.BaseMaxFP(this.GeneralSection.EnduranceTemporaryLevel).ToString();
        this.MoveSpeedValue.text = AttributesCalculator.BaseMoveSpeed(this.PlayerEquipments.EquipMoveSpeed, this.PlayerAttributes.BonusMoveSpeed, (this.PlayerAttributes.CurrentEquipLoad / (AttributesCalculator.BaseMaxFP(this.GeneralSection.EnduranceTemporaryLevel)))).ToString();
        this.AttackSpeedValue.text = AttributesCalculator.BaseAttackSpeed(this.GeneralSection.ArcaneTemporaryLevel).ToString();

        this.PhysicalDefenseValues[0].text = AttributesCalculator.BasePhysicalDefense(this.GeneralSection.EnduranceTemporaryLevel, this.GeneralSection.StrengthTemporaryLevel).ToString();
        this.PhysicalDefenseValues[1].text = this.PlayerAttributes.EquipPhysicalDefense.ToString();

        this.MagicDefenseValues[0].text = AttributesCalculator.BaseMagicDefense(this.GeneralSection.EnduranceTemporaryLevel, this.GeneralSection.IntelligenceTemporaryLevel).ToString();
        this.MagicDefenseValues[1].text = this.PlayerAttributes.EquipMagicDefense.ToString();

        this.PhysicalDamageValues[0].text = AttributesCalculator.BasePhysicalDamage(this.GeneralSection.StrengthTemporaryLevel).ToString();
        this.PhysicalDamageValues[1].text = this.PlayerAttributes.EquipPhysicalDamage.ToString();
        this.PhysicalPierceValues[0].text = AttributesCalculator.BasePhysicalPierce(this.GeneralSection.DexterityTemporaryLevel).ToString();
        this.PhysicalPierceValues[1].text = this.PlayerAttributes.EquipPhysicalPierce.ToString();
        this.PhysicalLifeStealValues[0].text = AttributesCalculator.BasePhysicalLifeSteal(this.GeneralSection.ArcaneTemporaryLevel, this.GeneralSection.DexterityTemporaryLevel).ToString();
        this.PhysicalLifeStealValues[1].text = this.PlayerAttributes.EquipPhysicalLifeSteal.ToString();

        this.MagicDamageValues[0].text = AttributesCalculator.BaseMagicDamage(this.GeneralSection.IntelligenceTemporaryLevel).ToString();
        this.MagicDamageValues[1].text = this.PlayerAttributes.EquipMagicDamage.ToString();
        this.MagicPierceValues[0].text = AttributesCalculator.BaseMagicPierce(this.GeneralSection.FaithTemporaryLevel).ToString();
        this.MagicPierceValues[1].text = this.PlayerAttributes.EquipMagicPierce.ToString();
        this.MagicLifeStealValues[0].text = AttributesCalculator.BaseMagicLifeSteal(this.GeneralSection.ArcaneTemporaryLevel, this.GeneralSection.FaithTemporaryLevel).ToString();
        this.MagicLifeStealValues[1].text = this.PlayerAttributes.EquipMagicLifeSteal.ToString();
    }
}
