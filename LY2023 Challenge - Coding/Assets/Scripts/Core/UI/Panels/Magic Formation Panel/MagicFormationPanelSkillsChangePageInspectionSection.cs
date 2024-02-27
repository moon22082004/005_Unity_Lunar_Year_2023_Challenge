using UnityEngine;
using UnityEngine.UI;

namespace LY2023Challenge
{
    public class MagicFormationPanelSkillsChangePageInspectionSection : MonoBehaviour
    {
        private SkillsManager PlayerSkills => PlayerManager.Instance.Player.GetComponent<SkillsManager>();

        private MagicFormationPanelSkillsChangePageSwapSection _swapSectionManager;
        private MagicFormationPanelSkillsChangePageSwapSection SwapSectionManager
        {
            get
            {
                if (_swapSectionManager == null)
                {
                    _swapSectionManager = this.transform.parent.GetChild(1).GetComponent<MagicFormationPanelSkillsChangePageSwapSection>();
                }

                return _swapSectionManager;
            }
        }

        [SerializeField] private GameObject _normalAttackSlotUIGameObject;
        private GameObject NormalAttackSlotUIGameObject
        {
            get
            {
                if (_normalAttackSlotUIGameObject == null)
                {
                    _normalAttackSlotUIGameObject = this.transform.GetChild(1).gameObject;
                }

                return _normalAttackSlotUIGameObject;
            }
        }

        [SerializeField] private GameObject _firstMainSkillSlotUIGameObject;
        private GameObject FirstMainSkillSlotUIGameObject
        {
            get
            {
                if (_firstMainSkillSlotUIGameObject == null)
                {
                    _firstMainSkillSlotUIGameObject = this.transform.GetChild(2).gameObject;
                }

                return _firstMainSkillSlotUIGameObject;
            }
        }

        [SerializeField] private GameObject _secondMainSkillSlotUIGameObject;
        private GameObject SecondMainSkillSlotUIGameObject
        {
            get
            {
                if (_secondMainSkillSlotUIGameObject == null)
                {
                    _secondMainSkillSlotUIGameObject = this.transform.GetChild(3).gameObject;
                }

                return _secondMainSkillSlotUIGameObject;
            }
        }

        [SerializeField] private GameObject _thirdMainSkillSlotUIGameObject;
        private GameObject ThirdMainSkillSlotUIGameObject
        {
            get
            {
                if (_thirdMainSkillSlotUIGameObject == null)
                {
                    _thirdMainSkillSlotUIGameObject = this.transform.GetChild(4).gameObject;
                }

                return _thirdMainSkillSlotUIGameObject;
            }
        }

        [SerializeField] private GameObject _sideSkillSlotUIGameObject;
        private GameObject SideSkillSlotUIGameObject
        {
            get
            {
                if (_sideSkillSlotUIGameObject == null)
                {
                    _sideSkillSlotUIGameObject = this.transform.GetChild(5).gameObject;
                }

                return _sideSkillSlotUIGameObject;
            }
        }

        private void OnEnable()
        {
            this.UpdateSkillDisplays();

            this.RefreshSkillsSwapButtons();
        }

        public void RefreshSkillsSwapButtons()
        {
            this.NormalAttackSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.FirstMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SecondMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.ThirdMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SideSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
        }

        public void PrepareToSwapNormalAttackSkill()
        {
            this.NormalAttackSlotUIGameObject.GetComponent<Button>().interactable = false;

            this.SwapSectionManager.CallSwapSkillsPage("Main Skill", 0);

            this.FirstMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SecondMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.ThirdMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SideSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
        }

        public void PrepareToSwapFirstMainSkill()
        {
            this.FirstMainSkillSlotUIGameObject.GetComponent<Button>().interactable = false;

            this.SwapSectionManager.CallSwapSkillsPage("Main Skill", 1);

            this.NormalAttackSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SecondMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.ThirdMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SideSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
        }

        public void PrepareToSwapSecondMainSkill()
        {
            this.SecondMainSkillSlotUIGameObject.GetComponent<Button>().interactable = false;

            this.SwapSectionManager.CallSwapSkillsPage("Main Skill", 2);

            this.NormalAttackSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.FirstMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.ThirdMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SideSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
        }

        public void PrepareToSwapThirdMainSkill()
        {
            this.ThirdMainSkillSlotUIGameObject.GetComponent<Button>().interactable = false;

            this.SwapSectionManager.CallSwapSkillsPage("Main Skill", 3);

            this.NormalAttackSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.FirstMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SecondMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SideSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
        }

        public void PrepareToSwapSideSkill()
        {
            this.SideSkillSlotUIGameObject.GetComponent<Button>().interactable = false;

            this.SwapSectionManager.CallSwapSkillsPage("Side Skill", 0);

            this.NormalAttackSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.FirstMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.SecondMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
            this.ThirdMainSkillSlotUIGameObject.GetComponent<Button>().interactable = true;
        }

        public void UpdateSkillDisplays()
        {
            this.NormalAttackSlotUIGameObject.transform.GetChild(0).GetComponent<Image>().sprite = this.PlayerSkills.MainSkills[0].SkillIcon;

            this.FirstMainSkillSlotUIGameObject.transform.GetChild(0).GetComponent<Image>().sprite = this.PlayerSkills.MainSkills[1].SkillIcon;
            this.SecondMainSkillSlotUIGameObject.transform.GetChild(0).GetComponent<Image>().sprite = this.PlayerSkills.MainSkills[2].SkillIcon;
            this.ThirdMainSkillSlotUIGameObject.transform.GetChild(0).GetComponent<Image>().sprite = this.PlayerSkills.MainSkills[3].SkillIcon;

            this.SideSkillSlotUIGameObject.transform.GetChild(0).GetComponent<Image>().sprite = this.PlayerSkills.SideSkill.SkillIcon;
        }
    }
}
