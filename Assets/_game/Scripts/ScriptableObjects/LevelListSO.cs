using System.Collections.Generic;
using UnityEngine;

namespace _game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelList", menuName = "SliceItAll/Level/LevelList", order = 1)]
    public class LevelListSO : ScriptableObject
    {
        public List<LevelSO> Levels;
    }
}
