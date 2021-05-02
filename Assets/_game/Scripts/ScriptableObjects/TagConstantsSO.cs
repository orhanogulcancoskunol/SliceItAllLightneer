using UnityEngine;

namespace _game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TagConstantsSO", menuName = "SliceItAll/TagConstants", order = 1)]
    public class TagConstantsSO : ScriptableObject
    {
        public string Player, Obstacle, Platform, FinishPlayer;
    }
}
