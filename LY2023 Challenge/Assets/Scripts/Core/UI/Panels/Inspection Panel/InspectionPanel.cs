using UnityEngine;
using UnityEngine.UI;

namespace LY2023Challenge
{
    public class InspectionPanel : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject _attributesAndEquipmentsUIGameObject;
        private GameObject AttributesAndEquipmentsUIGameObject
        {
            get
            {
                if (_attributesAndEquipmentsUIGameObject == null)
                {
                    _attributesAndEquipmentsUIGameObject = this.transform.GetChild(1).gameObject;
                }

                return _attributesAndEquipmentsUIGameObject;
            }
        }

        [SerializeField] private GameObject _inventoryUIGameObject;
        private GameObject InventoryUIGameObject
        {
            get
            {
                if (_inventoryUIGameObject == null)
                {
                    _inventoryUIGameObject = this.transform.GetChild(2).gameObject;
                }

                return _inventoryUIGameObject;
            }
        }

        [SerializeField] private GameObject _mapUIGameObject;
        private GameObject MapUIGameObject
        {
            get
            {
                if (_mapUIGameObject == null)
                {
                    _mapUIGameObject = this.transform.GetChild(3).gameObject;
                }

                return _mapUIGameObject;
            }
        }

        [SerializeField] private GameObject _databankUIGameObject;
        private GameObject DatabankUIGameObject
        {
            get
            {
                if (_databankUIGameObject == null)
                {
                    _databankUIGameObject = this.transform.GetChild(4).gameObject;
                }

                return _databankUIGameObject;
            }
        }

        [SerializeField] private GameObject _settingsUIGameObject;
        private GameObject SettingsUIGameObject
        {
            get
            {
                if (_settingsUIGameObject == null)
                {
                    _settingsUIGameObject = this.transform.GetChild(5).gameObject;
                }

                return _settingsUIGameObject;
            }
        }

        [Header("Navbar's Buttons")]
        [SerializeField] private Button _aAEButton;
        public Button AAEButton
        {
            get
            {
                if (_aAEButton == null)
                {
                    _aAEButton = this.transform.GetChild(0).GetComponent<Button>();
                }

                return _aAEButton;
            }
        }

        public void SetUpAAEPanels()
        {
            this.AttributesAndEquipmentsUIGameObject.SetActive(true);

            this.InventoryUIGameObject.SetActive(false);
            this.MapUIGameObject.SetActive(false);
            this.DatabankUIGameObject.SetActive(false);
            this.SettingsUIGameObject.SetActive(false);
        }

        public void SetUpInventoryPanel()
        {
            this.InventoryUIGameObject.SetActive(true);

            this.AttributesAndEquipmentsUIGameObject.SetActive(false);
            this.MapUIGameObject.SetActive(false);
            this.DatabankUIGameObject.SetActive(false);
            this.SettingsUIGameObject.SetActive(false);
        }

        public void SetUpMapPanel()
        {
            this.MapUIGameObject.SetActive(true);

            this.AttributesAndEquipmentsUIGameObject.SetActive(false);
            this.InventoryUIGameObject.SetActive(false);
            this.DatabankUIGameObject.SetActive(false);
            this.SettingsUIGameObject.SetActive(false);
        }

        public void SetUpDatabankPanel()
        {
            this.DatabankUIGameObject.SetActive(true);

            this.AttributesAndEquipmentsUIGameObject.SetActive(false);
            this.InventoryUIGameObject.SetActive(false);
            this.MapUIGameObject.SetActive(false);
            this.SettingsUIGameObject.SetActive(false);
        }

        public void SetUpSettingsPanel()
        {
            this.SettingsUIGameObject.SetActive(true);

            this.AttributesAndEquipmentsUIGameObject.SetActive(false);
            this.InventoryUIGameObject.SetActive(false);
            this.MapUIGameObject.SetActive(false);
            this.DatabankUIGameObject.SetActive(false);
        }

        private void OnEnable()
        {
            this.SetUpAAEPanels();
        }
    }
}