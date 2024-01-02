using UnityEngine;

public class AttributesPanel : MonoBehaviour
{
    [SerializeField] private bool _isShowedGeneralAttributes;

    [Header("Panels")]
    [SerializeField] private GameObject _generalAttributesPanel;
    public GameObject GeneralAttributesPanel
    { 
        get 
        { 
            if (_generalAttributesPanel == null)
            {
                _generalAttributesPanel = this.transform.GetChild(1).transform.gameObject;
            }

            return _generalAttributesPanel; 
        } 
    }

    [SerializeField] private GameObject _detailedAttributesPanel;
    public GameObject DetailedAttributesPanel
    {
        get 
        {
            if (_detailedAttributesPanel == null)
            {
                _detailedAttributesPanel = this.transform.GetChild(2).transform.gameObject;
            }

            return _detailedAttributesPanel;
        }
    }

    private void Awake()
    {
        _isShowedGeneralAttributes = true;

        this.GeneralAttributesPanel.SetActive(_isShowedGeneralAttributes);
        this.DetailedAttributesPanel.SetActive(!_isShowedGeneralAttributes);
    }

    public void SwapAttributesPanel()
    {
        _isShowedGeneralAttributes = !_isShowedGeneralAttributes;

        this.GeneralAttributesPanel.SetActive(_isShowedGeneralAttributes);
        this.DetailedAttributesPanel.SetActive(!_isShowedGeneralAttributes);
    }

}
