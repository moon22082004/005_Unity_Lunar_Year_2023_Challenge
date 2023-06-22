using UnityEngine;
using UnityEngine.UI;

public class MainButtonsFunctionManager : MonoBehaviour
{
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

    // PLAYER PANEL
    public void OpenPlayerPanel()
    {
        this.PlayerPanel.SetActive(true);
        this.PlayerPanelButton.GetComponent<Button>().interactable = false;
    }
    public void ClosePlayerPanel()
    {
        this.PlayerPanel.SetActive(false);
        this.PlayerPanelButton.GetComponent<Button>().interactable = true;
    }
    public void OpenPageOfPlayerPanel(int playerPanelPage)
    {
        this.PlayerPanel.GetComponent<PlayerPanelManager>().PanelPage = (PlayerPanelContent)playerPanelPage;
    }

    // SAVE AND EXIT
    public void SaveAndExit()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.PlayerPanel.activeInHierarchy)
            {
                this.ClosePlayerPanel();
            }
            else
            {
                this.OpenPlayerPanel();
            }
        }
    }
}