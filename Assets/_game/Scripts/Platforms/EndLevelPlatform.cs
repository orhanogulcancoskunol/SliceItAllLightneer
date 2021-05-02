using _game.Scripts.Managers;
using _game.Scripts.ScriptableObjects;
using UnityEngine;

namespace _game.Scripts.Platforms
{
    public class EndLevelPlatform : MonoBehaviour
    {
        public int ScoreMultiplier;
        [SerializeField] private TagConstantsSO tagConstants;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.tag.Equals(tagConstants.Player)) return;
            other.GetComponent<Collider>().enabled = false;
            CharacterManager.Instance.CurrentCharacter.ClearRotationBuffer();
            CharacterManager.Instance.CurrentCharacter.GetComponent<Rigidbody>().isKinematic = true;
            CharacterManager.Instance.GetScoreController().ScoreMultiply(ScoreMultiplier);
            GameManager.Instance.LevelComplete();
        }
    }
}
