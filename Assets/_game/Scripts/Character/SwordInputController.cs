using System;
using _game.Scripts.Managers;
using _game.Scripts.Utilities.Interfaces;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordInputController : MonoBehaviour, IActiveSetters
    {
        public bool IsActive { get; set; }
        private SwordController _swordController;
        
        private void Awake()
        {
            _swordController = GetComponent<SwordController>();
        }

        private void OnEnable()
        {
            GameManager.OnLevelInitialized += SetEnabled;
            GameManager.OnLevelFailed += SetDisabled;
            GameManager.OnLevelCompleted += SetDisabled;
        }

        private void OnDisable()
        {
            GameManager.OnLevelInitialized -= SetEnabled;
            GameManager.OnLevelFailed -= SetDisabled;
            GameManager.OnLevelCompleted -= SetDisabled;
        }

        private void Update()
        {
            if (!IsActive) return;
            if(Input.GetMouseButtonDown(0))
                _swordController.Jump();
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
