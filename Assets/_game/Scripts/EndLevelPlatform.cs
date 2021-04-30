using System;
using _game.Scripts.Managers;
using UnityEngine;

namespace _game.Scripts
{
    public class EndLevelPlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                CharacterManager.Instance.CurrentCharacter.ClearRotationBuffer();
                CharacterManager.Instance.CurrentCharacter.GetComponent<Rigidbody>().isKinematic = true;
                GameManager.Instance.LevelComplete();
            }
        }
    }
}
