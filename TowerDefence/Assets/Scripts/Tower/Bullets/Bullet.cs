using UnityEngine;

namespace Tower.Bullets
{
    public class Bullet : MonoBehaviour
    {
        public int BulletSpeed { get; private set; }
        public int Damage { get; set; }
        
        public BulletCheckTarget BulletCheckTarget;

        private TowerCharacteristics _towerCharacteristics;
        
        private void Awake() => 
            Initialize();

        private void Initialize()
        {
            _towerCharacteristics = GetComponentInParent<TowerCharacteristics>();
            BulletSpeed = _towerCharacteristics.BulletSpeed;
            Damage = _towerCharacteristics.Damage;
        }
    }
}