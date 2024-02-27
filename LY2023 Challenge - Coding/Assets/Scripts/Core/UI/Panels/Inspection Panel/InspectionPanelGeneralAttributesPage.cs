using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LY2023Challenge
{
    public class InspectionPanelGeneralAttributesPage : MonoBehaviour
    {
        private AttributesManager PlayerAttributes => PlayerManager.Instance.Player.GetComponent<AttributesManager>();

        [SerializeField] private GameObject _vigorUIGameObject;
        public GameObject VigorUIGameObject
        {
            get
            {
                if (_vigorUIGameObject == null)
                {
                    _vigorUIGameObject = this.transform.GetChild(0).GetChild(0).gameObject;
                }

                return _vigorUIGameObject;
            }
        }

        [SerializeField] private GameObject _mindUIGameObject;
        public GameObject MindUIGameObject
        {
            get
            {
                if (_mindUIGameObject == null)
                {
                    _mindUIGameObject = this.transform.GetChild(0).GetChild(1).gameObject;
                }
                return _mindUIGameObject;
            }
        }

        [SerializeField] private GameObject _enduranceUIGameObject;
        public GameObject EnduranceUIGameObject
        {
            get
            {
                if (_enduranceUIGameObject == null)
                {
                    _enduranceUIGameObject = this.transform.GetChild(0).GetChild(2).gameObject;
                }
                return _enduranceUIGameObject;
            }
        }

        [SerializeField] private GameObject _arcaneUIGameObject;
        public GameObject ArcaneUIGameObject
        {
            get
            {
                if (_arcaneUIGameObject == null)
                {
                    _arcaneUIGameObject = this.transform.GetChild(0).GetChild(3).gameObject;
                }
                return _arcaneUIGameObject;
            }
        }

        [SerializeField] private GameObject _strengthUIGameObject;
        public GameObject StrengthUIGameObject
        {
            get
            {
                if (_strengthUIGameObject == null)
                {
                    _strengthUIGameObject = this.transform.GetChild(0).GetChild(4).gameObject;
                }
                return _strengthUIGameObject;
            }
        }

        [SerializeField] private GameObject _dexterityUIGameObject;
        public GameObject DexterityUIGameObject
        {
            get
            {
                if (_dexterityUIGameObject == null)
                {
                    _dexterityUIGameObject = this.transform.GetChild(0).GetChild(5).gameObject;
                }
                return _dexterityUIGameObject;
            }
        }

        [SerializeField] private GameObject _intelligenceUIGameObject;
        public GameObject IntelligenceUIGameObject
        {
            get
            {
                if (_intelligenceUIGameObject == null)
                {
                    _intelligenceUIGameObject = this.transform.GetChild(0).GetChild(6).gameObject;
                }
                return _intelligenceUIGameObject;
            }
        }

        [SerializeField] private GameObject _faithUIGameObject;
        public GameObject FaithUIGameObject
        {
            get
            {
                if (_faithUIGameObject == null)
                {
                    _faithUIGameObject = this.transform.GetChild(0).GetChild(7).gameObject;
                }
                return _faithUIGameObject;
            }
        }

        [SerializeField] private GameObject _elixirUIGameObject;
        public GameObject ElixirUIGameObject
        {
            get
            {
                if (_elixirUIGameObject == null)
                {
                    _elixirUIGameObject = this.transform.GetChild(1).gameObject;
                }
                return _elixirUIGameObject;
            }
        }

        private void GetGeneralAttribute(GameObject attributeUIGameObject, int levelValue)
        {
            TextMeshProUGUI attributeLevelText = attributeUIGameObject.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
            attributeLevelText.text = levelValue.ToString();
            attributeLevelText.color = Color.white;
            attributeLevelText.fontSize = 14;

            Image attributeDisplay = attributeUIGameObject.transform.GetChild(0).GetComponent<Image>();
            attributeDisplay.fillAmount = (float)levelValue / 99;
        }

        private void GetElixirValue()
        {
            TextMeshProUGUI elixirValueText = this.ElixirUIGameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
            elixirValueText.text = this.PlayerAttributes.Elixir.ToString();
            elixirValueText.color = Color.white;
            elixirValueText.fontSize = 8;
        }

        private void OnEnable()
        {
            this.UpdateGeneralAttributes();
        }

        public void UpdateGeneralAttributes()
        {
            this.GetGeneralAttribute(this.VigorUIGameObject, this.PlayerAttributes.Vigor);
            this.GetGeneralAttribute(this.MindUIGameObject, this.PlayerAttributes.Mind);
            this.GetGeneralAttribute(this.EnduranceUIGameObject, this.PlayerAttributes.Endurance);
            this.GetGeneralAttribute(this.ArcaneUIGameObject, this.PlayerAttributes.Arcane);
            this.GetGeneralAttribute(this.StrengthUIGameObject, this.PlayerAttributes.Strength);
            this.GetGeneralAttribute(this.DexterityUIGameObject, this.PlayerAttributes.Dexterity);
            this.GetGeneralAttribute(this.IntelligenceUIGameObject, this.PlayerAttributes.Intelligence);
            this.GetGeneralAttribute(this.FaithUIGameObject, this.PlayerAttributes.Faith);

            this.GetElixirValue();
        }

        public void UpdateTemporaryGeneralAttribute(GameObject attributeUIGameObject, int levelValue)
        {
            this.GetGeneralAttribute(attributeUIGameObject, levelValue);

            TextMeshProUGUI attributeLevelText = attributeUIGameObject.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
            attributeLevelText.color = Color.green;
            attributeLevelText.fontSize = 16;
        }

        public void UpdateTemporaryElixirValue(int temporaryElixirValue)
        {
            TextMeshProUGUI elixirValueText = this.ElixirUIGameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
            elixirValueText.text = temporaryElixirValue.ToString();
            elixirValueText.color = Color.red;
            elixirValueText.fontSize = 9;
        }
    }
}