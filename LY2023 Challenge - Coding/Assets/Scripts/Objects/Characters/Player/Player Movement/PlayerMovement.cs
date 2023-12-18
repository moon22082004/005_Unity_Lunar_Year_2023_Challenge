using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player's Attributes")]
    private AttributesManager _playerAttributes;
    public AttributesManager PlayerAttributes
    {
        get
        {
            if (_playerAttributes == null)
            {
                _playerAttributes = GetComponent<AttributesManager>();
            }

            return _playerAttributes; 
        }
    }

    private bool _isRun = false;
    private bool _isAttacked = false;
    private bool _canMoveNormally = true;

    private string _direction = "Down";
    public string Direction
    {
        get => _direction;
    }
    public string AnimationDirection
    {
        get
        {
            if ((this.Direction == "Down") || (this.Direction == "Up"))
            {
                return this.Direction;
            }

            return "Side";
        }
    }

    public bool IsRun 
    {
        get => _isRun;
        set => _isRun = value;
    }
    public bool IsAttacked
    {
        get => _isAttacked;
        set => _isAttacked = value;
    }
    public bool CanMoveNormally
    {
        get => _canMoveNormally;
        set => _canMoveNormally = value;
    }

    private Rigidbody2D _body;
    public Rigidbody2D Body
    {
        get 
        { 
            if (_body == null) 
            {
                _body = GetComponent<Rigidbody2D>();
            }

            return _body; 
        }
    }
    private Vector2 _movement;

    private void Awake() 
    {
    }

    private void Update() 
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (!this.IsAttacked)
        {
            if (_movement.x != 0)
            {
                this.SetSideDirection(_movement.x);
            }
            else if (_movement.y > 0.01f)
            {
                this.SetUpDirection();
            }
            else if (_movement.y < -0.01f)
            {
                this.SetDownDirection();
            }

            if (_movement == Vector2.zero)
            {
                this.HelmAnimator.Play($"{this.AnimationDirection}_Idle");
                this.ArmorAnimator.Play($"{this.AnimationDirection}_Idle");
            }
            else
            {
                if (!this.IsRun)
                {
                    this.HelmAnimator.Play($"{this.AnimationDirection}_Walk");
                    this.ArmorAnimator.Play($"{this.AnimationDirection}_Walk");
                }
                else
                {
                    this.HelmAnimator.Play($"{this.AnimationDirection}_Run");
                    this.ArmorAnimator.Play($"{this.AnimationDirection}_Run");
                }
            }
        }
        else
        {
            this.HelmAnimator.Play($"{this.AnimationDirection}_Bow");
            this.ArmorAnimator.Play($"{this.AnimationDirection}_Bow");
        }
    }

    private void FixedUpdate() 
    {   
        if (this.CanMoveNormally)
        {
            this.Body.MovePosition(this.Body.position + _movement * this.PlayerAttributes.MoveSpeed * Time.fixedDeltaTime);
        }
    }

    public void SetSideDirection(float horizontalValue)
    {
        this.transform.localScale = new Vector3(Mathf.Sign(horizontalValue) * -1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        this.HelmAnimator.SetInteger("Direction", 1);
        this.ArmorAnimator.SetInteger("Direction", 1);

        if (horizontalValue > 0)
        {
            _direction = "Right";
        }
        else
        {
            _direction = "Left";
        }
    }

    public void SetDownDirection()
    {
        this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        this.HelmAnimator.SetInteger("Direction", 0);
        this.ArmorAnimator.SetInteger("Direction", 0);

        _direction = "Down";
    }

    public void SetUpDirection()
    {
        this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        this.HelmAnimator.SetInteger("Direction", 2);
        this.ArmorAnimator.SetInteger("Direction", 2);

        _direction = "Up";
    }

    [SerializeField] private RuntimeAnimatorController _helmAnimationController;
    public RuntimeAnimatorController HelmAnimationController
    {
        get
        { 
            _helmAnimationController = this.AnimationsMap(this.GetComponent<EquipmentsManager>().Helm.Name);

            return _helmAnimationController; 
        }
    }

    [SerializeField] private Animator _helmAnimator;
    public Animator HelmAnimator
    {
        get
        {
            if (_helmAnimator == null)
            {
                _helmAnimator = this.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
            }

            _helmAnimator.runtimeAnimatorController = this.HelmAnimationController;

            return _helmAnimator;
        }
    }

    [SerializeField] private RuntimeAnimatorController _armorAnimationController;
    public RuntimeAnimatorController ArmorAnimationController
    {
        get
        {
            _armorAnimationController = this.AnimationsMap(this.GetComponent<EquipmentsManager>().Armor.Name);

            return _armorAnimationController;
        }
    }
    public RuntimeAnimatorController AnimationsMap(string skinName)
    {
        return Resources.Load<RuntimeAnimatorController>($"Animations/Characters/{skinName}/{skinName}");
    }

    [SerializeField] private Animator _armorAnimator;
    public Animator ArmorAnimator
    {
        get
        {
            if (_armorAnimator == null)
            {
                _armorAnimator = this.transform.GetChild(0).GetChild(1).GetComponent<Animator>();
            }

            _armorAnimator.runtimeAnimatorController = this.ArmorAnimationController;

            return _armorAnimator;
        }
    }
}