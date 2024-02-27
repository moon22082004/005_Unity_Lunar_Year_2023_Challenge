using TMPro;
using UnityEngine;

namespace LY2023Challenge
{
    public class NpcPanelTalkPage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dialogueDisplay;
        private TextMeshProUGUI DialogueDisplay
        {
            get 
            {
                if (_dialogueDisplay == null)
                {
                    _dialogueDisplay = this.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
                }

                return _dialogueDisplay; 
            }
        }

        public void ShowDialogue(string dialogue)
        {
            this.DialogueDisplay.text = dialogue;
        }
    }
}
