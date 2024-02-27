using UnityEngine;

namespace LY2023Challenge
{
    public class NpcPanelShopPageBuyingSection : PageContainingItemPages
    {
        [SerializeField] private NpcController _npc;
        public NpcController Npc
        {
            get => _npc;
            set => _npc = value;
        }

        private InventoryManager NpcInventory => this.Npc.GetComponent<InventoryManager>();

        protected override InventoryManager SubjectInventory => PlayerManager.Instance.Player.GetComponent<InventoryManager>();

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
        }
    }
}
