using UnityEngine;

namespace LY2023Challenge
{
    public class MagicFormationController : InteractableObjectController
    {
        [SerializeField] private GameObject _mainPanel;
        public GameObject MainPanel
        {
            get
            {
                if (_mainPanel == null)
                {
                    _mainPanel = GameObject.Find("Game Canvas/Panels/Magic Formation Panel");
                }

                return _mainPanel;
            }
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();

            if (this.IsReadyToInteract)
            {
                if ((Input.GetKeyDown(KeyCode.Return)) && (GameCanvasManager.Instance.OtherPanelsIsNotActive(PanelType.MAGIC_FORMATION_PANEL)))
                {
                    if (!this.MainPanel.activeInHierarchy)
                    {
                        GameCanvasManager.Instance.SetActiveMagicFormationPanel(true);
                    }
                }
            }
        }
    }
}