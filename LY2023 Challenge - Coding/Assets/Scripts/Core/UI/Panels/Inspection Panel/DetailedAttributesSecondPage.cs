using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailedAttributesSecondPage : MonoBehaviour
{
    private AttributesManager PlayerAttributes => LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>();

    [SerializeField] private List<TextMeshProUGUI> _physicalDefenseValues;
    private List<TextMeshProUGUI> PhysicalDefenseValues
    {
        get
        {
            if (_physicalDefenseValues.Count < 2)
            {
                _physicalDefenseValues = new List<TextMeshProUGUI>();

                _physicalDefenseValues.Add(this.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>());
                _physicalDefenseValues.Add(this.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>());
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

                _magicDefenseValues.Add(this.transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>());
                _magicDefenseValues.Add(this.transform.GetChild(1).GetChild(4).GetComponent<TextMeshProUGUI>());
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

                _physicalDamageValues.Add(this.transform.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>());
                _physicalDamageValues.Add(this.transform.GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>());
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

                _physicalPierceValues.Add(this.transform.GetChild(3).GetChild(3).GetComponent<TextMeshProUGUI>());
                _physicalPierceValues.Add(this.transform.GetChild(3).GetChild(4).GetComponent<TextMeshProUGUI>());
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

                _physicalLifeStealValues.Add(this.transform.GetChild(4).GetChild(3).GetComponent<TextMeshProUGUI>());
                _physicalLifeStealValues.Add(this.transform.GetChild(4).GetChild(4).GetComponent<TextMeshProUGUI>());
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

                _magicDamageValues.Add(this.transform.GetChild(5).GetChild(3).GetComponent<TextMeshProUGUI>());
                _magicDamageValues.Add(this.transform.GetChild(5).GetChild(4).GetComponent<TextMeshProUGUI>());
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

                _magicPierceValues.Add(this.transform.GetChild(6).GetChild(3).GetComponent<TextMeshProUGUI>());
                _magicPierceValues.Add(this.transform.GetChild(6).GetChild(4).GetComponent<TextMeshProUGUI>());
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

                _magicLifeStealValues.Add(this.transform.GetChild(7).GetChild(3).GetComponent<TextMeshProUGUI>());
                _magicLifeStealValues.Add(this.transform.GetChild(7).GetChild(4).GetComponent<TextMeshProUGUI>());
            }

            return _magicLifeStealValues;
        }
    }

    private void OnEnable()
    {
        this.PhysicalDefenseValues[0].text = this.PlayerAttributes.BasePhysicalDefense.ToString();
        this.PhysicalDefenseValues[1].text = this.PlayerAttributes.EquippedPhysicalDefense.ToString();

        this.MagicDefenseValues[0].text = this.PlayerAttributes.BaseMagicDefense.ToString();
        this.MagicDefenseValues[1].text = this.PlayerAttributes.EquippedMagicDefense.ToString();

        this.PhysicalDamageValues[0].text = this.PlayerAttributes.BasePhysicalDamage.ToString();
        this.PhysicalDamageValues[1].text = this.PlayerAttributes.EquippedPhysicalDamage.ToString();

        this.PhysicalPierceValues[0].text = this.PlayerAttributes.BasePhysicalPierce.ToString();
        this.PhysicalPierceValues[1].text = this.PlayerAttributes.EquippedPhysicalPierce.ToString();

        this.PhysicalLifeStealValues[0].text = this.PlayerAttributes.BasePhysicalLifeSteal.ToString();
        this.PhysicalLifeStealValues[1].text = this.PlayerAttributes.EquippedPhysicalLifeSteal.ToString();

        this.MagicDamageValues[0].text = this.PlayerAttributes.BaseMagicDamage.ToString();
        this.MagicDamageValues[1].text = this.PlayerAttributes.EquippedMagicDamage.ToString();

        this.MagicPierceValues[0].text = this.PlayerAttributes.BaseMagicPierce.ToString();
        this.MagicPierceValues[1].text = this.PlayerAttributes.EquippedMagicPierce.ToString();

        this.MagicLifeStealValues[0].text = this.PlayerAttributes.BaseMagicLifeSteal.ToString();
        this.MagicLifeStealValues[1].text = this.PlayerAttributes.EquippedMagicLifeSteal.ToString();
    }
}
