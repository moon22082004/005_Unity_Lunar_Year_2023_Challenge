using Unity.VisualScripting;
using UnityEngine;

namespace LY2023Challenge
{
    public class NpcPanelShopPageSellingSection : PageContainingItemPages
    {
        [SerializeField] private NpcController _npc;
        public NpcController Npc
        {
            get => _npc;
            set => _npc = value;
        }

        protected override InventoryManager SubjectInventory => this.Npc.GetComponent<InventoryManager>();

        [SerializeField] private GameObject _itemPage;
        public override GameObject ItemPage
        {
            get
            {
                if (_itemPage == null)
                {
                    _itemPage = Resources.Load("Prefabs/UI/NPC Panel/Item Page") as GameObject;
                }

                return _itemPage;
            }
        }

        [SerializeField] private GameObject _checkoutPage;
        public GameObject CheckoutPage
        {
            get 
            {
                if (_checkoutPage == null) 
                {
                    _checkoutPage = this.transform.GetChild(5).gameObject;
                }

                return _checkoutPage;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void UpdatePageContent()
        {
            base.UpdatePageContent();

            for (int i = 0; i < this.ItemPagesTransform.childCount; i++) 
            {
                for (int j = 0; j < this.ItemPagesTransform.GetChild(i).childCount / 2; j++)
                {

                }    
            }
        }

        public void SetUpCheckoutPage(Item item, int Number)
        {
            this.CheckoutPage.SetActive(true);


            this.gameObject.SetActive(false);
        }
    }
}
