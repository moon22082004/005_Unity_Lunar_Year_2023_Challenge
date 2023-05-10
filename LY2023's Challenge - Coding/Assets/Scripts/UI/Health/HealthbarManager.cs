using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private AttributesManager _attributesManager;
    private Slider _slider;

    [SerializeField] private Vector3 _offset;

    private void Start() 
    {
        this._slider = GetComponent<Slider>();

        this._playerTransform = this.transform.parent.gameObject.transform.parent.gameObject.transform;
        this._attributesManager = _playerTransform.GetComponent<AttributesManager>();
    }

    private void Update() 
    {
        this._slider.value = this._attributesManager.CurrentLife / this._attributesManager.MaxLife;
        this._slider.transform.position = Camera.main.WorldToScreenPoint(this._playerTransform.position + this._offset);
    }
}