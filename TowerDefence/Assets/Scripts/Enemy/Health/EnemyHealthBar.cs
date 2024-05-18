using System;
using Architecture.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Enemy.Health
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        
        [SerializeField] private Slider _slider;

        private ICurrentLevelSettingsProvider _currentLevelSettingsProvider;
        
        [Inject]
        public void Construct(ICurrentLevelSettingsProvider currentLevelSettingsProvider) => 
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        private void Start()
        {
            Initialize();
            _enemyHealth.OnHealthChanged += UpdateHealthBar;
        }

        private void OnDestroy() => 
            _enemyHealth.OnHealthChanged -= UpdateHealthBar;

        private void LateUpdate() => 
            transform.LookAt(Camera.main.transform);

        private void Initialize()
        {
            _slider.maxValue = _currentLevelSettingsProvider.GetCurrentLevelSettings().EnemyData.MaxHp;
            _slider.value = _currentLevelSettingsProvider.GetCurrentLevelSettings().EnemyData.MaxHp;
        }

        private void UpdateHealthBar() => 
            _slider.value = _enemyHealth.CurrentHp;
    }
}