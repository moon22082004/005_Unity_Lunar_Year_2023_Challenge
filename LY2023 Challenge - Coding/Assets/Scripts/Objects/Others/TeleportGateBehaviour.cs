using UnityEngine;

public class TeleportGateBehaviour : InteractableObjectBehaviour
{
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
        this.IsReadyToInteract = false;

        this.Instruction.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + this.InstructionOffset);
    }

    private void Update() 
    {
        this.Instruction.SetActive(this.IsReadyToInteract);
        this.Instruction.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + this.InstructionOffset);

        if (this.IsReadyToInteract)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                this.ScenesController.LoadOptionalScene((int)_teleportingScene);
            }
        }
    }
}
