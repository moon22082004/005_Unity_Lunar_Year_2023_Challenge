using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LY2023Challenge
{
    public abstract class NpcController : InteractableObjectController
    {
        public string Name => this.gameObject.name;

        private string _direction = "Down";
        protected string Direction
        {
            get => _direction;
        }

        protected string AnimationDirection
        {
            get
            {
                if ((this.Direction == "Down") || (this.Direction == "Up"))
                {
                    return this.Direction;
                }

                return "Side";
            }
        }

        public void SetSideDirection(float horizontalValue)
        {
            this.transform.localScale = new Vector3(Mathf.Sign(horizontalValue) * -1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

            this.Animator.SetInteger("Direction", 1);

            if (horizontalValue > 0)
            {
                _direction = "Right";
            }
            else
            {
                _direction = "Left";
            }
        }

        public void SetDownDirection()
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

            this.Animator.SetInteger("Direction", 0);

            _direction = "Down";
        }

        public void SetUpDirection()
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

            this.Animator.SetInteger("Direction", 2);

            _direction = "Up";
        }


        private Animator _animator;
        protected Animator Animator
        {
            get
            {
                if (_animator == null)
                {
                    _animator = GetComponent<Animator>();
                }

                return _animator;
            }
        }

        [Header("NPC UI Panel")]
        [SerializeField] private GameObject _npcPanel;
        protected GameObject NpcPanel
        {
            get
            {
                if (_npcPanel == null)
                {
                    _npcPanel = GameObject.Find("Game Canvas/Panels/NPC Panel");
                }

                return _npcPanel;
            }
        }
        public NpcPanel NpcPanelManager => this.NpcPanel.GetComponent<NpcPanel>();
        public NpcPanelTalkPage NpcTalkPageManager => this.NpcPanelManager.TalkPage.GetComponent<NpcPanelTalkPage>();

        protected override void Update()
        {
            base.Update();

            if (this.IsReadyToInteract)
            {
                if ((Input.GetKeyDown(KeyCode.Return)) && (!GameCanvasManager.Instance.NpcPanel.activeInHierarchy))
                {
                    if (!this.NpcPanel.activeInHierarchy)
                    {
                        this.SetUpNpcPanel();
                    }
                }
            }
        }

        [Header("Dialogues")]
        [SerializeField] private List<string> _dialogues;
        public List<string> Dialogues => _dialogues;

        [SerializeField] private int _currentDialogueIndex;
        public int CurrentDialogueIndex
        {
            get => _currentDialogueIndex;
            set => _currentDialogueIndex = value;
        }

        protected virtual void SetUpNpcPanel()
        {
            for (int i = 0; i < this.NpcPanel.transform.childCount; i++)
            {
                this.NpcPanel.transform.GetChild(i).gameObject.SetActive(i == 0);
            }

            this.NpcPanelManager.Npc = this;
            this.NpcPanel.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.Name;
            GameCanvasManager.Instance.SetActiveNpcPanel(true);
        }

        public virtual void ResetTalking()
        {
            this.CurrentDialogueIndex = 0;
        }

        public virtual void Talk()
        {
            if (this.Dialogues.Count > this.CurrentDialogueIndex)
            {
                this.NpcTalkPageManager.ShowDialogue(this.Dialogues[this.CurrentDialogueIndex]);

                this.CurrentDialogueIndex++;
            }
            else
            {
                this.NpcPanelManager.EndTalking();
            }
        }    
    }
}
