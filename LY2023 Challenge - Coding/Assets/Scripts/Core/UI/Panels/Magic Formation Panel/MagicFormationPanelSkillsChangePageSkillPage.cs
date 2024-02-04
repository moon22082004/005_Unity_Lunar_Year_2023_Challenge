using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicFormationPanelSkillsChangePageSkillPage : MonoBehaviour
{
    [SerializeField] private List<Skill> _skills;
    public List<Skill> Skills
    {
        get
        {
            if (_skills == null)
            {
                _skills = new List<Skill>();
            }

            return _skills;
        }
        set => _skills = value;
    }

    [SerializeField] private List<Button> _buttons;
    public List<Button> Buttons
    {
        get
        {
            if (_buttons.Count == 0)
            {
                _buttons = new List<Button>();

                for (int i = 0; i < (this.transform.childCount / 2); i++)
                {
                    _buttons.Add(this.transform.GetChild(i).GetComponent<Button>());
                }
            }

            return _buttons;
        }
    }

    private void Update()
    {
        for (int i = 0; i < Mathf.Min(20, this.Skills.Count); i++)
        {
            this.transform.GetChild(i).GetComponent<MagicFormationPanelSkillsChangePageSkillPageSkillSlot>().Skill = this.Skills[i];
        }
    }
}
