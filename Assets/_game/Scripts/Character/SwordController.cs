using System;
using System.Collections;
using System.Collections.Generic;
using _game.Scripts.Managers;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private bool _isActive;
        private float _durationForReJumpLimit;
        [SerializeField] private Vector3 staticForce;
        [Header("ReJump Values")]
        [SerializeField] private float durationForReJump = 1f;
        [SerializeField] private float durationForJump = 4f;
        [SerializeField] private float velocityYLimit = -3f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _durationForReJumpLimit = durationForReJump;
        }

        private void FixedUpdate()
        {
            ReJump();
        }

        private void OnEnable()
        {
            GameManager.OnLevelFailed += StopAllCoroutines;
            GameManager.OnLevelFailed += UnFreezeRotation;
            GameManager.OnLevelCompleted += StopAllCoroutines;
        }

        private void OnDisable()
        {
            GameManager.OnLevelFailed -= StopAllCoroutines;
            GameManager.OnLevelFailed -= UnFreezeRotation;
            GameManager.OnLevelCompleted -= StopAllCoroutines;
        }

        private void ReJump()
        {
            if (_rigidbody.velocity.y < velocityYLimit && durationForReJump >= _durationForReJumpLimit)
            {
                StartCoroutine(Rotate(durationForJump));
                durationForReJump = 0;
            }
            else
            {
                durationForReJump += Time.fixedDeltaTime;
            }
        }

        public void Jump()
        {
            _rigidbody.AddForce(staticForce);
            StopAllCoroutines();
            StartCoroutine(Rotate(durationForJump));
        }

        private IEnumerator Rotate(float duration)
        {
            var startRot = transform.rotation;
            var t = 0f;
            while ( t  < duration )
            {
                t += Time.fixedDeltaTime;
                transform.rotation = startRot * Quaternion.AngleAxis(t / duration * 360f, Vector3.right);
                yield return null;
            }
            transform.rotation = startRot;
        }

        #region freezeX

        private void UnFreezeRotation()
        {
            _rigidbody.constraints =
                RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        private void FreezeRotation()
        {
            _rigidbody.constraints =
                RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        
        #endregion
    }
}
