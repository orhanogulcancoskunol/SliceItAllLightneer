using System;
using _game.Scripts.Character.SwordParts;
using _game.Scripts.Managers;
using _game.Scripts.ScriptableObjects;
using _game.Scripts.Utilities.Interfaces;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordHitController : MonoBehaviour, IActiveSetters
    {
        public bool IsActive { get; set; }
        [SerializeField] private TagConstantsSO tagConstants;
        private SwordController _swordController;
        private SwordPolishController _polishController;
        private bool _isFailed;

        private void Start()
        {
            _swordController = GetComponent<SwordController>();
            _polishController = GetComponent<SwordPolishController>();
        }

        private void FixedUpdate()
        {
            if (!(transform.position.y <= -5f) || _isFailed) return;
            GameManager.LevelFail();
            _isFailed = true;
        }

        private void OnEnable()
        {
            GameManager.OnLevelStart += SetEnabled;
            GameManager.OnLevelCompleted += SetDisabled;
            GameManager.OnLevelFailed += SetDisabled;
        }

        private void OnDisable()
        {
            GameManager.OnLevelStart -= SetEnabled;
            GameManager.OnLevelCompleted -= SetDisabled;
            GameManager.OnLevelFailed -= SetDisabled;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!IsActive) return;
            var col = other.contacts[0].thisCollider;
            if (col.TryGetComponent<SwordBottom>(out _) && other.gameObject.tag.Equals(tagConstants.Platform))
            {
                _polishController.SwapMaterialAndJump();
            }
            else if (col.TryGetComponent<SwordTop>(out _))
            {
                _swordController.StopAllCoroutines();
                _swordController.DisableRotate();
            }
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
