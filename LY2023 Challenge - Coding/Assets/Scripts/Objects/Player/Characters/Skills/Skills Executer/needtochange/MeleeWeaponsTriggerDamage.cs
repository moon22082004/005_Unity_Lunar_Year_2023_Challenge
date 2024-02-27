using UnityEngine;


public class MeleeWeaponsTriggerDamage : MonoBehaviour
{
    private PolygonCollider2D _polygonCollider2D;
    [SerializeField] private float _offsetSpeed = 0.025f;

    private float _damage;

    public float Damage 
    {
        get => this._damage;
        set => this._damage = value;
    }

    private void Start() 
    {
        this._polygonCollider2D = GetComponent<PolygonCollider2D>();    
    }

    private void FixedUpdate() 
    {
        if ( ((this._polygonCollider2D.offset.x >= 0.025) && (this._offsetSpeed >= 0)) || ((this._polygonCollider2D.offset.x <= -0.025) && (this._offsetSpeed <= 0)) )
            this._offsetSpeed *= -1;

        this._polygonCollider2D.offset = new Vector2(this._polygonCollider2D.offset.x + this._offsetSpeed * Time.fixedDeltaTime, this._polygonCollider2D.offset.y + this._offsetSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if ( collider.tag == "Enemy" )
        {
            // collider.GetComponent<AttributesManager>().IncreaseHealth(-this.Damage);
            this._polygonCollider2D.enabled = false;
        }
    }
}