using System.Collections.Generic;
using UnityEngine;

public class LunarMonoBehaviour : MonoBehaviour
{
    private static LunarMonoBehaviour _instance;
    public static LunarMonoBehaviour Instance
    {
        get => _instance;
    }

    private GameObject _player;
    public GameObject Player
    {
        get
        {
            if (_player == null)
            {
                _player = GameObject.Find("Player/Character");
            }

            return _player;
        }
    }
    public bool IsPausedGame
    {
        get 
        {
            Transform panels = GameObject.Find("Game Canvas/Panels").transform;
            for (int i = 0; i < panels.childCount; i++) 
            {
                if (panels.GetChild(i).gameObject.activeInHierarchy)
                {
                    return true;
                }
            }
            return false;
        }
    }

    private PlayerMovement _pMovement;
    private PlayerMovement PlayerMovement
    {
        get
        {
            if (_pMovement == null)
            {
                _pMovement = this.Player.GetComponent<PlayerMovement>();
            }
            return _pMovement;
        }
    }

    private Transform _projectilesDownPointTransform;
    private Transform _projectilesHorizontalPointTransform;
    private Transform _projectilesUpPointTransform;
    private Transform _projectilesAlternativePointTransform;
    public Vector3[] ProjectilesPositions
    {
        get
        {
            if (_projectilesDownPointTransform == null)
            {
                _projectilesDownPointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Down Point").transform;
            }
            if (_projectilesHorizontalPointTransform == null)
            {
                _projectilesHorizontalPointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Horizontal Point").transform;
            }
            if (_projectilesUpPointTransform == null)
            {
                _projectilesUpPointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Up Point").transform;
            }
            if (_projectilesAlternativePointTransform == null)
            {
                _projectilesAlternativePointTransform = GameObject.Find("Player/Character/Projectiles Points/Projectiles Alternative Point").transform;
            }

            return new Vector3[] { _projectilesDownPointTransform.position, _projectilesUpPointTransform.position, _projectilesHorizontalPointTransform.position, _projectilesAlternativePointTransform.position };
        }
    }

    public Vector3 GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 attackVector3 = new Vector3(mousePos.x - this.ProjectilesPositions[3].x, mousePos.y - this.ProjectilesPositions[3].y, mousePos.z - this.ProjectilesPositions[3].z);
        if (attackVector3.x >= attackVector3.y)
        {
            if (attackVector3.x + attackVector3.y >= 0)
            {
                this.PlayerMovement.SetSideDirection(1f);
            }
            else
            {
                this.PlayerMovement.SetDownDirection();
            }
        }
        else
        {
            if (attackVector3.x + attackVector3.y <= 0)
            {
                this.PlayerMovement.SetSideDirection(-1f);
            }
            else
            {
                this.PlayerMovement.SetUpDirection();
            }
        }

        return mousePos;
    }

    private void Awake()
    {
        _instance = this;
    }
}