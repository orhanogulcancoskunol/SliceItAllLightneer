using System;
using _game.Scripts.Character.SwordParts;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordHitController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var col = other.contacts[0].thisCollider;
            var isTop = col.TryGetComponent<SwordTop>(out _);
            var isBot = col.TryGetComponent<SwordBottom>(out _);
            if (isBot && other.gameObject.tag.Equals("Platform") || other.gameObject.tag.Equals("Obstacle"))
            {
                Debug.Log("Hit Bottom");
                GetComponent<SwordPolishController>().SwapMaterialAndJump();
            }
            else if (isTop)
            {
                GetComponent<SwordController>().ClearRotationBuffer();
            }
        }
    }
}
