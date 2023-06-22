using UnityEngine;

public abstract class SideSkill : Skill
{
    [SerializeField] private GameObject _playerEffect;
    protected GameObject PlayerEffect
    {
        get
        {
            if (_playerEffect == null)
            {
                this.SetUpEffect();
            }

            return _playerEffect;
        }
        set => _playerEffect = value;
    }

    protected abstract void SetUpEffect();
}