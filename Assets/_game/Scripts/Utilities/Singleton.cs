using UnityEngine;

namespace _game.Scripts.Utilities
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
                Instance = GetComponent<T>();
            else
                Destroy(this);
        }
    }
}
