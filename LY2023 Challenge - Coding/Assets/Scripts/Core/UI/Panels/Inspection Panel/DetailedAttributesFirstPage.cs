using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailedAttributesFirstPage : MonoBehaviour
{
    private AttributesManager PlayerAttributes => LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>();

    [SerializeField] private List<TextMeshProUGUI> _hPValues;
    private List<TextMeshProUGUI> HPValues
    {
        get
        {
            if (_hPValues.Count < 2)
            {
                _hPValues = new List<TextMeshProUGUI>();

                _hPValues.Add(this.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>());
                _hPValues.Add(this.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>());
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

                _fPValues.Add(this.transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>());
                _fPValues.Add(this.transform.GetChild(1).GetChild(4).GetComponent<TextMeshProUGUI>());
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

                _equipedLoadValues.Add(this.transform.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>());
                _equipedLoadValues.Add(this.transform.GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>());
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
                _moveSpeedValue = this.transform.GetChild(3).GetChild(3).GetComponent<TextMeshProUGUI>();
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
                _attackSpeedValue = this.transform.GetChild(4).GetChild(3).GetComponent<TextMeshProUGUI>();
            }

            return _attackSpeedValue;
        }
    }

    private void OnEnable()
    {
        this.HPValues[0].text = this.PlayerAttributes.CurrentHP.ToString();
        this.HPValues[1].text = this.PlayerAttributes.MaxHP.ToString();

        this.FPValues[0].text = this.PlayerAttributes.CurrentFP.ToString();
        this.FPValues[1].text = this.PlayerAttributes.MaxFP.ToString();

        this.EquipedLoadValues[0].text = this.PlayerAttributes.CurrentEquipLoad.ToString();
        this.EquipedLoadValues[1].text = this.PlayerAttributes.MaxEquipLoad.ToString();

        this.MoveSpeedValue.text = this.PlayerAttributes.MoveSpeed.ToString();

        this.AttackSpeedValue.text = this.PlayerAttributes.AttackSpeed.ToString();
    }
}
