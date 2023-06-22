using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player's Attributes")]
    private AttributesManager _playerAttributes;
    [SerializeField] private GameObject _playerAnimation;
    private string _direction = "Down";
    private bool _isRun = false;
    private bool _isAttacked = false;
    private bool _canMoveNormally = true;

    public string Direction
    {
        get => _direction;
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

    private AnimationHolder _idle;
    private AnimationHolder _walk;
    private AnimationHolder _run;
    private AnimationHolder _woodBow;
    private AnimationHolder _shortSword;
    private AnimationHolder _shortGun;
    private AnimationHolder _rifle;
    private AnimationHolder _sycthe;
    private AnimationHolder _beastHammer;

    public AnimationHolder WoodBow
    {
        get => _woodBow;
    }
    public AnimationHolder ShortSword
    {
        get => _shortSword;
    }
    public AnimationHolder ShortGun
    {
        get => _shortGun;
    }
    public AnimationHolder Rifle
    {
        get => _rifle;
    }
    public AnimationHolder BeastHammer
    {
        get => _beastHammer;
    }

    private Rigidbody2D _body;
    private Vector2 _movement;

    private void Awake() 
    {
        _body = GetComponent<Rigidbody2D>();
        _playerAttributes = GetComponent<AttributesManager>();

        _playerAnimation.SetActive(true);
        this.GetAnimationsOfPlayer();
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
                _idle.ParentAnimation.SetActive(true);
                _walk.ParentAnimation.SetActive(false);
                _run.ParentAnimation.SetActive(false);
            }
            else
            {
                if (!this.IsRun)
                {
                    _idle.ParentAnimation.SetActive(false);
                    _walk.ParentAnimation.SetActive(true);
                    _run.ParentAnimation.SetActive(false);
                }
                else
                {
                    _idle.ParentAnimation.SetActive(false);
                    _walk.ParentAnimation.SetActive(false);
                    _run.ParentAnimation.SetActive(true);                
                }
            }
        }
        else
        {
            _idle.ParentAnimation.SetActive(false);
            _walk.ParentAnimation.SetActive(false);
            _run.ParentAnimation.SetActive(false);
        }
    }

    private void FixedUpdate() 
    {   
        if (this.CanMoveNormally)
        {
            _body.MovePosition(_body.position + _movement * _playerAttributes.MoveSpeed * Time.fixedDeltaTime);
        }
    }

    private void GetAnimationsOfPlayer()
    {
        _idle = new AnimationHolder(_playerAnimation.transform.GetChild(0).gameObject);
        _walk = new AnimationHolder(_playerAnimation.transform.GetChild(1).gameObject);
        _run = new AnimationHolder(_playerAnimation.transform.GetChild(2).gameObject);
        _woodBow = new AnimationHolder(_playerAnimation.transform.GetChild(3).gameObject);
        _shortSword = new AnimationHolder(_playerAnimation.transform.GetChild(4).gameObject);
        _shortGun = new AnimationHolder(_playerAnimation.transform.GetChild(5).gameObject);
        _rifle = new AnimationHolder(_playerAnimation.transform.GetChild(6).gameObject);
        _sycthe = new AnimationHolder(_playerAnimation.transform.GetChild(7).gameObject);
        _beastHammer = new AnimationHolder(_playerAnimation.transform.GetChild(8).gameObject);

        _idle.ParentAnimation.SetActive(true);
    }

    public void SetSideDirection(float horizontalValue)
    {
        this.transform.localScale = new Vector3(Mathf.Sign(horizontalValue) * -1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        _idle.SetSideDirection();
        _walk.SetSideDirection();
        _run.SetSideDirection();
        _woodBow.SetSideDirection();
        _shortSword.SetSideDirection();
        _shortGun.SetSideDirection();
        _rifle.SetSideDirection();
        _sycthe.SetSideDirection();
        _beastHammer.SetSideDirection();

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

        _idle.SetDownDirection();
        _walk.SetDownDirection();
        _run.SetDownDirection();
        _woodBow.SetDownDirection();
        _shortSword.SetDownDirection();
        _shortGun.SetDownDirection();
        _rifle.SetDownDirection();
        _sycthe.SetDownDirection();
        _beastHammer.SetDownDirection();

        _direction = "Down";
    }

    public void SetUpDirection()
    {
        this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        _idle.SetUpDirection();
        _walk.SetUpDirection();
        _run.SetUpDirection();
        _woodBow.SetUpDirection();
        _shortSword.SetUpDirection();
        _shortGun.SetUpDirection();
        _rifle.SetUpDirection();
        _sycthe.SetUpDirection();
        _beastHammer.SetUpDirection();

        _direction = "Up";    
    }
}