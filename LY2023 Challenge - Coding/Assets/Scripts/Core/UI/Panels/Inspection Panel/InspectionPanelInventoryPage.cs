using UnityEngine;

public class InspectionPanelInventoryPage : MonoBehaviour
{
    private InventoryManager PlayerInventory => LunarMonoBehaviour.Instance.Player.GetComponent<InventoryManager>();

    [SerializeField] private ItemType _itemTypeName;
    private bool _isNotSpawnItemsPages;
    private int _currentPage;

    [SerializeField] private GameObject _itemPage;
    public GameObject ItemPage
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

    private int NumberOfPages
    {
        get
        {
            int value = 1;
            switch (_itemTypeName)
            {
                case ItemType.EQUIPMENT:
                    value += (int)(this.PlayerInventory.EquipmentItems("Equipment").Count / 16);
                    break;
                case ItemType.UPGRADE_MATERIAL:
                    value += (int)(this.PlayerInventory.UpgradeMaterialItems().Count / 16);
                    break;
            }
            return value;

        }
    }
}
