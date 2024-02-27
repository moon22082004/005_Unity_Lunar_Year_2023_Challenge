using UnityEngine;

namespace LY2023Challenge
{
    public class InteractableObjectController : MonoBehaviour
    {
        [SerializeField] private GameObject _instruction;
        protected GameObject Instruction
        {
            get
            {
                if (_instruction == null)
                {
                    _instruction = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
                }

                return _instruction;
            }
        }

        [SerializeField] private Vector3 _instructionOffset;
        protected Vector3 InstructionOffset => _instructionOffset;

        [SerializeField] private bool _isReadyToInteract;
        protected bool IsReadyToInteract
        {
            get => _isReadyToInteract;
            set => _isReadyToInteract = value;
        }

        protected virtual void Awake()
        {
            this.IsReadyToInteract = false;

            this.Instruction.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + this.InstructionOffset);
        }

        protected virtual void Update()
        {
            this.Instruction.SetActive(this.IsReadyToInteract);
            this.Instruction.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + this.InstructionOffset);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                this.IsReadyToInteract = true;
            }
        }

        protected void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                this.IsReadyToInteract = false;
            }
        }
    }
}