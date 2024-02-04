using UnityEngine;

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
        if ((Input.GetKeyDown(KeyCode.Escape)) && (!this.MagicFormationPanel.activeInHierarchy))
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