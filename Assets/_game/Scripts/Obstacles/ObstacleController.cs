using _game.Scripts.Character;
using _game.Scripts.Character.SwordParts;
using _game.Scripts.ScriptableObjects;
using UnityEngine;

namespace _game.Scripts.Obstacles
{
    public class ObstacleController : MonoBehaviour
    {
        public ObstacleSO ObstacleInfo;
        public Rigidbody PieceLeft, PieceRight;

        [SerializeField]private TagConstantsSO tagConstants;
        private const float _timeToDestroy = 8f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<SwordBottom>(out var bot))
            {
                bot.JumpSetter();
            }
            if (!other.tag.Equals(tagConstants.Player)) return;
            GetComponent<Collider>().enabled = false;
            UpdateScore(other);
            ApplyForceToPieces();
        }

        private void UpdateScore(Component other)
        {
            other.GetComponentInParent<SwordPolishController>().SetHitObject(other.transform);
            other.GetComponentInParent<SwordScoreController>().OnObstacle.Invoke(ObstacleInfo.Score);
        }

        private void ApplyForceToPieces()
        {
            PieceLeft.isKinematic = false;
            PieceRight.isKinematic = false;
            PieceLeft.AddForce(new Vector3(-ObstacleInfo.AppliableForce.x,ObstacleInfo.AppliableForce.y, ObstacleInfo.AppliableForce.z));
            PieceRight.AddForce(ObstacleInfo.AppliableForce);
            Destroy(gameObject, _timeToDestroy);
        }
    }
}
