using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    private EquipmentsManager _equipmentsManager;

    [SerializeField, Range(1, 99)] private int _vigorLevel = 1;
    [SerializeField, Range(1, 99)] private int _mindLevel = 1;
    [SerializeField, Range(1, 99)] private int _enduranceLevel = 1;
    [SerializeField, Range(1, 99)] private int _strengthLevel = 1;
    [SerializeField, Range(1, 99)] private int _dexterityLevel = 1;
    [SerializeField, Range(1, 99)] private int _intelligenceLevel = 1;
    [SerializeField, Range(1, 99)] private int _faithLevel = 1;
    [SerializeField, Range(1, 99)] private int _arcaneLevel = 1;
    #region Level Properties
    public int Vigor
    {
        get => _vigorLevel;
        set => _vigorLevel = value;
    }
    public int Mind
    {
        get => _mindLevel;
        set => _mindLevel = value;
    }
    public int Endurance
    {
        get => _enduranceLevel; 
        set => _enduranceLevel = value;
    }
    public int Strength
    {
        get => _strengthLevel; 
        set => _strengthLevel = value;
    }
    public int Dexterity
    { 
        get => _dexterityLevel; 
        set => _dexterityLevel = value;
    }
    public int Intelligence
    {
        get => _intelligenceLevel;
        set => _intelligenceLevel = value;
    }
    public int Faith
    {
        get => _faithLevel;
        set => _faithLevel = value;
    }
    public int Arcane
    {
        get => _arcaneLevel;
        set => _arcaneLevel = value;
    }
    #endregion

    // ---------------------------------------------------------------------------------------------------------------
    [Header("Life - HP")]
    [SerializeField] private float _maxHP;
    [SerializeField] private float _currentHP;
    public float MaxHP
    {
        get
        {
            _maxHP = 0;
            // Vigor Level 1
            _maxHP += 500f;
            // Vigor Level 2-5
            _maxHP += 5f * Mathf.Max(0, Mathf.Min(4, _vigorLevel - 1));
            // Vigor Level 6-10
            _maxHP += 7f * Mathf.Max(0, Mathf.Min(5, _vigorLevel - 5));
            // Vigor Level 11-15
            _maxHP += 10f * Mathf.Max(0, Mathf.Min(5, _vigorLevel - 10));
            // Vigor Level 16-20
            _maxHP += 15f * Mathf.Max(0, Mathf.Min(5, _vigorLevel - 15));
            // Vigor Level 21-25
            _maxHP += 20f * Mathf.Max(0, Mathf.Min(5, _vigorLevel - 20));
            // Vigor Level 26-30
            _maxHP += 28f * Mathf.Max(0, Mathf.Min(5, _vigorLevel - 25));
            // Vigor Level 31-35
            _maxHP += 36f * Mathf.Max(0, Mathf.Min(5, _vigorLevel - 30));
            // Vigor Level 36-40
            _maxHP += 45f * Mathf.Max(0, Mathf.Min(5, _vigorLevel - 35));
            // Vigor Level 41-50
            _maxHP += 28f * Mathf.Max(0, Mathf.Min(10, _vigorLevel - 40));
            // Vigor Level 51-60
            _maxHP += 20f * Mathf.Max(0, Mathf.Min(10, _vigorLevel - 50));
            // Vigor Level 61-70
            _maxHP += 14f * Mathf.Max(0, Mathf.Min(10, _vigorLevel - 60));
            // Vigor Level 71-80
            _maxHP += 10f * Mathf.Max(0, Mathf.Min(10, _vigorLevel - 70));
            // Vigor Level 81-90
            _maxHP += 6f * Mathf.Max(0, Mathf.Min(10, _vigorLevel - 80));
            // Vigor Level 91-99
            _maxHP += 3f * Mathf.Max(0, Mathf.Min(9, _vigorLevel - 90));

            return _maxHP;
        }
    }
    public float CurrentHP => _currentHP;
    public void IncreaseHealth(float value)
    {
        _currentHP = Mathf.Clamp(_currentHP + value, 0, _maxHP);
    }
    public void TakeDamage(AttributesManager perpetratorAttributes, float value, float pierceValue, bool isMagic) 
    {
        float initialHP = _currentHP;

        if (isMagic)
        {
            _currentHP = Mathf.Clamp(_currentHP - (value - Mathf.Max(0, _magicDefense - pierceValue)), 0, _maxHP);
            perpetratorAttributes.IncreaseHealth(Mathf.Abs(initialHP - _currentHP) * perpetratorAttributes.MagicLifeSteal);
        }
        else
        {
            _currentHP = Mathf.Clamp(_currentHP - (value - Mathf.Max(0, _physicalDefense - pierceValue)), 0, _maxHP);
            perpetratorAttributes.IncreaseHealth(Mathf.Abs(initialHP - _currentHP) * perpetratorAttributes.PhysicalLifeSteal);
        }

        if (_currentHP <= 0) 
        {
            StopAllCoroutines();
            this.gameObject.SetActive(false);
        }
    }

    // ---------------------------------------------------------------------------------------------------------------
    [Header("FP")]
    [SerializeField] private float _maxFP;
    [SerializeField] private float _currentFP;
    public float MaxFP
    {
        get
        {
            _maxFP = 0;
            // Mind Level 1
            _maxFP += 150f;
            // Mind Level 2-12
            _maxFP += 3f * Mathf.Max(0, Mathf.Min(11, _mindLevel - 1));
            // Mind Level 13-15
            _maxFP += 4f * Mathf.Max(0, Mathf.Min(3, _mindLevel - 12));
            // Mind Level 16-30
            _maxFP += 5f * Mathf.Max(0, Mathf.Min(15, _mindLevel - 15));
            // Mind Level 31-35
            _maxFP += 6f * Mathf.Max(0, Mathf.Min(5, _mindLevel - 30));
            // Mind Level 36-45
            _maxFP += 7f * Mathf.Max(0, Mathf.Min(10, _mindLevel - 35));
            // Mind Level 46-55
            _maxFP += 6f * Mathf.Max(0, Mathf.Min(10, _mindLevel - 45));
            // Mind Level 56-60
            _maxFP += 4f * Mathf.Max(0, Mathf.Min(5, _mindLevel - 55));
            // Mind Level 61-87
            _maxFP += 2f * Mathf.Max(0, Mathf.Min(27, _mindLevel - 60));
            // Mind Level 88-89
            _maxFP += 3f * Mathf.Max(0, Mathf.Min(2, _mindLevel - 87));
            // Mind Level 90-99
            _maxFP += 4f * Mathf.Max(0, Mathf.Min(10, _mindLevel - 89));

            return _maxFP;
        }
    }
    public float CurrentFP => _currentFP;
    public void ChangeFP(float addedvalue) 
    {
        _currentFP = Mathf.Clamp(_currentFP + addedvalue, 0, _maxFP);
    }

    public void Respawn()
    {
        this.gameObject.SetActive(true);
        _currentHP = this.MaxHP;
        _currentFP = this.MaxFP;
    }

    // ---------------------------------------------------------------------------------------------------------------
    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _bonusMoveSpeed;
    private bool _isLockedMovement;
    public float MoveSpeed
    {
        get
        {
            if (!_isLockedMovement)
            {
                _moveSpeed = 3f;

                // MoveSpeed from equipments (Leg Armor)
                _moveSpeed += _equipmentsManager.EquippedMoveSpeed;

                // Other Bonus MoveSpeed
                _moveSpeed = Mathf.Max(0.001f, _moveSpeed + this.BonusMoveSpeed);

                // Final MoveSpeed after equip load considering
                float equipLoadRate = this.CurrentEquipLoad / this.MaxEquipLoad;
                if (equipLoadRate > 0.5f)
                {
                    _moveSpeed -= Mathf.Min(_moveSpeed / 2, _moveSpeed * equipLoadRate / 2);
                }

                return _moveSpeed;
            }
            else
            {
                return 0f;
            }
        }
    }
    public float BonusMoveSpeed
    {
        get => _bonusMoveSpeed;
        set => _bonusMoveSpeed = value;
    }
    public bool IsLockedMovement
    {
        get => _isLockedMovement;
        set => _isLockedMovement = value;
    }

    [Header("Equip Load")]
    [SerializeField] private float _maxEquipLoad;
    [SerializeField] private float _currentEquipLoad;
    public float MaxEquipLoad
    {
        get
        {
            _maxEquipLoad = 0f;

            // Endurance Level 1
            _maxEquipLoad += 20f;
            // Endurance Level 2-10
            _maxEquipLoad += 1f * Mathf.Max(0, Mathf.Min(9, this.Endurance - 1));
            // Endurance Level 11-20
            _maxEquipLoad += 1.5f * Mathf.Max(0, Mathf.Min(10, this.Endurance - 10));
            // Endurance Level 21-25
            _maxEquipLoad += 1.6f * Mathf.Max(0, Mathf.Min(5, this.Endurance - 20));
            // Endurance Level 26-40
            _maxEquipLoad += 1.25f * Mathf.Max(0, Mathf.Min(15, this.Endurance - 25));
            // Endurance Level 41-60
            _maxEquipLoad += 1.5f * Mathf.Max(0, Mathf.Min(20, this.Endurance - 40));
            // Endurance Level 61-85
            _maxEquipLoad += 1f * Mathf.Max(0, Mathf.Min(25, this.Endurance - 60));
            // Endurance Level 86-99
            _maxEquipLoad += 1.1f * Mathf.Max(0, Mathf.Min(14, this.Endurance - 85));

            return _maxEquipLoad;
        }
    }
    public float CurrentEquipLoad => _equipmentsManager.EquipLoad;

    // ---------------------------------------------------------------------------------------------------------------
    [Header("Defense")]
    [SerializeField] private float _physicalDefense;
    [SerializeField] private float _magicDefense;
    public float PhysicalDefense
    {
        get
        {
            _physicalDefense = 0;
            // Endurance Level 1
            _physicalDefense += 7.5f;
            // Endurance Level 2-10
            _physicalDefense += 1.5f * Mathf.Max(0, Mathf.Min(9, this.Endurance - 1));
            // Endurance Level 11-20
            _physicalDefense += 2f * Mathf.Max(0, Mathf.Min(10, this.Endurance - 10));
            // Endurance Level 21-30
            _physicalDefense += 2.5f * Mathf.Max(0, Mathf.Min(10, this.Endurance - 20));
            // Endurance Level 31-50
            _physicalDefense += 1.75f * Mathf.Max(0, Mathf.Min(20, this.Endurance - 30));
            // Endurance Level 51-75
            _physicalDefense += 1f * Mathf.Max(0, Mathf.Min(25, this.Endurance - 50));
            // Endurance Level 76-99
            _physicalDefense += 0.75f * Mathf.Max(0, Mathf.Min(24, this.Endurance - 75));

            // Strength Level 1-10
            _physicalDefense += 0.5f * Mathf.Max(0, Mathf.Min(10, this.Strength));
            // Strength Level 11-25
            _physicalDefense += 1f * Mathf.Max(0, Mathf.Min(15, this.Strength - 10));
            // Strength Level 26-35
            _physicalDefense += 1.5f * Mathf.Max(0, Mathf.Min(10, this.Strength - 25));
            // Strength Level 36-40
            _physicalDefense += 2f * Mathf.Max(0, Mathf.Min(5, this.Strength - 35));
            // Strength Level 41-60
            _physicalDefense += 1.25f * Mathf.Max(0, Mathf.Min(20, this.Strength - 40));
            // Strength Level 61-99
            _physicalDefense += 1f * Mathf.Max(0, Mathf.Min(39, this.Strength - 60));

            // Final Physical Defense
            _physicalDefense += _equipmentsManager.EquippedPhysicalDefense;

            return _physicalDefense;
        }
    }
    public float MagicDefense
    {
        get
        {
            _magicDefense = 0;
            // Endurance Level 1
            _magicDefense += 5f;
            // Endurance Level 2-10
            _magicDefense += 1f * Mathf.Max(0, Mathf.Min(9, this.Endurance - 1));
            // Endurance Level 11-30
            _magicDefense += 1.75f * Mathf.Max(0, Mathf.Min(20, this.Endurance - 10));
            // Endurance Level 31-55
            _magicDefense += 2f * Mathf.Max(0, Mathf.Min(25, this.Endurance - 30));
            // Endurance Level 56-75
            _magicDefense += 1.5f * Mathf.Max(0, Mathf.Min(20, this.Endurance - 55));
            // Endurance Level 76-99
            _magicDefense += 1.25f * Mathf.Max(0, Mathf.Min(24, this.Endurance - 75));

            // Intelligence Level 1-10
            _magicDefense += 0.5f * Mathf.Max(0, Mathf.Min(10, this.Intelligence));
            // Intelligence Level 11-35
            _magicDefense += 1f * Mathf.Max(0, Mathf.Min(25, this.Intelligence - 10));
            // Intelligence Level 36-45
            _magicDefense += 2.5f * Mathf.Max(0, Mathf.Min(10, this.Intelligence - 35));
            // Intelligence Level 46-60
            _magicDefense += 2f * Mathf.Max(0, Mathf.Min(15, this.Intelligence - 45));
            // Intelligence Level 61-92
            _magicDefense += 1.25f * Mathf.Max(0, Mathf.Min(32, this.Intelligence - 60));
            // Intelligence Level 93-99
            _magicDefense += 1f * Mathf.Max(0, Mathf.Min(7, this.Intelligence - 92));

            // Final Magic Defense
            _magicDefense += _equipmentsManager.EquippedMagicDefense;

            return _magicDefense;
        }
    }

    // ---------------------------------------------------------------------------------------------------------------
    [Header("Attack")]
    [SerializeField] private float _attackSpeed;
    public float AttackSpeed
    {
        get
        {
            _attackSpeed = 0;

            // Arcane Level 1
            _attackSpeed += 1f;
            // Arcane Level 2-10
            _attackSpeed -= 0.01f * Mathf.Max(0, Mathf.Min(9, _arcaneLevel - 1));
            // Arcane Level 11-25
            _attackSpeed -= 0.005f * Mathf.Max(0, Mathf.Min(15, _arcaneLevel - 10));
            // Arcane Level 26-55
            _attackSpeed -= 0.0025f * Mathf.Max(0, Mathf.Min(30, _arcaneLevel - 25));
            // Arcane Level 56-65
            _attackSpeed -= 0.0015f * Mathf.Max(0, Mathf.Min(10, _arcaneLevel - 55));
            // Arcane Level 66-99
            _attackSpeed -= 0.001f * Mathf.Max(0, Mathf.Min(34, _arcaneLevel - 65));

            return _attackSpeed;
        }
    }

    // ---------------------------------------------------------------------------------------------------------------
    [Header("Physical Attack")]
    [SerializeField] private float _physicalDamage;
    [SerializeField] private float _physicalPierce;
    [SerializeField] private float _physicalLifeSteal;
    [SerializeField] private float _criticalChange;
    public float PhysicalDamage
    {
        get
        {
            _physicalDamage = 0;

            // Strength Level 1
            _physicalDamage += 10f;
            // Strength Level 2-15
            _physicalDamage += 4f * Mathf.Max(0, Mathf.Min(14, this.Strength - 1));
            // Strength Level 16-29
            _physicalDamage += 5f * Mathf.Max(0, Mathf.Min(14, this.Strength - 15));
            // Strength Level 30-43
            _physicalDamage += 6f * Mathf.Max(0, Mathf.Min(14, this.Strength - 29));
            // Strength Level 44-57
            _physicalDamage += 5f * Mathf.Max(0, Mathf.Min(14, this.Strength - 43));
            // Strength Level 58-71
            _physicalDamage += 4f * Mathf.Max(0, Mathf.Min(14, this.Strength - 57));
            // Strength Level 72-85
            _physicalDamage += 3f * Mathf.Max(0, Mathf.Min(14, this.Strength - 71));
            // Strength Level 86-99
            _physicalDamage += 2f * Mathf.Max(0, Mathf.Min(14, this.Strength - 85));

            // Final Physical Damage
            _physicalDamage += _equipmentsManager.EquippedPhysicalDamage;

            return _physicalDamage;
        }
    }
    public float PhysicalPierce
    {
        get
        {
            _physicalPierce = 0;
            // Dexterity Level 1
            _physicalPierce += 2f;
            // Dexterity Level 2-10
            _physicalPierce += 1f * Mathf.Max(0, Mathf.Min(9, this.Dexterity - 1));
            // Dexterity Level 11-30
            _physicalPierce += 1.5f * Mathf.Max(0, Mathf.Min(20, this.Dexterity - 10));
            // Dexterity Level 31-40
            _physicalPierce += 2f * Mathf.Max(0, Mathf.Min(10, this.Dexterity - 30));
            // Dexterity Level 41-60
            _physicalPierce += 1.5f * Mathf.Max(0, Mathf.Min(20, this.Dexterity - 40));
            // Dexterity Level 61-99
            _physicalPierce += 1f * Mathf.Max(0, Mathf.Min(39, this.Dexterity - 60));

            // Final Physical Pierce
            _physicalPierce += _equipmentsManager.EquippedPhysicalPierce;

            return _physicalPierce;
        }
    }
    public float PhysicalLifeSteal
    {
        get
        {
            _physicalLifeSteal = 0;

            // Arcane + Dexterity Level 2
            _physicalLifeSteal += 0.005f;
            // Arcane + Dexterity Level 3-20
            _physicalLifeSteal += 0.0025f * Mathf.Max(0, Mathf.Min(18, this.Arcane + this.Dexterity - 2));
            // Arcane + Dexterity Level 21-40
            _physicalLifeSteal += 0.0015f * Mathf.Max(0, Mathf.Min(20, this.Arcane + this.Dexterity - 20));
            // Arcane + Dexterity Level 41-70
            _physicalLifeSteal += 0.001f * Mathf.Max(0, Mathf.Min(30, this.Arcane + this.Dexterity - 40));
            // Arcane + Dexterity Level 71-110
            _physicalLifeSteal += 0.00125f * Mathf.Max(0, Mathf.Min(40, this.Arcane + this.Dexterity - 70));
            // Arcane + Dexterity Level 111-120
            _physicalLifeSteal += 0.001f * Mathf.Max(0, Mathf.Min(10, this.Arcane + this.Dexterity - 110));
            // Arcane + Dexterity Level 121-160
            _physicalLifeSteal += 0.00075f * Mathf.Max(0, Mathf.Min(40, this.Arcane + this.Dexterity - 120));
            // Arcane + Dexterity Level 161-198
            _physicalLifeSteal += 0.0005f * Mathf.Max(0, Mathf.Min(38, this.Arcane + this.Dexterity - 160));

            // Final Physical Life Steal
            _physicalLifeSteal += _equipmentsManager.EquippedPhysicalLifeSteal;

            return _physicalLifeSteal;
        }
    }
    public float CriticalChange
    {
        get => _criticalChange;
    }

    // ---------------------------------------------------------------------------------------------------------------
    [Header("Magic Attack")]
    [SerializeField] private float _magicDamage;
    [SerializeField] private float _magicPierce;
    [SerializeField] private float _magicLifeSteal;
    public float MagicDamage
    {
        get
        {
            _magicDamage = 0;
            // Strength Level 1
            _magicDamage += 10;
            // Strength Level 2-15
            _magicDamage += 4.5f * Mathf.Max(0, Mathf.Min(14, this.Intelligence - 1));
            // Strength Level 16-29
            _magicDamage += 5f * Mathf.Max(0, Mathf.Min(14, this.Intelligence - 15));
            // Strength Level 30-43
            _magicDamage += 6.5f * Mathf.Max(0, Mathf.Min(14, this.Intelligence - 29));
            // Strength Level 44-57
            _magicDamage += 5f * Mathf.Max(0, Mathf.Min(14, this.Intelligence - 43));
            // Strength Level 58-71
            _magicDamage += 4f * Mathf.Max(0, Mathf.Min(14, this.Intelligence - 57));
            // Strength Level 72-85
            _magicDamage += 2.5f * Mathf.Max(0, Mathf.Min(14, this.Intelligence - 71));
            // Strength Level 86-99
            _magicDamage += 2f * Mathf.Max(0, Mathf.Min(14, this.Intelligence - 85));

            // Final Magic Damage
            _magicDamage += _equipmentsManager.EquippedMagicDamage;

            return _magicDamage;
        }
    }
    public float MagicPierce
    {
        get
        {
            _magicPierce = 0;
            // Faith Level 1
            _magicPierce += 1f;
            // Faith Level 2-5
            _magicPierce += 1f * Mathf.Max(0, Mathf.Min(4, this.Faith - 1));
            // Faith Level 6-25
            _magicPierce += 1.75f * Mathf.Max(0, Mathf.Min(20, this.Faith - 5));
            // Faith Level 26-40
            _magicPierce += 2f * Mathf.Max(0, Mathf.Min(15, this.Faith - 25));
            // Faith Level 41-60
            _magicPierce += 1.25f * Mathf.Max(0, Mathf.Min(30, this.Faith - 40));
            // Faith Level 71-78
            _magicPierce += 0.75f * Mathf.Max(0, Mathf.Min(8, this.Faith - 70));
            // Faith Level 79-99
            _magicPierce += 0.5f * Mathf.Max(0, Mathf.Min(21, this.Faith - 78));

            // Final Magic Pierce
            _magicPierce += _equipmentsManager.EquippedMagicPierce;

            return _magicPierce;
        }
    }
    public float MagicLifeSteal
    {
        get
        {
            _magicLifeSteal = 0;

            // Arcane + Dexterity Level 2
            _magicLifeSteal += 0.005f;
            // Arcane + Dexterity Level 3-30
            _magicLifeSteal += 0.0025f * Mathf.Max(0, Mathf.Min(28, this.Arcane + this.Faith - 2));
            // Arcane + Dexterity Level 31-50
            _magicLifeSteal += 0.0015f * Mathf.Max(0, Mathf.Min(20, this.Arcane + this.Faith - 30));
            // Arcane + Dexterity Level 51-70
            _magicLifeSteal += 0.001f * Mathf.Max(0, Mathf.Min(20, this.Arcane + this.Faith - 50));
            // Arcane + Dexterity Level 71-120
            _magicLifeSteal += 0.00125f * Mathf.Max(0, Mathf.Min(50, this.Arcane + this.Faith - 70));
            // Arcane + Dexterity Level 121-160
            _magicLifeSteal += 0.00075f * Mathf.Max(0, Mathf.Min(40, this.Arcane + this.Faith - 120));
            // Arcane + Dexterity Level 161-198
            _magicLifeSteal += 0.00025f * Mathf.Max(0, Mathf.Min(38, this.Arcane + this.Faith - 160));

            // Final Magic Life Steal
            _magicLifeSteal += _equipmentsManager.EquippedMagicLifeSteal;

            return _magicLifeSteal;
        }
    }

    private void Start()
    {
        _equipmentsManager = GetComponent<EquipmentsManager>();

        this.Respawn();
    }

    private void FixedUpdate()
    {
        Debug.Log(MaxHP + MaxFP + MoveSpeed + AttackSpeed + PhysicalDamage + PhysicalPierce + PhysicalLifeSteal + PhysicalDefense + MagicDamage + MagicPierce + MagicLifeSteal + MagicDefense); 
    }
}