using UnityEngine;

namespace _game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level", menuName = "SliceItAll/Level/Level", order = 1)]
    public class LevelSO : ScriptableObject
    {
        public GameObject LevelPrefab;
    }
}
