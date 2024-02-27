using UnityEngine;

namespace LY2023Challenge
{
    public class TeleportGatewayController : InteractableObjectController
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

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();

            if (this.IsReadyToInteract)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    this.ScenesController.LoadOptionalScene((int)_teleportingScene);
                }
            }
        }
    }
}
