using System;
using _game.Scripts.Character.SwordParts;
using _game.Scripts.Managers;
using _game.Scripts.ScriptableObjects;
using UnityEngine;

namespace _game.Scripts.Obstacles
{
    public class NotBreakableObstacleController : MonoBehaviour
    {
        [SerializeField]private TagConstantsSO tagConstants;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<SwordBottom>(out var bot))
            {
                bot.JumpSetter();
                return;
            }
            if (!other.tag.Equals(tagConstants.Player)) return;
            GetComponent<Collider>().enabled = false;
            CharacterManager.Instance.CurrentCharacter.GetComponent<Rigidbody>().isKinematic = true;
            GameManager.LevelFail();
        }
    }
}
