using Architecture.Services;
using Audio;
using Tower.Selection;
using UnityEngine;
using Zenject;

namespace Tower
{
    public class TowerCharacteristics : MonoBehaviour
    {
        public TowerInfo Tower { get; private set; }
        public int Damage { get; private set; }
        public float FireSpeed { get; private set; }
        public int AttackRange { get; private set; }
        public int BulletSpeed { get; private set; }
        
        [SerializeField] private TowerType _towerType;
        
        public SfxType SfxType;

        private ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        [Inject]
        public void Construct(ICurrentLevelSettingsProvider currentLevelSettingsProvider) => 
            _currentLevelSettingsProvider = currentLevelSettingsProvider;

        private void Awake() =>
            Initialize();

        private void Initialize()
        {
            GetCurrentTowerSettings();

            Damage = Tower.Bullet.Damage;
            BulletSpeed = Tower.Bullet.Speed;
            FireSpeed = Tower.FireSpeed;
            AttackRange = Tower.AttackRange;
        }
        
        private void GetCurrentTowerSettings()
        {
            foreach (TowerSelectionButton button in _currentLevelSettingsProvider.GetCurrentLevelSettings().TowerSelectionButtons.Buttons) 
            {
                if (button.Tower.TowerType == _towerType) 
                    Tower = button.Tower;
            }
        }
        
    }
}