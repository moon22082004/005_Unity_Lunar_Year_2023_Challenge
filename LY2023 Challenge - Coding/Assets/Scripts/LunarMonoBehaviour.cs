using UnityEngine;

public class LunarMonoBehaviour : MonoBehaviour
{
    private static LunarMonoBehaviour _instance;
    public static LunarMonoBehaviour Instance
    {
        get => _instance;
    }

    private GameObject _player;
    public GameObject Player
    {
        get
        {
            if (_player == null)
            {
                _player = GameObject.Find("Player/Character");
            }

            return _player;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}