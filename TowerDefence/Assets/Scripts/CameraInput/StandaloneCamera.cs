using UnityEngine;

namespace CameraInput
{
    public class StandaloneCamera : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        
        [Header("Camera Settings")]
        [SerializeField] private Transform _camera;
        [SerializeField] private float _speed = 5f;
        
        private void LateUpdate()
        {
            float horizontal = Input.GetAxis(Horizontal);
            float vertical = Input.GetAxis(Vertical);
           
            Vector3 direction = new Vector3(-vertical, 0, horizontal);
            _camera.position += _speed * Time.deltaTime * direction.normalized;
        }
    }
}