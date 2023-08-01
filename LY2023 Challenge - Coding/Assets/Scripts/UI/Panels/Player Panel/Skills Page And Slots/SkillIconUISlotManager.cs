using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconUISlotManager : MonoBehaviour
{
    [SerializeField] private Skill _skill;
    public Skill Skill
    {
        get => _skill;
        set => _skill = value;
    }

    private Image _image;
    public Image Image
    {
        get
        {
            if (_image == null)
            {
                _image = this.transform.GetChild(0).GetComponent<Image>();
            }

            return _image;
        }
    }

    [SerializeField] private GameObject _hoverSkillDescriptionPanel;

    private void Update()
    {
        if (this.Skill != null)
        {
            this.Image.sprite = this.Skill.SkillIcon;
            this.Image.color = Color.white;
        }
        else
        {
            this.Image.color = new Color(1, 1, 1, 0);
        }
    }

    public void HoverButton(bool value)
    {
        if (this.Skill != null)
        {
            _hoverSkillDescriptionPanel.SetActive(value);

            if (value)
            {
                _hoverSkillDescriptionPanel.transform.position = Input.mousePosition;
                _hoverSkillDescriptionPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = this.Skill.Name;

                if (_hoverSkillDescriptionPanel.transform.position.x + 500 >= 1920)
                {
                    _hoverSkillDescriptionPanel.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
                }
            }
        }
    }
}
