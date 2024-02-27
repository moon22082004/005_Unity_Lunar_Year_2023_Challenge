using UnityEngine;

namespace LY2023Challenge
{
    public class InspectionPanelInventoryPage : PageContainingItemPages
    {
        protected override InventoryManager SubjectInventory => PlayerManager.Instance.Player.GetComponent<InventoryManager>();

        [SerializeField] private GameObject _itemPage;
        public override GameObject ItemPage
        {
            get
            {
                if (_itemPage == null)
                {
                    _itemPage = Resources.Load("Prefabs/UI/Inspection Panel/Item Page") as GameObject;
                }

                return _itemPage;
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