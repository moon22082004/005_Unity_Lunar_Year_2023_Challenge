using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LY2023Challenge
{
    public class MagicFormationPanelSkillsChangePageSwapSection : MonoBehaviour
    {
        private InventoryManager PlayerInventory => PlayerManager.Instance.Player.GetComponent<InventoryManager>();
        private SkillsManager PlayerSkills => PlayerManager.Instance.Player.GetComponent<SkillsManager>();

        [SerializeField] private string _skillDisplayType;
        private string SkillDisplayType
        {
            get
            {
                return _skillDisplayType;
            }
            set
            {
                _skillDisplayType = value;
            }
        }

        private List<Skill> AvailableSkills
        {
            get => this.PlayerInventory.SkillsByType(this.SkillDisplayType);
        }

        [SerializeField] private int _currentPage;

        [SerializeField] private Button _previousPageButton;
        private Button PreviousPageButton
        {
            get
            {
                if (_previousPageButton == null)
                {
                    _previousPageButton = this.transform.GetChild(1).GetComponent<Button>();
                }

                return _previousPageButton;
            }
        }

        [SerializeField] private Button _nextPageButton;
        private Button NextPageButton
        {
            get
            {
                if (_nextPageButton == null)
                {
                    _nextPageButton = this.transform.GetChild(2).GetComponent<Button>();
                }

                return _nextPageButton;
            }
        }

        [SerializeField] private GameObject _skillPage;
        public GameObject SkillPage
        {
            get
            {
                if (_skillPage == null)
                {
                    _skillPage = Resources.Load("Prefabs/UI/Magic Formation Panel/Skill Page") as GameObject;
                }

                return _skillPage;
            }
        }

        [SerializeField] private GameObject _skillPages;
        private GameObject SkillPages
        {
            get
            {
                if (_skillPages == null)
                {
                    _skillPages = this.transform.GetChild(3).gameObject;
                }

                return _skillPages;
            }
        }

        private int NumberOfPages
        {
            get
            {
                int value;
                if (this.SkillDisplayType != "")
                {
                    value = 1 + (int)(this.AvailableSkills.Count / 20);
                }
                else
                {
                    value = 0;
                }

                return value;
            }
        }

        public void DisplayOtherInventoryPage(int offsetValue)
        {
            _currentPage = (int)Mathf.Clamp(_currentPage + offsetValue, 0, this.NumberOfPages - 1);

            this.UpdateSwitchSkillPageButtons();
        }

        public void CallSwapSkillsPage(string skillDisplayType, int index)
        {
            this.SkillDisplayType = skillDisplayType;
            _currentPage = 0;

            // Remove all of the existing Item Pages
            int oldNumberOfPages = this.SkillPages.transform.childCount;
            for (int i = oldNumberOfPages - 1; i >= 0; i--)
            {
                Destroy(this.SkillPages.transform.GetChild(i).gameObject);
            }
            this.SkillPages.transform.DetachChildren();

            // Instantiate the missing Skill Pages
            while (this.SkillPages.transform.childCount < this.NumberOfPages)
            {
                GameObject page = Instantiate(this.SkillPage);
                page.name = $"{this.SkillPage.name} {this.SkillPages.transform.childCount}";
                page.transform.SetParent(this.SkillPages.transform, false);
            }

            this.UpdateSwitchSkillPageButtons();

            this.UpdateSkillPages(index);
        }

        public void ChangeSkill(string skillTypeName, int index, Skill choosenSkill)
        {
            if (choosenSkill != null)
            {
                this.PlayerInventory.SwapSkillFromCharacter(skillTypeName, index, choosenSkill, PlayerManager.Instance.Player.GetComponent<SkillsManager>());
                this.SkillDisplayType = "";
                _currentPage = 0;

                MagicFormationPanelSkillsChangePageInspectionSection inspectionSectionManager = this.transform.parent.GetChild(0).GetComponent<MagicFormationPanelSkillsChangePageInspectionSection>();
                inspectionSectionManager.UpdateSkillDisplays();
                inspectionSectionManager.RefreshSkillsSwapButtons();

                this.UpdateSkillPages(index);
            }
        }

        private void UpdateSkillPages(int index)
        {
            for (int i = 1; i <= this.NumberOfPages; i++)
            {
                List<Skill> skills = new List<Skill>();
                for (int j = ((i - 1) * 20); j < Mathf.Min(i * 20, this.AvailableSkills.Count); j++)
                {
                    skills.Add(this.AvailableSkills[j]);
                }

                this.SkillPages.transform.GetChild(i - 1).GetComponent<MagicFormationPanelSkillsChangePageSkillPage>().Skills = skills;
            }

            for (int i = 0; i < this.NumberOfPages; i++)
            {
                foreach (Button button in this.SkillPages.transform.GetChild(i).GetComponent<MagicFormationPanelSkillsChangePageSkillPage>().Buttons)
                {
                    button.onClick.RemoveAllListeners();
                    button.onClick.AddListener(() => this.ChangeSkill(this.SkillDisplayType, index, button.GetComponent<MagicFormationPanelSkillsChangePageSkillPageSkillSlot>().Skill));
                }
            }
        }

        private void UpdateSwitchSkillPageButtons()
        {
            this.PreviousPageButton.interactable = !(_currentPage == 0);
            this.NextPageButton.interactable = !(_currentPage == this.NumberOfPages);

            for (int i = 0; i < this.NumberOfPages; i++)
            {
                this.SkillPages.transform.GetChild(i).gameObject.SetActive(_currentPage == i);
            }
        }

        private void OnEnable()
        {
            this.SkillDisplayType = "";
            _currentPage = 0;
        }

        private void Update()
        {
            this.SkillPages.SetActive(this.SkillDisplayType != "");
            this.PreviousPageButton.gameObject.SetActive(this.SkillDisplayType != "");
            this.NextPageButton.gameObject.SetActive(this.SkillDisplayType != "");
        }
    }
}