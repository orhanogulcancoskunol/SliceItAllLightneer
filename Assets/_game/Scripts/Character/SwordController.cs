using System;
using System.Collections;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordController : MonoBehaviour
    {
        public Quaternion Rotation => _rigidbody.rotation;
        public float RotationSpeed;
        public void ClearRotationBuffer() => _rotationBuffer = Quaternion.identity;
        
        [SerializeField] private Vector3 staticForce;
        
        private Rigidbody _rigidbody;
        private Quaternion _rotationBuffer = Quaternion.identity;
        private bool _isActive;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            ApplyRotation();
        }

        public void Jump()
        {
            ClearRotationBuffer();
            _rigidbody.AddForce(staticForce);
            Rotate(Quaternion.Euler(-180,0,0));
        }
        
        private void ApplyRotation()
        {
            var usedBuffer = Quaternion.Lerp(Quaternion.identity, _rotationBuffer, RotationSpeed);
            _rigidbody.MoveRotation(_rigidbody.rotation * usedBuffer);
            _rotationBuffer *= Quaternion.Inverse(usedBuffer);
        }

        public void Rotate(Quaternion rotation)
        {
            _rotationBuffer *= rotation;
        }

    }
}
