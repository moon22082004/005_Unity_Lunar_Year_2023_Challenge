using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopLeftPanel : MonoBehaviour
{
    private AttributesManager PlayerAttributes => LunarMonoBehaviour.Instance.Player.GetComponent<AttributesManager>();

    [SerializeField] private Image _hPBar;
    private Image HPBar
    {
        get 
        {
            if (_hPBar == null)
            {
                _hPBar = this.transform.GetChild(1).GetComponent<Image>();
            }

            return _hPBar;
        }
    }

    [SerializeField] private TextMeshProUGUI _hPDisplay;
    private TextMeshProUGUI HPDisplay
    {
        get
        {
            if (_hPDisplay == null)
            {
                _hPDisplay = this.HPBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            }

            return _hPDisplay;
        }
    }

    [SerializeField] private Image _fPBar;
    private Image FPBar
    {
        get
        {
            if (_fPBar == null)
            {
                _fPBar = this.transform.GetChild(3).GetComponent<Image>();
            }

            return _fPBar;
        }
    }


    private void Update()
    {
        // HP
        this.HPBar.fillAmount = this.PlayerAttributes.CurrentHP / this.PlayerAttributes.MaxHP;
        this.HPDisplay.text = this.PlayerAttributes.CurrentHP.ToString() + "/" + this.PlayerAttributes.MaxHP;

        // FP
        this.FPBar.fillAmount = this.PlayerAttributes.CurrentFP / this.PlayerAttributes.MaxFP;
    }
}
