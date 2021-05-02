using _game.Scripts.Managers;
using _game.Scripts.ScriptableObjects;
using UnityEngine;

namespace _game.Scripts.Platforms
{
    public class WaterGroundPlatform : MonoBehaviour
    {
        [SerializeField]private TagConstantsSO tagConstants;
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.tag.Equals(tagConstants.FinishPlayer)) return;
            CharacterManager.Instance.CurrentCharacter.UnFreezeRotation();
            GameManager.LevelFail();
        }
    }
}
