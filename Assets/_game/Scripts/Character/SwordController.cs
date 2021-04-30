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
        [SerializeField] private Vector3 destinationRotation, destinationRotationOpp;
        
        private Rigidbody _rigidbody;
        private Quaternion _destinationRotation, _destinationRotationOpp;
        private Quaternion _rotationBuffer = Quaternion.identity;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _destinationRotation = Quaternion.Euler(destinationRotation);
            _destinationRotationOpp = Quaternion.Euler(destinationRotationOpp);
        }

        private void FixedUpdate()
        {
            ApplyRotation();
        }

        public void Jump()
        {
            Rotate(_destinationRotationOpp);
            ClearRotationBuffer();
            _rigidbody.AddForce(staticForce);
            Rotate(_destinationRotation);
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
