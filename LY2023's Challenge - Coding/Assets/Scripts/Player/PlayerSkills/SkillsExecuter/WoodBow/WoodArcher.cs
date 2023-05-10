using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WoodArcher : MonoBehaviour
{
    [SerializeField] private WoodBowSkillsExecuter _woodBowSkillsExecuter;
    [SerializeField] private GameObject _eArcherEffect;
    [SerializeField] private GameObject _spaceArcherEffect;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _body;

    private string _typeOfArcher;
    private Vector2 _movement;
    private bool _hit;
    private float _lifeTime = 10f;
    private float _lifeTimer;
    private float _startPosYOfRSkill;
    private float _damage;

    public string TypeOfArcher
    {
        get => this._typeOfArcher;
        set => this._typeOfArcher = value;
    }

    private void Awake() 
    {
        this._boxCollider2D = GetComponent<BoxCollider2D>();
        this._body = GetComponent<Rigidbody2D>();

        this._woodBowSkillsExecuter = GameObject.Find("Player/Character").GetComponent<WoodBowSkillsExecuter>();
        this._eArcherEffect = this.transform.GetChild(0).gameObject;
        this._spaceArcherEffect = this.transform.GetChild(1).gameObject;
    }

    private void FixedUpdate()
    {
        switch (this._typeOfArcher)
        {
            case "R Skill":
            {
                this._boxCollider2D.isTrigger = true;

                if ( this.transform.position.y <= this._startPosYOfRSkill - 5 )
                {
                    this.gameObject.SetActive(false);
                    return;
                }

                this._body.velocity = this._movement;

                break;
            }
            case "E Skill":
            {
                this._boxCollider2D.isTrigger = true;

                if (this._hit)
                {
                    return;
                }

                this._body.velocity = this._movement;

                this._lifeTimer += Time.fixedDeltaTime;
                if (this._lifeTimer > this._lifeTime)
                {
                    this.gameObject.SetActive(false);
                }

                break;
            }
            default:
            {
                this._boxCollider2D.isTrigger = false;

                if (this._hit)
                {
                    return;
                }

                this._body.velocity = this._movement;

                this._lifeTimer += Time.fixedDeltaTime;
                if (this._lifeTimer > this._lifeTime)
                { 
                    this.gameObject.SetActive(false);
                }

                break;
            }
        }
    }

    public void SetUpNormalWoodArcher(Vector3 projectilesPointPos, Vector3 mousePos, float lifeTime, float speed, string typeOfArcher, float damage)
    {
        this._typeOfArcher = typeOfArcher;
        this._hit = false;
        this._lifeTimer = 0;
        this._damage = damage;

        this.gameObject.SetActive(true);
        switch (this._typeOfArcher)
        {
            case "Normal Attack":
            {
                this.transform.localScale = new Vector3(1, 1, 1);
                this._eArcherEffect.SetActive(false);
                this._spaceArcherEffect.SetActive(false);
                break;
            }
            case "E Skill":
            {
                this.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                this._eArcherEffect.SetActive(true);
                this._spaceArcherEffect.SetActive(false);
                break;
            }
            case "Space Skill":
            {
                this.transform.localScale = new Vector3(2f, 2f, 2f);
                this._eArcherEffect.SetActive(false);
                this._spaceArcherEffect.SetActive(true);
                break;                
            }
        }

        Vector3 attackVector3 = new Vector3(mousePos.x - projectilesPointPos.x, mousePos.y - projectilesPointPos.y, mousePos.z - projectilesPointPos.z);

        this._movement = new Vector2(attackVector3.x, attackVector3.y);
        this._movement = new Vector2(this._movement.x / this._movement.magnitude * speed, this._movement.y / this._movement.magnitude * speed);
        this._lifeTime = lifeTime;

        this.transform.position = projectilesPointPos;
        float angle = Vector2.Angle(new Vector2(-1, 0), new Vector2(attackVector3.x, attackVector3.y));
        if ( attackVector3.y >= 0 )
        {
            angle = -1 * angle;
        }

        this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);
    }

    public void SetUpRWoodArcher(Vector3 mousePos, float radius, string typeOfArcher, float damage)
    {
        this._typeOfArcher = typeOfArcher;
        this._damage = damage;
        this._lifeTimer = 0;

        this._movement = new Vector2(0, -6f);

        this._startPosYOfRSkill = Random.Range(mousePos.y - radius, mousePos.y + radius) + 5;
        this.transform.position = new Vector3(Random.Range(mousePos.x - radius, mousePos.x + radius), this._startPosYOfRSkill, mousePos.z);
        this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 90f);
        this.transform.localScale = new Vector3(1, 1, 1);

        this.gameObject.SetActive(true);
        this._eArcherEffect.SetActive(false);
        this._spaceArcherEffect.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if ( collision.gameObject.tag != "Player" )
        {
            if ( (collision.gameObject.tag == "Enemy") && (!this._boxCollider2D.isTrigger) )
            {
                collision.gameObject.GetComponent<AttributesManager>().TakeDamage(this._damage);
            }

            switch (this._typeOfArcher)
            {
                case "Normal Attack":
                {
                    this._hit = true;
                    this.gameObject.SetActive(false);
                    break;
                }
                case "Space Skill":
                {
                    if ( !this._woodBowSkillsExecuter.IsUsedSpaceSkill )
                    {
                        this._woodBowSkillsExecuter.SetUpSpaceWoodArcherEffect(this.transform.position + new Vector3(this._movement.x * 0.05f, this._movement.y * 0.05f, 0));
                    }
                    this.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if ( (collider.tag == "Enemy") && (this._boxCollider2D.isTrigger) )
        {
            collider.GetComponent<AttributesManager>().TakeDamage(this._damage);
        }
    }
}