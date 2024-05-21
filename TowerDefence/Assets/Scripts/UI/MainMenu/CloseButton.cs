using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake() =>
            _button.onClick.AddListener(() => Destroy(gameObject));
    }
}