using UnityEngine;

public class TeleportGateBehaviour : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D _polygonCollider;
    private PolygonCollider2D PolygonCollider2D
    { 
        get 
        { 
            if (_polygonCollider == null)
            {
                _polygonCollider = GetComponent<PolygonCollider2D>();
            }

            return _polygonCollider; 
        }
    }

    [SerializeField] private GameObject _teleportInstruction;
    private GameObject TeleportInstruction
    {
        get 
        { 
            if (_teleportInstruction == null)
            {
                _teleportInstruction = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
            }

            return _teleportInstruction;
        }
    }

    [SerializeField] private bool _isReadyToTeleport;
    [SerializeField] private Vector3 _teleportInstructionOffset;

    [Header("Scenes Controller")]
    [SerializeField] private ScenesController _scenesController;
    public ScenesController ScenesController
    {
        get 
        {
            if (_scenesController == null)
            {
                _scenesController = GameObject.Find("Game Canvas").GetComponent<ScenesController>();
            }

            return _scenesController;
        }
    }

    [SerializeField] private SceneEnumerator _teleportingScene;

    private void Awake()
    {
        _isReadyToTeleport = false;

        this.TeleportInstruction.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + _teleportInstructionOffset);
    }

    private void Update() 
    {
        this.TeleportInstruction.SetActive(_isReadyToTeleport);
        this.TeleportInstruction.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + _teleportInstructionOffset);

        if (_isReadyToTeleport)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                this.ScenesController.LoadOptionalScene((int)_teleportingScene);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isReadyToTeleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isReadyToTeleport = false;
        }
    }
}
