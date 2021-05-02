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
        [SerializeField] private float hitAndSwapTime;

        [Header("Score Effect")] public ScoreEffectController ScoreEffect;
        [SerializeField] private float _timeToDestroyScoreEffect;
        
        private SwordController _swordController;
        private Transform _hitObject;

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
            _swordController.Jump(_swordController.GetStaticForceForHit());
            yield return new WaitForSeconds(hitAndSwapTime);
            Model.materials = new[] {OriginalMaterial};
        }

        public void AddScorePolish(int val)
        {
            var score = Instantiate(ScoreEffect, _hitObject.position, Quaternion.Euler(0, -90f, 0));
            score.UpdateScore(val);
            Destroy(score.gameObject, _timeToDestroyScoreEffect);
        }

        public void SetHitObject(Transform hitObject)
        {
            _hitObject = hitObject;
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
