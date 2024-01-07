using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    private static GameCanvasManager _instance;
    public static GameCanvasManager Instance
    {
        get => _instance;
    }

    // PLAYER PANEL
    [SerializeField] private GameObject _playerPanel;
    private GameObject PlayerPanel
    {
        get 
        {
            if (_playerPanel == null) 
            {
                _playerPanel = GameObject.Find("Game Canvas/Panels/Player Panel");
            }

            return _playerPanel;
        }
    }

    [SerializeField] private GameObject _playerPanelButton;
    private GameObject PlayerPanelButton
    {
        get
        {
            if (_playerPanelButton == null)
            {
                _playerPanelButton = GameObject.Find("Game Canvas/Buttons/Player Panel Button");
            }

            return _playerPanelButton;
        }
    }

    public void SetActivePlayerPanel(bool value)
    {
        this.PlayerPanel.SetActive(value);
        this.PlayerPanelButton.GetComponent<Button>().interactable = !value;

        if (value) 
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }    
    }

    // GENERAL PANEL
    [SerializeField] private GameObject _generalPanel;
    public GameObject GeneralPanel
    {
        get
        {
            if (_generalPanel == null)
            {
                _generalPanel = GameObject.Find("Game Canvas/Panels/Inspection Panel");
            }

            return _generalPanel;
        }
    }

    public void SetActiveGeneralPanel(bool value)
    {
        this.GeneralPanel.SetActive(value);

        if (value)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!this.PlayerPanel.activeInHierarchy)
            {
                this.SetActivePlayerPanel(true);
                this.PlayerPanel.GetComponent<PlayerPanelManager>().PanelPage = PlayerPanelContent.Inventory;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!this.GeneralPanel.activeInHierarchy)
            {
                this.SetActiveGeneralPanel(true);
            }
            else 
            { 
                this.SetActiveGeneralPanel(false);
            }
        }
    }
}