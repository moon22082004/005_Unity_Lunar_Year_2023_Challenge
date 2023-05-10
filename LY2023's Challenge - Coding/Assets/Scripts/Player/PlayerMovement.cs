using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player's Attributes")]
    [SerializeField] private string _typeOfPlayer;
    private string _direction = "Down";
    [SerializeField] private float _moveSpeed = 3f;
    private bool _isRun = false;
    private bool _isAttacked = false;
    private bool _canMoveNormally = true;

    public string Direction
    {
        get => this._direction;
    }
    public float MoveSpeed
    {
        get => this._moveSpeed;
        set => this._moveSpeed = value;
    }
    public bool IsRun 
    {
        get => this._isRun;
        set => this._isRun = value;
    }
    public bool IsAttacked
    {
        get => this._isAttacked;
        set => this._isAttacked = value;
    }
    public bool CanMoveNormally
    {
        get => this._canMoveNormally;
        set => this._canMoveNormally = value;
    }

    [Header ("Animation")]  
    [SerializeField] private GameObject _idles;
    [SerializeField] private GameObject _walks;
    [SerializeField] private GameObject _runs;
    [SerializeField] private GameObject _woodBows;
    [SerializeField] private GameObject _shortSwords;
    [SerializeField] private GameObject _shortGuns;
    [SerializeField] private GameObject _rifles;
    [SerializeField] private GameObject _sycthes;
    [SerializeField] private GameObject _beastHammers;

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
        get => this._woodBow;
    }
    public AnimationHolder ShortSword
    {
        get => this._shortSword;
    }
    public AnimationHolder ShortGun
    {
        get => this._shortGun;
    }
    public AnimationHolder Rifle
    {
        get => this._rifle;
    }
    public AnimationHolder BeastHammer
    {
        get => this._beastHammer;
    }

    private Rigidbody2D _body;
    private Vector2 _movement;

    private void Awake() 
    {
        this._body = GetComponent<Rigidbody2D>();

        this.GetTypesOfAnimationsOfPlayer();
    }

    private void Update() 
    {
        this._movement.x = Input.GetAxisRaw("Horizontal");
        this._movement.y = Input.GetAxisRaw("Vertical");

        if ( !this.IsAttacked )
        {
            if (this._movement.x != 0 )
            {
                this.SetSideDirection(this._movement.x);
            }
            else if ( this._movement.y > 0.01f )
            {
                this.SetUpDirection();
            }
            else if ( this._movement.y < -0.01f )
            {
                this.SetDownDirection();
            }

            if ( this._movement == Vector2.zero )
            {
                this._idle.ParentAnimation.SetActive(true);
                this._walk.ParentAnimation.SetActive(false);
                this._run.ParentAnimation.SetActive(false);
            }
            else
            {
                if ( !this.IsRun )
                {
                    this._idle.ParentAnimation.SetActive(false);
                    this._walk.ParentAnimation.SetActive(true);
                    this._run.ParentAnimation.SetActive(false);
                }
                else
                {
                    this._idle.ParentAnimation.SetActive(false);
                    this._walk.ParentAnimation.SetActive(false);
                    this._run.ParentAnimation.SetActive(true);                
                }
            }
        }
        else
        {
            this._idle.ParentAnimation.SetActive(false);
            this._walk.ParentAnimation.SetActive(false);
            this._run.ParentAnimation.SetActive(false);
        }
    }

    private void FixedUpdate() 
    {   
        if ( this.CanMoveNormally )
        {
            this._body.MovePosition(this._body.position + this._movement * this.MoveSpeed * Time.fixedDeltaTime);
        }
    }

    private void GetTypesOfAnimationsOfPlayer()
    {
        GameObject pCharacterAnimation = GameObject.Find("Player/Character/Animations");
        this._idles = pCharacterAnimation.transform.GetChild(1).gameObject;
        this._walks = pCharacterAnimation.transform.GetChild(2).gameObject;
        this._runs = pCharacterAnimation.transform.GetChild(3).gameObject;
        this._woodBows = pCharacterAnimation.transform.GetChild(4).gameObject;
        this._shortSwords = pCharacterAnimation.transform.GetChild(5).gameObject;
        this._shortGuns = pCharacterAnimation.transform.GetChild(6).gameObject;
        this._rifles = pCharacterAnimation.transform.GetChild(7).gameObject;
        this._sycthes = pCharacterAnimation.transform.GetChild(8).gameObject;
        this._beastHammers = pCharacterAnimation.transform.GetChild(9).gameObject;

        this.GetAnimationsOfPlayer();
    }

    private void GetAnimationsOfPlayer()
    {
        this._idle = new AnimationHolder(this._idles.transform.GetChild(FindActiveAnimation(this._idles)).gameObject);
        this._walk = new AnimationHolder(this._walks.transform.GetChild(FindActiveAnimation(this._walks)).gameObject);
        this._run = new AnimationHolder(this._runs.transform.GetChild(FindActiveAnimation(this._runs)).gameObject);
        this._woodBow = new AnimationHolder(this._woodBows.transform.GetChild(FindActiveAnimation(this._woodBows)).gameObject);
        this._shortSword = new AnimationHolder(this._shortSwords.transform.GetChild(FindActiveAnimation(this._shortSwords)).gameObject);
        this._shortGun = new AnimationHolder(this._shortGuns.transform.GetChild(FindActiveAnimation(this._shortGuns)).gameObject);
        this._rifle = new AnimationHolder(this._rifles.transform.GetChild(FindActiveAnimation(this._rifles)).gameObject);
        this._sycthe = new AnimationHolder(this._sycthes.transform.GetChild(FindActiveAnimation(this._sycthes)).gameObject);
        this._beastHammer = new AnimationHolder(this._beastHammers.transform.GetChild(FindActiveAnimation(this._beastHammers)).gameObject); 

        this._idle.ParentAnimation.SetActive(true);
    }

    private int FindActiveAnimation(GameObject aniGameObject)
    {
        for (int i = 0; i < aniGameObject.transform.childCount; i++)
        {
            if ( aniGameObject.transform.GetChild(i).gameObject.tag != this._typeOfPlayer )
            {
                aniGameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < aniGameObject.transform.childCount; i++)
        {
            if ( aniGameObject.transform.GetChild(i).gameObject.tag == this._typeOfPlayer )
            {
                return i;
            }
        }
        return 0;
    }

    public void SetSideDirection(float horizontalValue)
    {
        this.transform.localScale = new Vector3(Mathf.Sign(horizontalValue) * -1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        this._idle.SetSideDirection();
        this._walk.SetSideDirection();
        this._run.SetSideDirection();
        this._woodBow.SetSideDirection();
        this._shortSword.SetSideDirection();
        this._shortGun.SetSideDirection();
        this._rifle.SetSideDirection();
        this._sycthe.SetSideDirection();
        this._beastHammer.SetSideDirection();

        if ( horizontalValue > 0 )
        {
            this._direction = "Right";
        }
        else
        {
            this._direction = "Left";
        }
    }

    public void SetDownDirection()
    {
        this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        this._idle.SetDownDirection();
        this._walk.SetDownDirection();
        this._run.SetDownDirection();
        this._woodBow.SetDownDirection();
        this._shortSword.SetDownDirection();
        this._shortGun.SetDownDirection();
        this._rifle.SetDownDirection();
        this._sycthe.SetDownDirection();
        this._beastHammer.SetDownDirection();

        this._direction = "Down";
    }

    public void SetUpDirection()
    {
        this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        this._idle.SetUpDirection();
        this._walk.SetUpDirection();
        this._run.SetUpDirection();
        this._woodBow.SetUpDirection();
        this._shortSword.SetUpDirection();
        this._shortGun.SetUpDirection();
        this._rifle.SetUpDirection();
        this._sycthe.SetUpDirection();
        this._beastHammer.SetUpDirection();

        this._direction = "Up";    
    }
}