using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSyctheSkills : MonoBehaviour
{/*
    private PlayerMovement playerMovement;
    private PlayerSkills playerSkills;

    [Header ("Attack Ranges")]
    [SerializeField] private PolygonCollider2D syctheRangeDown;
    [SerializeField] private PolygonCollider2D syctheRangeHorizontal;
    [SerializeField] private PolygonCollider2D syctheRangeUp;

    [Header ("R Skill")]
    [SerializeField] private GameObject rEffect;

    [Header ("E Skill")]
    [SerializeField] private ESyctheEffect eEffect;

    private void Start() 
    {
        this.playerMovement = GetComponent<PlayerMovement>();
        this.playerSkills = GetComponent<PlayerSkills>();
    }

    public IEnumerator DeathSyctheAttack(float _damage)
    {
        this.playerSkills.normalAttackTimer = 0;

        this.playerMovement.isAttacked = true;
        this.playerMovement.moveSpeed /= 5;
        this.playerMovement.sycthe.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        switch ( this.playerMovement.direction )
        {
            case "Down":
                this.syctheRangeDown.enabled = true;
                this.syctheRangeDown.GetComponent<MeleeWeaponsTriggerDamage>().damage = _damage;
                break;
            case "Up":
                this.syctheRangeUp.enabled = true;
                this.syctheRangeUp.GetComponent<MeleeWeaponsTriggerDamage>().damage = _damage;
                break;
            default:
                this.syctheRangeHorizontal.enabled = true;
                this.syctheRangeHorizontal.GetComponent<MeleeWeaponsTriggerDamage>().damage = _damage;
                break;
        }
        yield return new WaitForSeconds(0.35f);

        this.syctheRangeDown.enabled = false;
        this.syctheRangeHorizontal.enabled = false;
        this.syctheRangeUp.enabled = false;
        
        this.playerMovement.isAttacked = false;
        this.playerMovement.moveSpeed *= 5;
        this.playerMovement.sycthe.SetActive(false);
    }

    public IEnumerator RDeathSycthe(float _damage)
    {
        this.playerSkills.normalAttackTimer = 0;
        this.playerSkills.rTimer = 0;

        this.playerMovement.isAttacked = true;
        this.playerMovement.moveSpeed /= 5;
        this.playerMovement.sycthe.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        this.rEffect.SetActive(true);
        this.rEffect.GetComponent<PolygonCollider2D>().enabled = true;
        switch ( this.playerMovement.direction )
        {
            case "Down":
                this.rEffect.transform.position = this.transform.position + new Vector3(0, 0, 0);
                this.rEffect.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -90f);
                this.rEffect.transform.localScale = new Vector3(-2.5f, 2.5f, 2.5f);
                break;
            case "Up":
                this.rEffect.transform.position = this.transform.position + new Vector3(0, 0, 0);
                this.rEffect.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -90f);
                this.rEffect.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                break;
            case "Right":
                this.rEffect.transform.position = this.transform.position + new Vector3(2.4f, 0.6f, 0);
                this.rEffect.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 180f);
                this.rEffect.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                break;
            case "Left":
                this.rEffect.transform.position = this.transform.position + new Vector3(-2.4f, 0.6f, 0);
                this.rEffect.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 180f);
                this.rEffect.transform.localScale = new Vector3(-2.5f, 2.5f, 2.5f);
                break;
        }
        this.rEffect.GetComponent<MeleeWeaponsTriggerDamage>().damage = _damage;

        yield return new WaitForSeconds(0.35f);
        this.rEffect.GetComponent<PolygonCollider2D>().enabled = false;

        this.playerMovement.isAttacked = false;
        this.playerMovement.moveSpeed *= 5;
        this.playerMovement.sycthe.SetActive(false);

        yield return new WaitForSeconds(0.4f);
        this.rEffect.SetActive(false);
    }

    public IEnumerator EDeathSycthe(float _damage, Transform _targetTransfrom)
    {
        this.playerSkills.normalAttackTimer = 0;
        this.playerSkills.eTimer = 0;

        this.playerMovement.isAttacked = true;
        this.playerMovement.moveSpeed /= 5;
        this.playerMovement.sycthe.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        this.eEffect.SetUpEffect(this.transform.position, _targetTransfrom, _damage);
        yield return new WaitForSeconds(0.35f);

        this.playerMovement.isAttacked = false;
        this.playerMovement.moveSpeed *= 5;
        this.playerMovement.sycthe.SetActive(false);
    }*/
}
