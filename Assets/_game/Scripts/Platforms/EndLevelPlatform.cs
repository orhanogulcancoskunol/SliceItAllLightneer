using _game.Scripts.Managers;
using UnityEngine;

namespace _game.Scripts.Platforms
{
    public class EndLevelPlatform : MonoBehaviour
    {
        public int ScoreMultiplier;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.tag.Equals("Player")) return;
            CharacterManager.Instance.CurrentCharacter.ClearRotationBuffer();
            CharacterManager.Instance.CurrentCharacter.GetComponent<Rigidbody>().isKinematic = true;
            CharacterManager.Instance.GetScoreController().ScoreMultiply(ScoreMultiplier);
            GameManager.Instance.LevelComplete();
        }
    }
}
