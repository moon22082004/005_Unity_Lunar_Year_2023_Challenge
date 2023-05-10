using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManagement : MonoBehaviour
{
    public GameObject[] enemies;

    public GameObject GetClosestEnemy(Vector3 _targetPos, float _maxDistance)
    {
        Transform _transformMin = null;
        float _minDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float _distance = Vector3.Distance(enemy.transform.position, _targetPos);
            if ( (_distance < _minDistance) && (_distance <= _maxDistance) )
            {
                _transformMin = enemy.transform;
                _minDistance = _distance;
            }
        }
        if ( _transformMin != null )
            return _transformMin.GetComponent<GameObject>();
        return null;
    }
}
