using UnityEngine;

public class PlayerPanelManager : MonoBehaviour
{
    [SerializeField] private PlayerPanelContent _panelPage;
    private PlayerPanelContent PanelPage
    {
        get => _panelPage;
        set
        {
            for (int i = 0; i < 4; i++)
            {
                this.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                this.transform.GetChild(3).GetChild(i).gameObject.SetActive(false);
            }

            this.transform.GetChild(0).GetChild((int)value).gameObject.SetActive(true);
            this.transform.GetChild(3).GetChild((int)value).gameObject.SetActive(true);

            _panelPage = value;
        }
    }

    private void Awake()
    {
        this.PanelPage = PlayerPanelContent.Inventory;
    }

    // Buttons
    public void OpenPageOfPlayerPanel(int playerPanelPage)
    {
        this.PanelPage = (PlayerPanelContent)playerPanelPage;
    }
}