using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESyctheEffect : MonoBehaviour
{
    /*
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed;
    private float damage;
    private Vector3 targetPos;
    private Vector3 direction;
    private float lifeTime = 0;

    private void FixedUpdate() 
    {
        if ( this.gameObject.activeInHierarchy )
        {
            this.transform.position -= this.direction;
            
            Vector2 _direction = new Vector2(this.transform.position.x - this.targetPos.x, this.transform.position.y - this.targetPos.y);
            this.direction = new Vector3((_direction.x / _direction.magnitude) * this.speed, (_direction.y / _direction.magnitude) * this.speed, 0);

            this.lifeTime += Time.deltaTime;
            if ( this.lifeTime > (0.75f) )
                this.gameObject.SetActive(false);
        }
    }

    public void SetUpEffect(Vector3 _position, Transform _targetTransfrom, float _damage)
    {
        this.lifeTime = 0;
        this.gameObject.SetActive(true);

        this.transform.position = _position;
        this.targetPos = _targetTransfrom.position;
        Vector2 _direction = new Vector2(this.transform.position.x - this.targetPos.x, this.transform.position.y - this.targetPos.y);
        this.direction = new Vector3((_direction.x / _direction.magnitude) * this.speed, (_direction.y / _direction.magnitude) * this.speed, 0);

        float _angle = Vector2.Angle(new Vector2(1, 0), new Vector2(-direction.x, -direction.y));
        if ( -direction.y >= 0 )
            _angle = -1 * _angle;

        this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, _angle);

        this.gameObject.GetComponent<Animator>().Play("DeathSycthe E", -1, 0);

        this.damage = _damage;
    }

    private void OnTriggerEnter2D(Collider2D _collider) 
    {
        if ( _collider.tag == "Enemy" )
        {
            this.playerTransform.position = this.transform.position;
            _collider.GetComponent<HealthSystem>().TakeDamage(this.damage);
            this.gameObject.SetActive(false);
        }    
    }
    */
}
