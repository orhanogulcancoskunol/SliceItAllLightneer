using System;
using System.Collections;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordController : MonoBehaviour
    {
        [SerializeField] private Vector3 staticForce;
        [SerializeField] private float durationJumpRotation;
        private Rigidbody _rigidbody;
        private bool _isJump;
        private WaitForSeconds durationJumpRotationSeconds;
        private Coroutine _currentJumpCoroutine;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            _rigidbody.AddForce(staticForce);
            if(_currentJumpCoroutine!=null)
                StopCoroutine(_currentJumpCoroutine);
            _currentJumpCoroutine = StartCoroutine(RotationSetter());
        }

        private IEnumerator RotationSetter()
        {
            _isJump = true;
            yield return durationJumpRotationSeconds;
            _isJump = false;
        }
    }
}
