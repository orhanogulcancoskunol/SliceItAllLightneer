using System;
using System.Collections;
using System.Collections.Generic;
using _game.Scripts.Managers;
using _game.Scripts.Utilities.Interfaces;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordController : MonoBehaviour, IActiveSetters
    {
        public bool IsActive { get; set; }
        private Rigidbody _rigidbody;
        private bool _isRotating;
        private float _durationForReJumpLimit;
        [SerializeField] private Vector3 staticForce;
        
        [Header("ReJump Values")]
        [SerializeField] private float durationForJump = 4f;
        [SerializeField] private float velocityYLimit = -4f;
        [SerializeField][Range(60,360)] private float flyingSpinSpeed = 60f;
        [SerializeField] [Range(180, 720)] private float reJumpSpeed = 360f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            SpinOnFly();
            ReJump();
        }

        private void OnEnable()
        {
            GameManager.OnLevelStart += SetEnabled;
            GameManager.OnLevelFailed += DisableStopActive;
            GameManager.OnLevelCompleted += DisableStopActive;
        }

        private void OnDisable()
        {
            GameManager.OnLevelStart += SetEnabled;
            GameManager.OnLevelFailed -= DisableStopActive;
            GameManager.OnLevelCompleted -= DisableStopActive;
        }

        private void SpinOnFly()
        {
            if (_rigidbody.velocity.y >= velocityYLimit && _rigidbody.velocity.y!=0 && !_isRotating && IsActive)
            {
                transform.Rotate(flyingSpinSpeed*Time.fixedDeltaTime, 0 ,0);
            }
        }

        private void ReJump()
        {
            if (_rigidbody.velocity.y < velocityYLimit)
            {
                transform.Rotate(reJumpSpeed*Time.fixedDeltaTime, 0 ,0);
            }
        }

        public void Jump(Vector3 customStaticForce = default)
        {
            _rigidbody.AddForce(customStaticForce != default ? customStaticForce : staticForce);
            StopAllCoroutines();
            StartCoroutine(Rotate(durationForJump));
        }

        private IEnumerator Rotate(float duration)
        {
            var startRot = transform.rotation;
            var t = 0f;
            _isRotating = true;
            while ( t  < duration )
            {
                t += Time.fixedDeltaTime;
                transform.rotation = startRot * Quaternion.AngleAxis(t / duration * 360f, Vector3.right);
                yield return null;
            }

            if (t >= duration)
            {
                _isRotating = false;
            }
            transform.rotation = startRot;
        }

        #region freezeX

        public void UnFreezeRotation()
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

        private void DisableStopActive()
        {
            StopAllCoroutines();
            SetDisabled();
        }

        public Vector3 GetStaticForceForHit()
        {
            return staticForce * 2;
        }

        public void DisableRotate()
        {
            _isRotating = true;
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
