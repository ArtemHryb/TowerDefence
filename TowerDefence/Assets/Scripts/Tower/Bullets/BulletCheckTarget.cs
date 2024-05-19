using UnityEngine;

namespace Tower.Bullets
{
    public class BulletCheckTarget : MonoBehaviour
    {
        public Transform Target { get; private set; }
        
        public void Seek(Transform target) =>
            Target = target;

        public void CheckTarget()
        {
            if (Target == null) 
                Destroy(gameObject);
        }
        private void Update() => CheckTarget();
    }
}