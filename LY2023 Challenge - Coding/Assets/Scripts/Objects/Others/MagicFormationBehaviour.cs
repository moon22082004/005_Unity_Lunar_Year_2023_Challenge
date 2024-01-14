using UnityEngine;

public class MagicFormationBehaviour : InteractableObjectBehaviour
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

    public void SetActiveMainPanel(bool value)
    {
        this.MainPanel.SetActive(value);

        if (value)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

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
            if ((Input.GetKeyDown(KeyCode.Return)) && (!GameCanvasManager.Instance.InspectionPanel.activeInHierarchy))
            {
                if (!this.MainPanel.activeInHierarchy)
                {
                    this.SetActiveMainPanel(true);
                }
                else
                {
                    this.SetActiveMainPanel(false);
                }
            }
        }
    }
}
