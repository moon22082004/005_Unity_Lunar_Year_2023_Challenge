using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private static EnemiesManager _instance;
    public static EnemiesManager Instance
    {
        get => _instance;
    }

    [SerializeField] private List<GameObject> _enemies;
    public List<GameObject> Enemies
    {
        get => _enemies;
    }

    public GameObject GetClosestEnemy(Vector3 targetPos, float maxDistance)
    {
        Transform transformMin = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject enemy in _enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, targetPos);
            if ((distance < minDistance) && (distance <= maxDistance))
            {
                transformMin = enemy.transform;
                minDistance = distance;
            }
        }
        if (transformMin != null)
        {
            return transformMin.GetComponent<GameObject>();
        }
        return null;
    }

    public List<GameObject> GetEnemiesInCircle(Vector3 targetPos, float radius) 
    {
        List<GameObject> result = new List<GameObject>();
        foreach (GameObject enemy in _enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, targetPos);
            if (distance < radius)
            {
                result.Add(enemy);
            }
        }

        return result;
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}