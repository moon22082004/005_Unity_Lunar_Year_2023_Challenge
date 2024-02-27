using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LY2023Challenge
{
    public class NpcPanel : MonoBehaviour
    {
        [SerializeField] private NpcController _npc;
        public NpcController Npc
        {
            get => _npc;
            set => _npc = value;
        }

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

        [SerializeField] private GameObject _initialPageButtons;
        private GameObject InitialPageButtons
        {
            get 
            {
                if (_initialPageButtons == null)
                {
                    _initialPageButtons = this.InitialPage.transform.GetChild(1).gameObject;
                }

                return _initialPageButtons;
            }
        }

        [SerializeField] private GameObject _initialPageButton;
        private GameObject InitialPageButton
        {
            get 
            {
                if (_initialPageButton == null)
                {
                    _initialPageButton = Resources.Load("Prefabs/UI/NPC Panel/Initial Page Button") as GameObject;
                }

                return _initialPageButton;
            }
        }

        public void CloneButton(string buttonName, UnityAction buttonAction)
        {
            GameObject buttonGameobject = Instantiate(this.InitialPageButton);
            buttonGameobject.name = buttonName;
            buttonGameobject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = buttonName;
            buttonGameobject.transform.SetParent(this.InitialPageButtons.transform, false);

            buttonGameobject.GetComponent<Button>().onClick.AddListener(buttonAction);
        }

        #region Talk Page

        [SerializeField] private GameObject _talkPage;
        public GameObject TalkPage
        {
            get
            {
                if (_talkPage == null)
                {
                    _talkPage = this.transform.GetChild(1).gameObject;
                }

                return _talkPage;
            }
        }

        public void DeactivateOtherPages(GameObject pageToBeActivated)
        {
            // Deactivate other pages except Chosen Page
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
            pageToBeActivated.SetActive(true);
        }

        [SerializeField] private bool _isTalking;
        public bool IsTalking
        {
            get => _isTalking;
            set => _isTalking = value;
        }

        public void StartTalking()
        {
            if (!this.IsTalking)
            {
                this.IsTalking = true;

                this.Npc.ResetTalking();
                this.TalkPage.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.Npc.Name;

                this.DeactivateOtherPages(this.TalkPage);

                this.Npc.Talk();
            }
        }

        public void EndTalking()
        {
            if (this.IsTalking)
            {
                this.IsTalking = false;

                this.DeactivateOtherPages(this.InitialPage);
            }
        }
        #endregion

        #region Shop Page
        [SerializeField] private GameObject _shopPage;
        public GameObject ShopPage
        {
            get
            {
                if (_shopPage == null)
                {
                    _shopPage = this.transform.GetChild(2).gameObject;
                }

                return _shopPage;
            }
        }

        public NpcPanelShopPageBuyingSection ShopPageManager => this.ShopPage.GetComponent<NpcPanelShopPageBuyingSection>();

        [SerializeField] private bool _isShopping;
        public bool IsShopping
        {
            get => _isShopping;
            set => _isShopping = value;
        }

        public void StartShopping()
        {
            if (!this.IsShopping)
            {
                this.IsShopping = true;
                this.ShopPageManager.Npc = this.Npc;

                this.DeactivateOtherPages(this.ShopPage);
            }
        }

        public void EndShopping()
        {
            if (this.IsShopping)
            {
                this.IsShopping = false;

                this.DeactivateOtherPages(this.InitialPage);
            }
        }
        #endregion

        public void Leave()
        {
            GameCanvasManager.Instance.SetActiveNpcPanel(false);
        }

        private void OnEnable()
        {
            // Deactivate other pages except Initial Page
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(i == 0);
            }

            // Clone Leave Button
            this.CloneButton("Leave", (() => this.Leave()));

            // Remove all previous Buttons in the Initial Page
            int oldButtons = this.InitialPageButtons.transform.childCount;
            for (int i = oldButtons - 1; i >= 0; i--)
            {
                Destroy(this.InitialPageButtons.transform.GetChild(i).gameObject);
            }
            this.InitialPageButtons.transform.DetachChildren();
        }

        private void Update()
        {
            for (int i = 0; i < this.InitialPageButtons.transform.childCount; i++) 
            {
                this.InitialPageButtons.transform.GetChild(i).position = this.InitialPageButton.transform.position + new Vector3(960, 540 - 95 * i, 0);
            }

            if (this.IsTalking)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    this.Npc.Talk();
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    this.EndTalking();
                }
            }
        }
    }
}
