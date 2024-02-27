using UnityEngine;

namespace LY2023Challenge
{
    public class NpcPanelShopPage : MonoBehaviour
    {
        [SerializeField] private GameObject _initialPage;
        private GameObject InitialPage
        {
            get
            {
                if (_initialPage == null)
                {
                    _initialPage = this.transform.GetChild(0).GetComponent<GameObject>();
                }

                return _initialPage;
            }
        }

        [SerializeField] private GameObject _buyingSection;
        private GameObject BuyingSection
        {
            get
            {
                if (_buyingSection == null)
                {
                    _buyingSection = this.transform.GetChild(1).GetComponent<GameObject>();
                }

                return _buyingSection;
            }
        }

        [SerializeField] private GameObject _sellingSection;
        private GameObject SellingSection
        {
            get
            {
                if (_sellingSection == null)
                {
                    _sellingSection = this.transform.GetChild(2).GetComponent<GameObject>();
                }

                return _sellingSection;
            }
        }

        public void SetUpBuyingSection()
        {
            if (!this.BuyingSection.activeInHierarchy)
            {
                this.BuyingSection.SetActive(true);
                this.SellingSection.SetActive(false);
                this.InitialPage.SetActive(false);
            }
        }
        public void SetUpSellingSection()
        {
            if (!this.SellingSection.activeInHierarchy)
            {
                this.BuyingSection.SetActive(false);
                this.SellingSection.SetActive(true);
                this.InitialPage.SetActive(false);
            }
        }
        public void ReturnToInitialPage()
        {
            this.BuyingSection.SetActive(false);
            this.SellingSection.SetActive(false);
            this.InitialPage.SetActive(true);
        }

        private void OnEnable()
        {
            this.BuyingSection.SetActive(false);
            this.SellingSection.SetActive(false);
        }
    }
}
