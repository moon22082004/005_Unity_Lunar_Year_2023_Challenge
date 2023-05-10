using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    private void Start() 
    {
        this.Respawn();
    }

    private void Update() 
    {
        this.gameObject.SetActive(this._currentLife > 0);
    }

    [Header("Life")]
    [SerializeField] private float _maxLife;
    [SerializeField] private float _currentLife;

    public float MaxLife
    {
        get => this._maxLife;
    }
    public float CurrentLife
    {
        get => this._currentLife;
    }

    public void TakeDamage(float damage)
    {
        this._currentLife = Mathf.Clamp(this._currentLife - damage, 0, this._maxLife);
    }
    public void Respawn()
    {
        this.gameObject.SetActive(true);
        this._currentLife = this._maxLife;
    }

    [Header("Defense")]
    [SerializeField] private float _armor;
    [SerializeField] private float _magicDefense;

    public float Armor
    {
        get => this._armor;
    }
    public float MagicDefense
    {
        get => this._magicDefense;
    }

    [Header("Physical Attack")]
    [SerializeField] private float _physicalDamage;
    [SerializeField] private float _armorPierce;
    [SerializeField] private float _physicalLifeSteal;
    [SerializeField] private float _criticalChange;

    public float PhysicalDamage
    {
        get => this._physicalDamage;
    }
    public float ArmorPierce
    {
        get => this._armorPierce;
    }
    public float PhysicalLifeSteal
    {
        get => this._physicalLifeSteal;
    }
    public float CriticalChange
    {
        get => this._criticalChange;
    }

    [Header("Magic Attack")]
    [SerializeField] private float _magicDamage;
    [SerializeField] private float _magicPierce;
    [SerializeField] private float _magicLifeSteal;

    public float MagicDamage
    {
        get => this._magicDamage;
    }
    public float MagicPierce
    {
        get => this._magicPierce;
    }
    public float MagicLifeSteal
    {
        get => this._magicLifeSteal;
    }
}