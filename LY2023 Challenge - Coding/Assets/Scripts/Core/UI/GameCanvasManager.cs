using UnityEngine;

namespace LY2023Challenge
{
    public class GameCanvasManager : MonoBehaviour
    {
        private static GameCanvasManager _instance;
        public static GameCanvasManager Instance
        {
            get => _instance;
        }

        // INSPECTION PANEL
        [SerializeField] private GameObject _inspectionPanel;
        public GameObject InspectionPanel
        {
            get
            {
                if (_inspectionPanel == null)
                {
                    _inspectionPanel = GameObject.Find("Game Canvas/Panels/Inspection Panel");
                }

                return _inspectionPanel;
            }
        }

        public void SetActiveInspectionPanel(bool value)
        {
            this.InspectionPanel.SetActive(value);

            if (value)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        // MAGIC FORMATION
        [SerializeField] private GameObject _magicFormationPanel;
        public GameObject MagicFormationPanel
        {
            get
            {
                if (_magicFormationPanel == null)
                {
                    _magicFormationPanel = GameObject.Find("Game Canvas/Panels/Magic Formation Panel");
                }

                return _magicFormationPanel;
            }
        }

        public void SetActiveMagicFormationPanel(bool value)
        {
            this.MagicFormationPanel.SetActive(value);

            if (value)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        // NPC
        [SerializeField] private GameObject _npcPanel;
        public GameObject NpcPanel
        {
            get
            {
                if (_npcPanel == null)
                {
                    _npcPanel = GameObject.Find("Game Canvas/Panels/NPC Panel");
                }

                return _npcPanel;
            }
        }

        public void SetActiveNpcPanel(bool value)
        {
            this.NpcPanel.SetActive(value);

            if (value)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public bool OtherPanelsIsNotActive(PanelType panelType)
        {
            switch (panelType)
            {
                case PanelType.INSPECTION_PANEL:
                    return ((!this.MagicFormationPanel.activeInHierarchy) && (!this.NpcPanel.activeInHierarchy));
                case PanelType.MAGIC_FORMATION_PANEL:
                    return ((!this.InspectionPanel.activeInHierarchy) && (!this.NpcPanel.activeInHierarchy));
                case PanelType.NPC_PANEL:
                    return ((!this.InspectionPanel.activeInHierarchy) && (!this.MagicFormationPanel.activeInHierarchy));
                default:
                    return false;
            }
        }

        // SAVE AND EXIT
        public void SaveAndExit()
        {
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

        private void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Escape)) && (this.OtherPanelsIsNotActive(PanelType.INSPECTION_PANEL)))
            {
                if (!this.InspectionPanel.activeInHierarchy)
                {
                    this.SetActiveInspectionPanel(true);
                }
                else
                {
                    this.SetActiveInspectionPanel(false);
                }
            }
        }
    }
}