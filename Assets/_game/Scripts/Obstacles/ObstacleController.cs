using System;
using _game.Scripts.Managers;
using _game.Scripts.ScriptableObjects;
using UnityEngine;

namespace _game.Scripts.Obstacles
{
    public class ObstacleController : MonoBehaviour
    {
        public ObstacleSO ObstacleInfo;
        public Rigidbody PieceLeft, PieceRight;
        
        private const string _playerTag = "Player";
        private const float _timeToDestroy = 8f;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.tag.Equals(_playerTag)) return;
            GetComponent<Collider>().enabled = false;
            PieceLeft.isKinematic = false;
            PieceRight.isKinematic = false;
            PieceLeft.AddForce(new Vector3(-ObstacleInfo.AppliableForce.x,ObstacleInfo.AppliableForce.y, ObstacleInfo.AppliableForce.z));
            PieceRight.AddForce(ObstacleInfo.AppliableForce);
            Destroy(gameObject, _timeToDestroy);
        }
    }
}
