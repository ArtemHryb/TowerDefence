using UnityEngine;

namespace Tower.Visualisation
{
    [RequireComponent(typeof(LineRenderer))]
    public class TowerAttackVisualisation : MonoBehaviour
    {
        [SerializeField] private float _attackRange = 30f;
        [SerializeField] private int _segments = 50;
        private LineRenderer _lineRenderer;
        
        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.useWorldSpace = false;
            _lineRenderer.loop = true;
            DrawAttackRadius();
        }

        private void DrawAttackRadius()
        {
            _lineRenderer.positionCount = _segments + 1;
            float angle = 0f;

            for (int i = 0; i <= _segments; i++)
            {
                float x = Mathf.Sin(Mathf.Deg2Rad * angle) * _attackRange;
                float z = Mathf.Cos(Mathf.Deg2Rad * angle) * _attackRange;
                _lineRenderer.SetPosition(i, new Vector3(x, 0, z));
                angle += 360f / _segments;
            }
        }

        private void OnValidate()
        {
            if (_lineRenderer != null)
            {
                DrawAttackRadius();
            }
        }
    }
}