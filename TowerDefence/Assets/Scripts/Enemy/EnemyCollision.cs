using UnityEngine;

namespace Enemy
{
    public class EnemyCollision : MonoBehaviour
    {
        private const string Finish = "Finish";

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Finish))
            {
                Destroy(gameObject);
            }
        }
    }
}