using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPanelAttributesContent : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _hPValues;
    private List<TextMeshProUGUI> HPValues
    {
        get 
        {
            if (_hPValues.Count < 2)
            {
                _hPValues = new List<TextMeshProUGUI>();

                _hPValues.Add(this.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>());
                _hPValues.Add(this.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>());
            }

            return _hPValues;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _fPValues;
    private List<TextMeshProUGUI> FPValues
    {
        get
        {
            if (_fPValues.Count < 2)
            {
                _fPValues = new List<TextMeshProUGUI>();

                _fPValues.Add(this.transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>());
                _fPValues.Add(this.transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>());
            }

            return _fPValues;
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _equipedLoadValues;
    private List<TextMeshProUGUI> EquipedLoadValues
    {
        get
        {
            if (_equipedLoadValues.Count < 2)
            {
                _equipedLoadValues = new List<TextMeshProUGUI>();

                _equipedLoadValues.Add(this.transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>());
                _equipedLoadValues.Add(this.transform.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>());
            }

            return _equipedLoadValues;
        }
    }

    [SerializeField] private TextMeshProUGUI _moveSpeedValue;
    private TextMeshProUGUI MoveSpeedValue
    {
        get 
        {
            if (_moveSpeedValue == null) 
            {
                _moveSpeedValue = this.transform.GetChild(3).GetChild(2).GetComponent<TextMeshProUGUI>();
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
                _attackSpeedValue = this.transform.GetChild(4).GetChild(2).GetComponent<TextMeshProUGUI>();
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

                _physicalDefenseValues.Add(this.transform.GetChild(5).GetChild(2).GetComponent<TextMeshProUGUI>());
                _physicalDefenseValues.Add(this.transform.GetChild(5).GetChild(3).GetComponent<TextMeshProUGUI>());
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

                _magicDefenseValues.Add(this.transform.GetChild(6).GetChild(2).GetComponent<TextMeshProUGUI>());
                _magicDefenseValues.Add(this.transform.GetChild(6).GetChild(3).GetComponent<TextMeshProUGUI>());
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

                _physicalDamageValues.Add(this.transform.GetChild(7).GetChild(2).GetComponent<TextMeshProUGUI>());
                _physicalDamageValues.Add(this.transform.GetChild(7).GetChild(3).GetComponent<TextMeshProUGUI>());
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

                _physicalPierceValues.Add(this.transform.GetChild(8).GetChild(2).GetComponent<TextMeshProUGUI>());
                _physicalPierceValues.Add(this.transform.GetChild(8).GetChild(3).GetComponent<TextMeshProUGUI>());
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

                _physicalLifeStealValues.Add(this.transform.GetChild(9).GetChild(2).GetComponent<TextMeshProUGUI>());
                _physicalLifeStealValues.Add(this.transform.GetChild(9).GetChild(3).GetComponent<TextMeshProUGUI>());
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

                _magicDamageValues.Add(this.transform.GetChild(10).GetChild(2).GetComponent<TextMeshProUGUI>());
                _magicDamageValues.Add(this.transform.GetChild(10).GetChild(3).GetComponent<TextMeshProUGUI>());
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

                _magicPierceValues.Add(this.transform.GetChild(11).GetChild(2).GetComponent<TextMeshProUGUI>());
                _magicPierceValues.Add(this.transform.GetChild(11).GetChild(3).GetComponent<TextMeshProUGUI>());
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

                _magicLifeStealValues.Add(this.transform.GetChild(12).GetChild(2).GetComponent<TextMeshProUGUI>());
                _magicLifeStealValues.Add(this.transform.GetChild(12).GetChild(3).GetComponent<TextMeshProUGUI>());
            }

            return _magicLifeStealValues;
        }
    }

    [SerializeField] private TextMeshProUGUI _vigorValue;
    private TextMeshProUGUI VigorValue
    {
        get
        {
            if (_vigorValue == null)
            {
                _vigorValue = this.transform.GetChild(13).GetChild(2).GetComponent<TextMeshProUGUI>();
            }

            return _vigorValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _mindValue;
    private TextMeshProUGUI MindValue
    {
        get
        {
            if (_mindValue == null)
            {
                _mindValue = this.transform.GetChild(14).GetChild(2).GetComponent<TextMeshProUGUI>();
            }

            return _mindValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _enduranceValue;
    private TextMeshProUGUI EnduranceValue
    {
        get
        {
            if (_enduranceValue == null)
            {
                _enduranceValue = this.transform.GetChild(15).GetChild(2).GetComponent<TextMeshProUGUI>();
            }

            return _enduranceValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _strengthValue;
    private TextMeshProUGUI StrengthValue
    {
        get
        {
            if (_strengthValue == null)
            {
                _strengthValue = this.transform.GetChild(16).GetChild(2).GetComponent<TextMeshProUGUI>();
            }

            return _strengthValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _dexterityValue;
    private TextMeshProUGUI DexterityValue
    {
        get
        {
            if (_dexterityValue == null)
            {
                _dexterityValue = this.transform.GetChild(17).GetChild(2).GetComponent<TextMeshProUGUI>();
            }

            return _dexterityValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _intelligenceValue;
    private TextMeshProUGUI IntelligenceValue
    {
        get
        {
            if (_intelligenceValue == null)
            {
                _intelligenceValue = this.transform.GetChild(18).GetChild(2).GetComponent<TextMeshProUGUI>();
            }

            return _intelligenceValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _faithValue;
    private TextMeshProUGUI FaithValue
    {
        get
        {
            if (_faithValue == null)
            {
                _faithValue = this.transform.GetChild(19).GetChild(2).GetComponent<TextMeshProUGUI>();
            }

            return _faithValue;
        }
    }

    [SerializeField] private TextMeshProUGUI _arcaneValue;
    private TextMeshProUGUI ArcaneValue
    {
        get
        {
            if (_arcaneValue == null)
            {
                _arcaneValue = this.transform.GetChild(20).GetChild(2).GetComponent<TextMeshProUGUI>();
            }

            return _arcaneValue;
        }
    }



    private void Update()
    {
        AttributesManager playerAttributes = LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>();

        this.HPValues[0].text = playerAttributes.CurrentHP.ToString();
        this.HPValues[1].text = playerAttributes.MaxHP.ToString();

        this.FPValues[0].text = playerAttributes.CurrentFP.ToString();
        this.FPValues[1].text = playerAttributes.MaxFP.ToString();

        this.EquipedLoadValues[0].text = playerAttributes.CurrentEquipLoad.ToString();
        this.EquipedLoadValues[1].text = playerAttributes.MaxEquipLoad.ToString();

        this.MoveSpeedValue.text = playerAttributes.MoveSpeed.ToString();

        this.AttackSpeedValue.text = playerAttributes.AttackSpeed.ToString();

        this.PhysicalDefenseValues[0].text = playerAttributes.BasePhysicalDefense.ToString();
        this.PhysicalDefenseValues[1].text = playerAttributes.EquippedPhysicalDefense.ToString();

        this.MagicDefenseValues[0].text = playerAttributes.BaseMagicDefense.ToString();
        this.MagicDefenseValues[1].text = playerAttributes.EquippedMagicDefense.ToString();

        this.PhysicalDamageValues[0].text = playerAttributes.BasePhysicalDamage.ToString();
        this.PhysicalDamageValues[1].text = playerAttributes.EquippedPhysicalDamage.ToString();

        this.PhysicalPierceValues[0].text = playerAttributes.BasePhysicalPierce.ToString();
        this.PhysicalPierceValues[1].text = playerAttributes.EquippedPhysicalPierce.ToString();

        this.PhysicalLifeStealValues[0].text = playerAttributes.BasePhysicalLifeSteal.ToString();
        this.PhysicalLifeStealValues[1].text = playerAttributes.EquippedPhysicalLifeSteal.ToString();

        this.MagicDamageValues[0].text = playerAttributes.BaseMagicDamage.ToString();
        this.MagicDamageValues[1].text = playerAttributes.EquippedMagicDamage.ToString();

        this.MagicPierceValues[0].text = playerAttributes.BaseMagicPierce.ToString();
        this.MagicPierceValues[1].text = playerAttributes.EquippedMagicPierce.ToString();

        this.MagicLifeStealValues[0].text = playerAttributes.BaseMagicLifeSteal.ToString();
        this.MagicLifeStealValues[1].text = playerAttributes.EquippedMagicLifeSteal.ToString();

        this.VigorValue.text = playerAttributes.Vigor.ToString();
        this.MindValue.text = playerAttributes.Mind.ToString();
        this.EnduranceValue.text = playerAttributes.Endurance.ToString();
        this.StrengthValue.text = playerAttributes.Strength.ToString();
        this.DexterityValue.text = playerAttributes.Dexterity.ToString();
        this.IntelligenceValue.text = playerAttributes.Intelligence.ToString();
        this.FaithValue.text = playerAttributes.Faith.ToString();
        this.ArcaneValue.text = playerAttributes.Arcane.ToString();
    }
}