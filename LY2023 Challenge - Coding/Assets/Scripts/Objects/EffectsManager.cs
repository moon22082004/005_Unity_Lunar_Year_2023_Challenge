using System.Collections;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    private AttributesManager _attributesManager;
    private AttributesManager AttributesManager
    {
        get
        {
            if (_attributesManager == null)
            {
                _attributesManager = GetComponent<AttributesManager>();
            }

            return _attributesManager;
        }
    }

    // ---------------------------------------------------------------------------------------------------------------
    [Header("Decrease Move Speed")]
    [SerializeField] private GameObject _weakenEffect;
    private GameObject WeakenEffect
    {
        get
        {
            if (_weakenEffect == null)
            {
                _weakenEffect = this.transform.Find("Effects").Find("Weaken").gameObject;
            }

            return _weakenEffect;
        }
    }

    [SerializeField] private bool _isDecresedMoveSpeed;
    public bool IsDecreasedMoveSpeed => _isDecresedMoveSpeed;
    public void DecreaseMoveSpeed(float value, float time)
    {
        StartCoroutine(this.DecreaseMoveSpeedCoroutine(value, time));
    }
    private IEnumerator DecreaseMoveSpeedCoroutine(float value, float time)
    {
        this.WeakenEffect.SetActive(true);
        _isDecresedMoveSpeed = true;

        float initialValue = this.AttributesManager.BonusMoveSpeed;
        this.AttributesManager.BonusMoveSpeed = Mathf.Clamp(this.AttributesManager.BonusMoveSpeed - value, 0.001f, value);

        yield return new WaitForSeconds(time);

        this.AttributesManager.BonusMoveSpeed = initialValue;
        _isDecresedMoveSpeed = false;
        this.WeakenEffect.SetActive(false);
    }

    // ---------------------------------------------------------------------------------------------------------------
    [Header("Lock Movement")]
    [SerializeField] private GameObject _stunEffect;
    private GameObject StunEffect
    {
        get
        {
            if (_stunEffect == null)
            {
                _stunEffect = this.transform.Find("Effects").Find("Stun").gameObject;
            }

            return _stunEffect;
        }
    }
    [SerializeField] private GameObject _freezeEffect;
    private GameObject FreezeEffect
    {
        get
        {
            if (_freezeEffect == null)
            {
                _freezeEffect = this.transform.Find("Effects").Find("Freeze").gameObject;
            }

            return _freezeEffect;
        }
    }

    [SerializeField] private bool _isLockedMovement;
    public bool IsLockedMovement => _isLockedMovement;
    public void LockMovement(float time, LockMovementType type)
    {
        StartCoroutine(this.LockMovementCoroutine(time, type));
    }
    private IEnumerator LockMovementCoroutine(float time, LockMovementType type)
    {
        GameObject effect = this.StunEffect;
        switch (type)
        {
            case LockMovementType.Stun:
                effect = this.StunEffect;
                break;
            case LockMovementType.Freeze:
                effect = this.FreezeEffect; 
                break;
        }

        effect.SetActive(true);
        _isLockedMovement = true;
        this.AttributesManager.IsLockedMovement = true;

        yield return new WaitForSeconds(time);

        this.AttributesManager.IsLockedMovement = false;
        _isLockedMovement = false;
        effect.SetActive(false);
    }

    // ---------------------------------------------------------------------------------------------------------------
    [Header("Knock Back")]
    [SerializeField] private bool _isKnockedBack;
    public bool IsKnockedBack => _isKnockedBack;
    public void KnockBack(Vector2 direction, float power, float time)
    {
        if (!this.IsKnockedBack)
        {
            StartCoroutine(this.KnockBackCoroutine(direction, power, time));
        }
    }
    private IEnumerator KnockBackCoroutine(Vector2 direction, float power, float time)
    {
        _isKnockedBack = true;

        Rigidbody2D body = this.GetComponent<Rigidbody2D>();
        Vector2 knockBackDirection = new Vector2(direction.x / direction.magnitude * power, direction.y / direction.magnitude * power);
        body.velocity += knockBackDirection;

        yield return new WaitForSeconds(time);

        body.velocity -= knockBackDirection;
        _isKnockedBack = false;

    }
}

public enum LockMovementType
{
    Lock,
    Stun,
    Freeze
}