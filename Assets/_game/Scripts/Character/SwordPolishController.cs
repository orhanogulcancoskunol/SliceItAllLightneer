using System;
using System.Collections;
using _game.Scripts.Managers;
using _game.Scripts.Utilities.Interfaces;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordPolishController : MonoBehaviour, IActiveSetters
    {
        public bool IsActive { get; set; }
        public MeshRenderer Model;
        [Header("Hit Material")] public Material OriginalMaterial;
        public Material HitMaterial;
        
        private SwordController _swordController;

        private void OnEnable()
        {
            GameManager.OnLevelStart += SetEnabled;
            GameManager.OnLevelCompleted += SetDisabled;
            GameManager.OnLevelFailed += SetDisabled;
        }

        private void OnDisable()
        {
            GameManager.OnLevelStart += SetEnabled;
            GameManager.OnLevelCompleted += SetDisabled;
            GameManager.OnLevelFailed += SetDisabled;
        }

        private void Start()
        {
            _swordController = GetComponent<SwordController>();
        }

        public void SwapMaterialAndJump()
        {
            if (!IsActive) return;
            StartCoroutine(SwapMaterialAndJumpCoroutine());
        }

        private IEnumerator SwapMaterialAndJumpCoroutine()
        {
            Model.materials = new[] {HitMaterial};
            _swordController.Jump();
            yield return new WaitForSeconds(.5f);
            Model.materials = new[] {OriginalMaterial};
        }
        
        public void SetEnabled()
        {
            IsActive = true;
        }

        public void SetDisabled()
        {
            IsActive = false;
        }
    }
}
