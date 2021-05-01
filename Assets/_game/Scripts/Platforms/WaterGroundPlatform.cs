using _game.Scripts.Managers;
using UnityEngine;

namespace _game.Scripts.Platforms
{
    public class WaterGroundPlatform : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.tag.Equals("Finish")) return;
            CharacterManager.Instance.CurrentCharacter.UnFreezeRotation();
            GameManager.LevelFail();
        }
    }
}
