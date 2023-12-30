using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    [Header("Camera's Range")]
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private void Awake()
    {
        _targetTransform = GameObject.Find("Player/Character").transform;
    }

    private void Update()
    {
        this.transform.position = new Vector3(Mathf.Clamp(_targetTransform.position.x, _minX, _maxX), Mathf.Clamp(_targetTransform.position.y, _minY, _maxY), _targetTransform.position.z);
    }
}
