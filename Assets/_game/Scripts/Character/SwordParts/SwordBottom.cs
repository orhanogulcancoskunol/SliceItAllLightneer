using System;
using UnityEngine;

namespace _game.Scripts.Character.SwordParts
{
    public class SwordBottom : MonoBehaviour
    {
        private SwordPolishController _polishController;
        private void Start()
        {
            _polishController = GetComponentInParent<SwordPolishController>();
        }

        public void JumpSetter()
        {
            _polishController.SwapMaterialAndJump();
        }
    }
}
