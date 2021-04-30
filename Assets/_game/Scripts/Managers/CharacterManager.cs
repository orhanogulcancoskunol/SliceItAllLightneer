using _game.Scripts.Character;
using _game.Scripts.Utilities;
using UnityEngine;

namespace _game.Scripts.Managers
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        public SwordController CurrentCharacter;
    }
}
