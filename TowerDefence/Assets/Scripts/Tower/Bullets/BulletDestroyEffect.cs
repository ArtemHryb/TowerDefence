using UnityEngine;

namespace Tower.Bullets
{
    public class BulletDestroyEffect : MonoBehaviour
    {
        [SerializeField] private GameObject _destroyEffect;
        
        private const float DestroyEffectDelay = 1f;
        
        public void SpawnEffect()
        {
            GameObject effect = Instantiate(_destroyEffect, transform.position, transform.rotation);
            Destroy(effect, DestroyEffectDelay);
        }
    }
}