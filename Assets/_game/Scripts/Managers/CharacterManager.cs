using _game.Scripts.Character;
using _game.Scripts.Utilities;
using UnityEngine;

namespace _game.Scripts.Managers
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        [HideInInspector]
        public SwordController CurrentCharacter;

        public void Initialize()
        {
            CurrentCharacter = FindObjectOfType<SwordController>();
        }
    }
}
