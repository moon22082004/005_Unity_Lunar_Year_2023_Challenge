using UnityEngine;

public class MagicFormationPanel : MonoBehaviour
{
    [SerializeField] private GameObject _initialPage;
    private GameObject InitialPage
    { 
        get 
        { 
            if (_initialPage == null)
            {
                _initialPage = this.transform.GetChild(0).gameObject;
            }

            return _initialPage;
        }
    }

    [SerializeField] private GameObject _attributesUpgradePage;
    private GameObject AttributesUpgradePage
    {
        get
        {
            if (_attributesUpgradePage == null)
            {
                _attributesUpgradePage = this.transform.GetChild(1).gameObject;
            }

            return _attributesUpgradePage;
        }
    }

    [SerializeField] private GameObject _equipmentsChangePage;
    private GameObject EquipmentsChangePage
    {
        get
        {
            if (_equipmentsChangePage == null)
            {
                _equipmentsChangePage = this.transform.GetChild(2).gameObject;
            }

            return _equipmentsChangePage;
        }
    }

    [SerializeField] private GameObject _skillsChangePage;
    private GameObject SkillsChangePage
    {
        get
        {
            if (_skillsChangePage == null)
            {
                _skillsChangePage = this.transform.GetChild(3).gameObject;
            }

            return _skillsChangePage;
        }
    }

    private void OnEnable()
    {
        this.SetUpInitialPage();
    }

    public void SetUpInitialPage()
    {
        this.InitialPage.SetActive(true);

        this.AttributesUpgradePage.SetActive(false);
        this.EquipmentsChangePage.SetActive(false);
        this.SkillsChangePage.SetActive(false);
    }

    public void SetUpAttributesUpgradePage()
    {
        this.AttributesUpgradePage.SetActive(true);

        this.InitialPage.SetActive(false);
        this.EquipmentsChangePage.SetActive(false);
        this.SkillsChangePage.SetActive(false);
    }

    public void SetUpEquipmentsChangePage()
    {
        this.EquipmentsChangePage.SetActive(true);

        this.InitialPage.SetActive(false);
        this.AttributesUpgradePage.SetActive(false);
        this.SkillsChangePage.SetActive(false);
    }

    public void SetUpSkillsChangePage()
    {
        this.SkillsChangePage.SetActive(true);

        this.InitialPage.SetActive(false);
        this.AttributesUpgradePage.SetActive(false);
        this.EquipmentsChangePage.SetActive(false);
    }

    public void SaveAndQuit()
    {
        Debug.Log("Saved game");
        Debug.Log("Quiting....");
    }

    public void Leave()
    {
        this.gameObject.SetActive(false);

        Time.timeScale = 1;
    }
}
