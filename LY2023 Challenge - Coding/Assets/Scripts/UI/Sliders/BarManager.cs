using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private AttributesManager _attributesManager;
    private Slider _slider;

    protected AttributesManager AttributesManager
    {
        get => _attributesManager;
    }    
    protected Slider Slider
    {
        get => _slider;
    }

    [SerializeField] protected Vector3 _offset;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        _playerTransform = this.transform.parent.gameObject.transform.parent.gameObject.transform;
        _attributesManager = _playerTransform.GetComponent<AttributesManager>();
    }

    protected virtual void Update()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(_playerTransform.position + _offset);
        this.transform.localScale = Vector3.one;
    }
}