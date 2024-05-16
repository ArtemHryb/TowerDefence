using TMPro;
using Tower.Selection;
using UnityEngine;

namespace Tower.Price
{
    public class DisplayTowerPrice : MonoBehaviour
    {
        [SerializeField] private TowerSelectionButtonHolder _holder;
        [SerializeField] private TextMeshProUGUI _priceText;

        private void Start() =>
            DisplayText();

        private void DisplayText() =>
            _priceText.text = _holder.Tower.Price.ToString();
    }
}