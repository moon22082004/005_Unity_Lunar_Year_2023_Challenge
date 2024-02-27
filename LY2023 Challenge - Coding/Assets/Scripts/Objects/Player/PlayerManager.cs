using UnityEngine;

namespace LY2023Challenge
{
    public class PlayerManager : MonoBehaviour
    {
        private static PlayerManager _instance;
        public static PlayerManager Instance
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

                if (panels.GetChild(1).gameObject.activeInHierarchy)
                {
                    return true;
                }

                if (panels.GetChild(2).gameObject.activeInHierarchy)
                {
                    return true;
                }

                return false;
            }
        }

        private PlayerController _playerController;
        private PlayerController PlayerController
        {
            get
            {
                if (_playerController == null)
                {
                    _playerController = this.Player.GetComponent<PlayerController>();
                }
                return _playerController;
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
                    this.PlayerController.SetSideDirection(1f);
                }
                else
                {
                    this.PlayerController.SetDownDirection();
                }
            }
            else
            {
                if (attackVector3.x + attackVector3.y <= 0)
                {
                    this.PlayerController.SetSideDirection(-1f);
                }
                else
                {
                    this.PlayerController.SetUpDirection();
                }
            }

            return mousePos;
        }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            _instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
    }
}