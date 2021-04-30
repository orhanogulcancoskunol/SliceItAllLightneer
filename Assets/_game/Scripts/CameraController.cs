using System;
using _game.Scripts.Character;
using _game.Scripts.Managers;
using _game.Scripts.Utilities;
using _game.Scripts.Utilities.Interfaces;
using UnityEngine;

namespace _game.Scripts
{
    public class CameraController : Singleton<CameraController>, IActiveSetters
    {
        public bool IsActive { get; set; }
        private Vector3 _initialPosition;
        private SwordController _target;
        [SerializeField] private Vector3 offSet;
        
        private void Start()
        {
            _initialPosition = transform.position;
        }

        private void OnEnable()
        {
            GameManager.OnLevelInitialized += ResetPosition;
            GameManager.OnLevelStart += SetEnabled;
            GameManager.OnLevelCompleted += SetDisabled;
            GameManager.OnLevelFailed += SetDisabled;
        }

        private void OnDisable()
        {
            GameManager.OnLevelInitialized -= ResetPosition;
            GameManager.OnLevelStart -= SetEnabled;
            GameManager.OnLevelCompleted -= SetDisabled;
            GameManager.OnLevelFailed -= SetDisabled;
        }

        private void FixedUpdate()
        {
            
        }

        private void ResetPosition()
        {
            transform.position = _initialPosition;
        }

        public void SetEnabled()
        {
            IsActive = true;
            SetOffSet();
        }

        public void SetDisabled()
        {
            IsActive = false;
            _target = null;
        }

        private void SetOffSet()
        {
            _target = CharacterManager.Instance.CurrentCharacter;
        }
    }
}
