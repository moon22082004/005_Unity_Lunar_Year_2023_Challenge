using System.Collections.Generic;
using UnityEngine;

namespace LY2023Challenge
{
    public class NpcsManager : MonoBehaviour
    {
        private static NpcsManager _instance;
        public static NpcsManager Instance
        {
            get => _instance;
        }

        [SerializeField] private List<GameObject> _npcs;
        public List<GameObject> Npcs => _npcs;

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
}
