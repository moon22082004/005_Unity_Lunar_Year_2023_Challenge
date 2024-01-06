using UnityEngine;

public class InteractableObjectBehaviour : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D _polygonCollider;
    protected PolygonCollider2D PolygonCollider2D
    {
        get
        {
            if (_polygonCollider == null)
            {
                _polygonCollider = GetComponent<PolygonCollider2D>();
            }

            return _polygonCollider;
        }
    }

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
