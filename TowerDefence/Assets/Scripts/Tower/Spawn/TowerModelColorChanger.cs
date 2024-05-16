using Architecture.Services.Factories.UI;
using UnityEngine;
using Zenject;

namespace Tower.Spawn
{
    public class TowerModelColorChanger : MonoBehaviour
    {
        [SerializeField] private Material _modelMaterial;

        private readonly Color32 _lightGreenColor = new(144, 217, 144, 255);
        private readonly Color32 _lightRedColor = new(229, 113, 109, 255);

        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        private void OnMouseEnter()
        {
            if (_uiFactory.TowerSelection?.SelectedButton != null)
                ChangeColor(_lightRedColor);
        }

        private void OnMouseExit()
        {
            if (_uiFactory.TowerSelection?.SelectedButton != null)
                ChangeColor(_lightGreenColor);
        }

        private void ChangeColor(Color32 color) =>
            _modelMaterial.color = color;
    }
}