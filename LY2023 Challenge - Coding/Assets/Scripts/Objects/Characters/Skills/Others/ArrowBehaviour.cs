using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private BoxCollider2D BoxCollider2D
    {
        get 
        {
            if (_boxCollider2D == null)
            {
                _boxCollider2D = GetComponent<BoxCollider2D>();
            }

            return _boxCollider2D;
        }
    }
    private Rigidbody2D _body;

    [Header("Arrows Rain Skill")]
    private float _startPosYOfArrowsRainSkill;

    [Header("Breakthrough Arrow Skill")]
    [SerializeField] private GameObject _breakthroughEffect;
    private float _knockbackDistance;

    [Header("Shackles Arrow Skill")]
    [SerializeField] private GameObject _arrowOfShacklesEffect;
    [SerializeField] private ShacklesArrow _shacklesArrowSkill;

    private ArrowType _typeOfArcher;
    public ArrowType TypeOfArcher => _typeOfArcher;

    private float _physicalDamage, _physicalPierce;
    private float _lifeTime, _lifeTimer;
    private bool _isHit;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();

        _breakthroughEffect = this.transform.GetChild(0).gameObject;
        _arrowOfShacklesEffect = this.transform.GetChild(1).gameObject;
    }

    private void FixedUpdate()
    {
        switch (this.TypeOfArcher)
        {
            case ArrowType.RainedArrow:
                if (this.transform.position.y <= _startPosYOfArrowsRainSkill - 5f)
                {
                    Destroy(this.gameObject);
                    //this.gameObject.SetActive(false);
                    return;
                }

                break;
            default:
                _lifeTimer += Time.fixedDeltaTime;
                if (_lifeTimer > _lifeTime)
                {
                    Destroy(this.gameObject);
                    //this.gameObject.SetActive(false);
                    return;
                }
                break;
        }

        if (_isHit)
        {
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);
            return;
        }
    }

    private void SetUp(ArrowType typeOfArcher, float damage, float pierce)
    {
        this.gameObject.SetActive(true);
        _isHit = false;
        _lifeTimer = 0;

        _typeOfArcher = typeOfArcher;

        _physicalDamage = damage;
        _physicalPierce = pierce;
    }

    public void SetUpRainedArrow(Vector3 mousePos, float radius, float damage, float pierce)
    {
        this.BoxCollider2D.isTrigger = true;
        this.SetUp(ArrowType.RainedArrow, damage, pierce);

        Vector2 movement = new Vector2(0f, -6f);
        _body.velocity = movement;
        _startPosYOfArrowsRainSkill = Random.Range(mousePos.y - radius, mousePos.y + radius) + 5f;

        this.transform.position = new Vector3(Random.Range(mousePos.x - radius, mousePos.x + radius), _startPosYOfArrowsRainSkill, mousePos.z);
        this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 90f);
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void SetUpCommonArrow(Vector3 projectilesPointPos, Vector3 destinationPos, float angleOffset, float lifeTime, float speed, ArrowType typeOfArcher, float damage, float pierce)
    {
        this.SetUp(typeOfArcher, damage, pierce);
        _lifeTime = lifeTime;

        Vector3 attackVector3 = new Vector3(destinationPos.x - projectilesPointPos.x, destinationPos.y - projectilesPointPos.y, destinationPos.z - projectilesPointPos.z);
        attackVector3 = Quaternion.AngleAxis(angleOffset, Vector3.forward) * attackVector3;

        Vector2 movement = new Vector2(attackVector3.x, attackVector3.y);
        movement = new Vector2(movement.x / movement.magnitude * speed, movement.y / movement.magnitude * speed);
        _body.velocity = movement;

        this.transform.position = projectilesPointPos;
        float angle = Vector2.Angle(new Vector2(-1f, 0f), movement);
        if (movement.y >= 0f)
        {
            angle = -1 * angle;
        }

        this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);

        switch (typeOfArcher)
        {
            case ArrowType.NormalArrow:
                this.BoxCollider2D.isTrigger = false;

                this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                _breakthroughEffect.SetActive(false);
                _arrowOfShacklesEffect.SetActive(false);
                break;
        }
    }

    public void SetUpBreakthroughArrow(float knockBackDistance, Vector3 projectilesPointPos, Vector3 destinationPos, float lifeTime, float speed, float damage, float pierce)
    {
        _knockbackDistance = knockBackDistance;
        this.SetUpCommonArrow(projectilesPointPos, destinationPos, 0, lifeTime, speed, ArrowType.BreakthroughArrow, damage, pierce);

        this.BoxCollider2D.isTrigger = true;

        this.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        _breakthroughEffect.SetActive(true);
        _arrowOfShacklesEffect.SetActive(false);
    }

    public void SetUpShacklesArrow(ShacklesArrow shacklesArrowSkill, Vector3 projectilesPointPos, Vector3 destinationPos, float lifeTime, float speed, float damage, float pierce)
    {
        _shacklesArrowSkill = shacklesArrowSkill;
        this.SetUpCommonArrow(projectilesPointPos, destinationPos, 0, lifeTime, speed, ArrowType.ShacklesArrow, damage, pierce);

        this.BoxCollider2D.isTrigger = false;

        this.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
        _breakthroughEffect.SetActive(false);
        _arrowOfShacklesEffect.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.tag == "Enemy") && (_boxCollider2D.isTrigger))
        {     
            switch (this.TypeOfArcher)
            {
                case ArrowType.RainedArrow:
                    collider.GetComponent<EffectsManager>().DecreaseMoveSpeed(2f, 3.5f);
                    break;
                case ArrowType.BreakthroughArrow:
                    collider.GetComponent<EffectsManager>().KnockBack(_body.velocity, _knockbackDistance, 0.25f);
                    break;
            }

            collider.GetComponent<AttributesManager>().TakeDamage(LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>(), _physicalDamage, _physicalPierce, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if ((collision.gameObject.tag == "Enemy") && (!this._boxCollider2D.isTrigger))
            {
                collision.gameObject.GetComponent<AttributesManager>().TakeDamage(LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>(), _physicalDamage, _physicalPierce, false);
            }

            switch (_typeOfArcher)
            {
                case ArrowType.ShacklesArrow:
                    _shacklesArrowSkill.SetUpShacklesEffect(this.transform.position);
                    break;
            }

            _isHit = true;
        }
    }
}