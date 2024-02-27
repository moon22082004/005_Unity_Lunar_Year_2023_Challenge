using UnityEngine;
using UnityEngine.EventSystems;

namespace LY2023Challenge
{
    public class MagicFormationPanelInitialPageButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject _hoverEffect;
        private GameObject HoverEffect
        {
            get
            {
                if (_hoverEffect == null)
                {
                    _hoverEffect = this.transform.GetChild(0).gameObject;
                }

                return _hoverEffect;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            this.HoverEffect.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.HoverEffect.SetActive(false);
        }

        private void OnEnable()
        {
            this.HoverEffect.SetActive(false);
        }
    }
}
