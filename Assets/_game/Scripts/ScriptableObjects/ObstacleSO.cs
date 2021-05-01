using UnityEngine;

namespace _game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ObstacleSO", menuName = "SliceItAll/Obstacle", order = 1)]
    public class ObstacleSO : ScriptableObject
    {
        public Vector3 AppliableForce;
        public int Score;
    }
}
