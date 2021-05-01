using _game.Scripts.Character;
using _game.Scripts.Utilities;
using UnityEngine;

namespace _game.Scripts.Managers
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        public SwordController CharacterBase;
        [HideInInspector]
        public SwordController CurrentCharacter;

        public void Initialize()
        {
            if(CurrentCharacter!=null) Destroy(CurrentCharacter.gameObject);
            CurrentCharacter = Instantiate(CharacterBase);
        }

        public SwordScoreController GetScoreController()
        {
            return CurrentCharacter.GetComponent<SwordScoreController>();
        }
    }
}
